using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    Shoot _shoot;
    public GameObject _builetPrefab;
    public Transform _transformForStartBuilett;

    [SerializeField, Range(0, 500f)]
    float _damage = 10f;
    [SerializeField, Range(0, 5000f)]
    float _range = 500f;
    [SerializeField, Range(0, 500f)]
    float _shootRate = 10f;
    [SerializeField, Range(0, 10000f)]
    float _speedFlyBuilett = 10f;
    Camera _camera;
    private float _nextTimeToFire = 0f;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _shoot = new Shoot(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        AtackEnemy();

    }

    private void AtackEnemy()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= _nextTimeToFire)
        {
            _nextTimeToFire = Time.time + 1f / _shootRate;
            _shoot.Shooting
                (
                _camera.transform.position,
                _camera.transform.forward,
                _transformForStartBuilett.position,
                _range, _builetPrefab,
                _damage,
                _speedFlyBuilett
                );
        }
    }
}




