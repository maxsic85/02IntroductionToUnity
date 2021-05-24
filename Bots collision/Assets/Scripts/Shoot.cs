using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Timers;

public struct Shoot
{
    GameObject _current;

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
            IDamageble dmg = _hit.transform.GetComponent<IDamageble>();
            if (dmg != null) dmg.TakeDamage(_damage);
        }
    }
}
