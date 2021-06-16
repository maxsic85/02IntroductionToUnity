using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newtest : MonoBehaviour
{
    public LayerMask lm;
    // Start is called before the first frame update
    void Start()
    {
        LayerMask mask = LayerMask.GetMask("BotMask");

        if (mask==lm)
        {
            Debug.Log("yes");
        }

    //    if (Physics.Raycast(transform.position, transform.forward, 20.0f, mask))
    //    {
    //        Debug.Log("Fired and hit a wall");
    //    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
