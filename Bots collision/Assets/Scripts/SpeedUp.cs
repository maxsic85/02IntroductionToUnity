using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour,ItimeGradble
{
    public delegate void GetTimeAbillity(int _duration);
    public  event GetTimeAbillity IsElapsed;

    [SerializeField]
    private float _speedUpValue;
    [SerializeField]
    private int _duration;
    private IMoveble _enemy;
    private bool _isTimerStart;
    private float secondgametime = 0;
    private int timersecond = 0;
    private float secondgametimereset = 0;

    private void Start()
    {
        IsElapsed += Destr;
    }
    private void Update()
    {
        if (_isTimerStart) StartTimer(ref _duration);

    }
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.GetComponent<IMoveble>() != null)
        {

            _enemy = coll.gameObject.GetComponent<IMoveble>();
            _enemy.Speed += _speedUpValue;
            _isTimerStart = true;
            gameObject.GetComponent<Transform>().position = new Vector3(9999, 0, 0);
            return;
        }
    }
    public void StartTimer(ref int duration)
    {
        //duration -= (int)(Time.deltaTime * 50);

        secondgametime += Time.deltaTime;
        if (secondgametime >= 1.0)
        {
            duration -= 1;
            print(duration);
        }
        if (secondgametime >= 1.0)
        {
            secondgametime = secondgametimereset;
        }
        if (duration <= 0)
        {
            IsElapsed(duration);
            _isTimerStart = false;
            return;
        }
    }
    void Destr(int a)
    {
        if (_enemy != null) _enemy.Speed -= _speedUpValue;
        Destroy(this.gameObject);
    }

}


