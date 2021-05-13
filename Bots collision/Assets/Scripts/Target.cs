using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    [SerializeField]
    float _health = 100f;

    public float Health { get => _health; private set => _health = value; }

    public void TakeDamage(float amount)
    {
        if (_health <= 0) Die();
        else _health -= amount;


    }

    private void Die()
    {
        Destroy(gameObject);
    }

}
