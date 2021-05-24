using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WayPointPatrol : MonoBehaviour
{
    public NavMeshAgent _navMeshAgent;
    [SerializeField]
    private List<Transform> _waypoints;
    [SerializeField]
    private Transform[] _currentPoints;
    private GameObject _player;

    int m_CurrentWaypointIndex;
    System.Random r;

    void Start()
    {
        r = new System.Random();
        _waypoints = new List<Transform>();
        _player = GameObject.FindGameObjectWithTag("Player");
        GetListPoints();
        CreateRandomPOintsForPatrul(2, out Transform[] points);
        _currentPoints = points;

    }

    private void CreateRandomPOintsForPatrul(int size, out Transform[] points)
    {
        points = new Transform[size];
        for (int i = 0; i < size; i++)
        {
            points[i] = _waypoints[UnityEngine.Random.Range(0, _waypoints.Count)];
            //points[i] = _waypoints[r.Next(0, _waypoints.Count)];

        }
    }

    private void GetListPoints()
    {
        var Points = GameObject.FindGameObjectsWithTag("WayPoint");
        foreach (var item in Points)
        {
            _waypoints.Add(item.transform);
        }
    }

    void Update()
    {
        // print($"m_CurrentWaypointIndex{m_CurrentWaypointIndex} ,navMeshAgent.remainingDistance-{navMeshAgent.remainingDistance},navMeshAgent.stoppingDistance-{navMeshAgent.stoppingDistance}");
        FollowToWayPoints(_currentPoints);
        // PlayerFollowing();

    }

    private void FollowToWayPoints(Transform[] point)
    {
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % point.Length;
            _navMeshAgent.SetDestination(point[m_CurrentWaypointIndex].position);
        }
    }

    private void PlayerFollowing()
    {
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            _navMeshAgent.SetDestination(_player.transform.position);
    }
}