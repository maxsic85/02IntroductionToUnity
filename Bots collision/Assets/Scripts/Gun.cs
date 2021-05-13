using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject _builetPrefab;
    public Transform _transformForStartBuilett;

    [SerializeField,Range(0,500f)]
    float _damage = 10f;
    [SerializeField,Range(0,5000f)]
    float _range = 500f;
    [SerializeField,Range(0,10000f)]
    float _speedFlyBuilett = 3000f;
    Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) Shoot();

    }

    private void Shoot()
    {
        RaycastHit _hit;
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out _hit, _range))
        {
            Debug.DrawLine(_camera.transform.position, _hit.transform.position, Color.red);
            Debug.Log($"{_hit.transform.name}");

            GameObject outBuilett = Instantiate(_builetPrefab, _transformForStartBuilett.position, Quaternion.identity);

            outBuilett.GetComponent<Rigidbody>().AddForce(transform.forward * _speedFlyBuilett);
            Destroy(outBuilett, 2f);

            Target _currentTarget = _hit.transform.GetComponent<Target>();
            if (_currentTarget != null) _currentTarget.TakeDamage(_damage);
        }
    }
}
