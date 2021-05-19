using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter(Collider coll)
    {
        print($"Enter {coll.name}");
        if (coll.gameObject.GetComponent<Inventory>())
        {
            coll.gameObject.GetComponent<Inventory>().CurrentInventory.Add(gameObject);
          
           gameObject.SetActive(false);
        }
    }


}
