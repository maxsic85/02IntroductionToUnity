using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    #region example with delegate
    //void Shoot(object o, StartTimer del)
    //{
    //    del(this);
    //    
    //}
    // Shoot(this, new StartTimer(tm.StartTimerWithOutDispose));
    //
    #endregion

public class Gun : MonoBehaviour
{
    public GameObject _builetPrefab;
    public Transform _transformForStartBuilett;

    Camera _camera;
    timeManager tm;
    Shoot _shoot;

    [SerializeField, Range(0, 500f)]
    float _damage = 10f;
    [SerializeField, Range(0, 5000f)]
    float _range = 500f;
    [SerializeField, Range(0, 500f)]
    int _shootDelay = 1;//sec
    [SerializeField, Range(0, 500f)]
    int _shootPeriod = 1000; //msec
    [SerializeField, Range(0, 10000f)]
    float _speedFlyBuilett = 10f;
    private float _nextTimeToFire = 0f;
    private bool _isElapsed;
    private bool isShootYet;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _shoot = new Shoot(gameObject);
        tm = new timeManager(_shootDelay, _shootPeriod);
    }

    void Update()
    {
        AtackEnemy();
        //test for update rate gun
        if (Input.GetButtonDown("Fire2"))
        {
            tm = new timeManager(1, 100);
            isShootYet = false;
        }
    }
    private void AtackEnemy()
    {
        if (Input.GetButtonDown("Fire1") && !isShootYet)
        {
            tm.StartTimerWithDispose(this);
            isShootYet = true;
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
        else if (tm.IsElapsed)
        {
            isShootYet = false;
            return;
        }
    }
}




