using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpItem : MonoBehaviour
{
    public float _healthUpValue = 50;
    private void OnTriggerEnter(Collider coll)
    {
       
        if (coll.gameObject.GetComponent<HealthComponent>())
        {
            //  coll.gameObject.GetComponent<HealthComponent>().Health += _healthUpValue;
            coll.gameObject.GetComponent<IDamageble>().TakeDamage(-_healthUpValue);

            gameObject.SetActive(false);
        }
    }

}
