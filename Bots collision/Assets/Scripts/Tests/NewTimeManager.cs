using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTimeManager : MonoBehaviour
{
    public delegate void MyElapsed(int _duration);
    public static event MyElapsed IsElapsed;
    [SerializeField]
    public bool startTimer = false;

 //   public bool StartTimer1 { get => startTimer; set => startTimer = value; }

    // Start is called before the first frame update
  

    public void StartTimer(int duration)
    {
      
     duration = OffTimer(duration);
        print(duration);
        if (duration <= 0)
        {
            IsElapsed(duration);
            startTimer = false;
            return;
        }
    }

    private  int OffTimer(int duration)
    {
        duration -= (int)(Time.deltaTime * 120);
        print(duration);
        return duration;
    }

    private static int ONTimer(int duration)
    {
        duration += (int)Time.time;
        return duration;
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            StartTimer(3);
        }
    }
}


