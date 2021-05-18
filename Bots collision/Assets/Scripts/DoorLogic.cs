using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    public GameObject Key;
    private void OnTriggerEnter(Collider coll)
    {
        print($"Enter {coll.name}");
        if (!coll.gameObject.GetComponent<Inventory>()) return;
        else if (coll.gameObject.GetComponent<Inventory>().CurrentInventory.Contains(Key))
        {
            gameObject.SetActive(false);
        }
    }

}
