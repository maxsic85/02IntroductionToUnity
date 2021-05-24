using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WayPointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public List<Transform> waypoints;

    int m_CurrentWaypointIndex;

    void Awake()
    {
        if (waypoints.Count == 0)
        {
            waypoints.Add(GameObject.FindGameObjectWithTag("WayPoint").transform);
        }
        navMeshAgent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
        //navMeshAgent.SetDestination(waypoints[0].position);

    }

    void Update()
    {

        //print($"m_CurrentWaypointIndex{m_CurrentWaypointIndex} ,navMeshAgent.remainingDistance-{navMeshAgent.remainingDistance},navMeshAgent.stoppingDistance-{navMeshAgent.stoppingDistance}");
        //if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        //{
        //    m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Count;
        //    navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        //}
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            navMeshAgent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);


    }

    public void PrintSomthing()
    {
        print("Hello");
    }
}