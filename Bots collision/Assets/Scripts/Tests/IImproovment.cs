using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  interface IImproovment :  ItimeGradble
{
    void ToTake(Collider coll);
  
}


//public class SpeedUPImproov : Improovment
//{
//    [SerializeField]
//    private float _speedUpValue;
//    [SerializeField]
//    private int _duration;
//    timeManager _tm;
//    private IMoveble _enemy;

//    public override void ToTake(Collider coll)
//    {
//        if (coll.gameObject.GetComponent<HealthComponent>()&& _tm==null)
//        {
//            _enemy = coll.gameObject.GetComponent<IMoveble>();
//            _enemy.Speed += 5f;
          
//            return;
//        }
//    }

//    public override void StarTimer(int duration)
//    {
//        _tm = new timeManager(_duration);
//        _tm.StartTimerWithDispose(this);
//    }

//    private void OnTriggerEnter(Collider coll)
//    {
//        ToTake(coll);
//        StarTimer(_duration);
//    }

//    public void Update()
//    {
//        if (_tm.IsElapsed)
//        {
//            _enemy.Speed -= 5f;
//            Destroy(gameObject);
//        }
//    }
//}

