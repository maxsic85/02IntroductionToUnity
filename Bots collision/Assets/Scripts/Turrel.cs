using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrel : MonoBehaviour
{
    Shoot _shoot;
    Gun gun;

    public Transform _startBuiletPosition;
    public GameObject _builetPrefaB;

    [SerializeField, Range(0, 500f)]
    float _damage = 10f;
    [SerializeField, Range(0, 5000f)]
    float _range = 500f;
    [SerializeField, Range(0, 500f)]
    float _shootRate = 10f;
    [SerializeField, Range(0, 10000f)]
    float _speedFlyBuilett = 10f;
    [SerializeField]
    private List<GameObject> _players;
    [SerializeField]
    private float _speedRotation = 5f;
    [SerializeField]
    private float _minDistance = 10f;

    private float _nextTimeToFire = 0f;
   
    void Start()
    {
        _players = new List<GameObject>();
        var bots = GameObject.FindGameObjectsWithTag("Bot");
        foreach (var item in bots)
        {
            _players.Add(item);
        }
        var _player = GameObject.FindGameObjectWithTag("Player");
        _players.Add(_player);

        _shoot = new Shoot(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in _players)
        {
            AtackEnemy(item,_shootRate);
        }
    }

    private void AtackEnemy(GameObject item, float shootRate)
    {
        if (item != null)
        {
            if (Vector3.Distance(transform.position, item.transform.position) < _minDistance)
            {
                Vector3 relative = item.transform.position - transform.position;
                Vector3 newDir = Vector3.RotateTowards(transform.forward, relative,
                    _speedRotation * Time.deltaTime, 0f);
                transform.rotation = Quaternion.LookRotation(newDir);

                if (Time.time >= _nextTimeToFire)
                {
                    _nextTimeToFire = Time.time + 1f / shootRate;

                    _shoot.Shooting
                                                        (
                                                        transform.GetChild(0).position,
                                                         newDir,
                                                        _startBuiletPosition.position,
                                                        _range,
                                                        _builetPrefaB,
                                                        _damage,
                                                        _speedFlyBuilett
                                                        );
                }
            }
        }
    }
}
