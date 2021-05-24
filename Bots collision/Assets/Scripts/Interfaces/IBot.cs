using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 interface IBot 
{
    public GameObject CurrentBot { get;  }
    void FollowToWayPoints(Transform[] point);
}
