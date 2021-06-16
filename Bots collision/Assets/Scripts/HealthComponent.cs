using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour, IDamageble
{

    [SerializeField]
    float _health = 100f;

    public float Health { get => _health; set => _health = value; }

    public void TakeDamage(float amount)
    {
        if (_health > 0f) _health -= amount;
        if(_health<=0)  Die();
    }

    private void Die()
    {
        DropItem();

        Destroy(gameObject);
    }

    private void DropItem()
    {
        if (this.gameObject == null) return;
        else if (this.gameObject.GetComponent<Inventory>().CurrentInventory.Count > 0)
        {
            gameObject.GetComponent<Inventory>().CurrentInventory[0].SetActive(true);
            gameObject.GetComponent<Inventory>().CurrentInventory[0].transform.position = transform.position;
            //  Instantiate(gameObject.GetComponent<Inventory>().CurrentInventory[0], transform.position, Quaternion.identity);
        }
    }
}
