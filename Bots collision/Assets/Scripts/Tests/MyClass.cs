using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyClass : MonoBehaviour
{
    private void Start()
    {
        NewTimeManager.IsElapsed += IsElapsed;
    }

    void IsElapsed(int duration)
    {

        print(Time.time);
    }
}