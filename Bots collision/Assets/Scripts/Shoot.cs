using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    GameObject _current;
    public Shoot()
    { }

    public Shoot(GameObject current)
    {
        this._current = current;
    }

    public void Shooting(Vector3 _origin, Vector3 _dir, Vector3 _startBuiletPosition, float _range, GameObject _builetPref, float _damage, float _speed)
    {
        RaycastHit _hit;
        if (Physics.Raycast(_origin, _dir, out _hit, _range))
        {
            GameObject outBuilett = GameObject.Instantiate(_builetPref, _startBuiletPosition, Quaternion.identity);

            outBuilett.GetComponent<Rigidbody>().AddForce(_current.transform.forward * _speed);
            //  GameObject.Destroy(outBuilett, 2f);

            HealthComponent _currentTarget = _hit.transform.GetComponent<HealthComponent>();
            if (_currentTarget != null) _currentTarget.TakeDamage(_damage);
        }
    }
}
