using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    private void OnCollisionEnter(Collision coll)
    {
        if (coll != null)
            Destroy(gameObject);
        
    }
    private void Start()    5SSSSSSSSSSSS
    {
        Destroy(gameObject, 2f);
    }
}
