using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrel : MonoBehaviour
{
    timeManager tm;
    Shoot _shoot;
    Gun gun;

    public Animator _animator;
    public Transform _startBuiletPosition;
    public GameObject _builetPrefaB;
    public AudioClip _fire;
    private AudioSource _audio;

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
    [SerializeField, Range(0, 500f)]
    int _shootDelay = 1;//sec
    [SerializeField, Range(0, 500f)]
    int _shootPeriod = 250; //msec
    private bool isShootYet;

    void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    void Start()
    {
        _shoot = new Shoot(this.gameObject);
        SetDelayShoot();
        GetEnemies();
    }
    void Update()
    {
        foreach (var item in _players)
        {
            AtackEnemy(item, _shootRate);
        }
    }
    private void SetDelayShoot()
    {
        tm = new timeManager(_shootDelay, _shootPeriod);
        tm.StartTimerWithOutDispose(this);
    }
    private void GetEnemies()
    {
        _players = new List<GameObject>();
        var bots = GameObject.FindObjectsOfType<HealthComponent>();

        // var dssds = FindObjectsOfType<WayPointPatrol>().GetType().GetProperty("CurrentMob").GetValue(FindObjectOfType<WayPointPatrol>().gameObject);//.GetValue(transform.gameObject.GetComponents<GameObject>());
        //GameObject[] bots = (GameObject[])dssds;
        foreach (var item in bots)
        {
            if (item.gameObject.GetComponent<IBot>() != null) _players.Add(item.gameObject);
        }
        var _player = GameObject.FindGameObjectWithTag("Player");
        _players.Add(_player);
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

                if (tm.IsElapsed && !isShootYet)
                {
                    _animator.SetBool("shoot",true);
                    isShootYet = true;
                    _audio.PlayOneShot(_fire);
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
                else if (!tm.IsElapsed)
                {
                    _animator.SetBool("shoot", true);
                    isShootYet = false;
                    return;
                }
            }
        }
    }
}

