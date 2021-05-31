using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WayPointPatrol : MonoBehaviour, IBot
{
    public GameObject _builetPref;
    public Transform _transformBulletStart;
    public LayerMask _masks_playerMask, _groundMask, _botMask;
    public NavMeshAgent _navMeshAgent;

    [SerializeField]
    private List<Transform> _waypoints;
    [SerializeField]
    private Transform[] _currentPoints;
    [SerializeField]
    private float _patrulDistance = 20.0f;
    [SerializeField]
    private float _aTtackDistance = 10.0f;
    [SerializeField, Range(0, 500f)]
    int _shootDelay = 1;//sec
    [SerializeField, Range(0, 500f)]
    int _shootPeriod = 500; //msec

    private GameObject _player;
    private Shoot shooting;
    timeManager tm;
    System.Random r;
    int m_CurrentWaypointIndex;
    private bool ispatrolDistance, isAttackDistance, isAtacking;
    private bool isShootYet;
    [SerializeField]
    private Transform red;
    [SerializeField]
    private Transform blue;

    public GameObject CurrentBot { get => this.gameObject; }

    void Start()
    {
        tm = new timeManager(_shootDelay, _shootPeriod);
        tm.StartTimerWithOutDispose(this);
        shooting = new Shoot(this.gameObject);
        r = new System.Random();
        _player = GameObject.FindGameObjectWithTag("Player");

        _waypoints = new List<Transform>();
        GetListPoints();
        CreateRandomPOintsForPatrul(2, out Transform[] points);
        _currentPoints = points;

    }
    void Update()
    {
        if (!ispatrolDistance && !isAttackDistance) FollowToWayPoints(_currentPoints);
        switch (gameObject.tag)
        {
            case "BotRed":
                if (ispatrolDistance && !isAttackDistance) PlayerFollowing(blue);
                if (ispatrolDistance && isAttackDistance) Attack(blue);
                break;
            case "BotBlue":
                if (ispatrolDistance && !isAttackDistance) PlayerFollowing(red);
                if (ispatrolDistance && isAttackDistance) Attack(red);
                break;
            default:
                break;
        }
        //AI();

        //   ispatrolDistance = Physics.CheckSphere(transform.position, _patrulDistance, _masks_playerMask);
        //   isAttackDistance = Physics.CheckSphere(transform.position, _aTtackDistance, _masks_playerMask);

        //if (!ispatrolDistance && !isAttackDistance) FollowToWayPoints(_currentPoints);
        //if (ispatrolDistance && !isAttackDistance) PlayerFollowing();
        //if (ispatrolDistance && isAttackDistance) Attack();
    }

    private void AI()
    {
        switch (this.gameObject.tag)
        {
            case "BotRed":
                ispatrolDistance = Physics.SphereCast(transform.position, _patrulDistance, transform.forward, out RaycastHit hitInfo01, 15, _masks_playerMask);
                isAttackDistance = Physics.SphereCast(transform.position, _aTtackDistance, transform.forward, out RaycastHit hitInfo02, 5, _masks_playerMask);
                if (!ispatrolDistance && !isAttackDistance) FollowToWayPoints(_currentPoints);
                if (ispatrolDistance && !isAttackDistance) PlayerFollowing(hitInfo01.transform);
                if (ispatrolDistance && isAttackDistance) Attack(hitInfo02.transform);
                break;
            case "BotBlue":
                // SphereCast(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask);
                // if(hitInfo.transform!=null) print(hitInfo.transform.name);
                ispatrolDistance = Physics.SphereCast(transform.position, _patrulDistance, transform.forward, out RaycastHit hitInfo, 15, _botMask);
                isAttackDistance = Physics.SphereCast(transform.position, _aTtackDistance, transform.forward, out RaycastHit hitInfo2, 5, _botMask);
                if (!ispatrolDistance && !isAttackDistance) FollowToWayPoints(_currentPoints);
                if (ispatrolDistance && !isAttackDistance) PlayerFollowing(hitInfo.transform);
                if (ispatrolDistance && isAttackDistance) Attack(hitInfo2.transform);
                //  ispatrolDistance = Physics.CheckSphere(transform.position, _patrulDistance, _botMask);
                // isAttackDistance = Physics.CheckSphere(transform.position, _aTtackDistance, _botMask);

                break;
            default:
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (gameObject.tag)
        {
            case "BotRed":
                if (other.tag == "BotBlue")
                {
                    print(other);
                    ispatrolDistance = Physics.CheckSphere(transform.position, _patrulDistance, _masks_playerMask);
                    isAttackDistance = Physics.CheckSphere(transform.position, _aTtackDistance, _masks_playerMask);
                    blue = other.transform;
                    if (!ispatrolDistance && !isAttackDistance) FollowToWayPoints(_currentPoints);
                    //if (ispatrolDistance && !isAttackDistance) PlayerFollowing(other.transform);
                    //if (ispatrolDistance && isAttackDistance) Attack(other.transform);
                }
                break;
            case "BotBlue":
                if (other.tag == "BotRed")
                {
                    ispatrolDistance = Physics.CheckSphere(transform.position, _patrulDistance, _botMask);
                    isAttackDistance = Physics.CheckSphere(transform.position, _aTtackDistance, _botMask);
                    red = other.transform;
                    if (!ispatrolDistance && !isAttackDistance) FollowToWayPoints(_currentPoints);
                    //if (ispatrolDistance && !isAttackDistance) PlayerFollowing(other.transform);
                    //if (ispatrolDistance && isAttackDistance) Attack(other.transform);
                }
                break;
            default:
                break;
        }
    }


    private void AI2()
    {
        switch (this.gameObject.tag)
        {
            case "BotRed":
                ispatrolDistance = Physics.CheckSphere(transform.position, _patrulDistance, _masks_playerMask);
                //isAttackDistance = Physics.CheckSphere(transform.position, _aTtackDistance, _botMask);
                //if (!ispatrolDistance && !isAttackDistance) FollowToWayPoints(_currentPoints);
                //if (ispatrolDistance && !isAttackDistance) PlayerFollowing(_.transform);
                //if (ispatrolDistance && isAttackDistance) Attack(hitInfo02.transform);
                break;
            case "BotBlue":
                // SphereCast(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask);
                // if(hitInfo.transform!=null) print(hitInfo.transform.name);
                ispatrolDistance = Physics.SphereCast(transform.position, _patrulDistance, transform.forward, out RaycastHit hitInfo, 15, _botMask);
                isAttackDistance = Physics.SphereCast(transform.position, _aTtackDistance, transform.forward, out RaycastHit hitInfo2, 5, _botMask);
                if (!ispatrolDistance && !isAttackDistance) FollowToWayPoints(_currentPoints);
                if (ispatrolDistance && !isAttackDistance) PlayerFollowing(hitInfo.transform);
                if (ispatrolDistance && isAttackDistance) Attack(hitInfo2.transform);
                //  ispatrolDistance = Physics.CheckSphere(transform.position, _patrulDistance, _botMask);
                // isAttackDistance = Physics.CheckSphere(transform.position, _aTtackDistance, _botMask);

                break;
            default:
                break;
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
    private void CreateRandomPOintsForPatrul(int size, out Transform[] points)
    {

        points = new Transform[size];
        for (int i = 0; i < size; i++)
        {
            points[i] = _waypoints[UnityEngine.Random.Range(0, _waypoints.Count)];
        }
        if (points[0] == points[1]) points[1] = _waypoints[UnityEngine.Random.Range(0, _waypoints.Count)];
    }
    public void FollowToWayPoints(Transform[] point)
    {
        this._navMeshAgent.speed = 3;
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % point.Length;
            _navMeshAgent.SetDestination(point[m_CurrentWaypointIndex].position);
            transform.LookAt(point[m_CurrentWaypointIndex].position);
        }
    }
    private void PlayerFollowing(Transform followingPosition)
    {
        if (followingPosition == null || transform == null)
        {
            isAttackDistance = false;
            ispatrolDistance = false;
        return;
        } 
        this._navMeshAgent.speed = 6;
        transform.LookAt(followingPosition.transform);
        _navMeshAgent.SetDestination(followingPosition.transform.position);
    }
    private void Attack(Transform followingPosition)
    {
        if (followingPosition == null || transform == null)
        {
            isAttackDistance = false;
            ispatrolDistance = false;
            return;
        }

        transform.LookAt(followingPosition.transform);
        _navMeshAgent.SetDestination(transform.position);
        if (tm.IsElapsed && !isShootYet)
        {

            isShootYet = true;
            shooting.Shooting(transform.position, transform.forward, _transformBulletStart.position, 10f, _builetPref, 25f, 10f);
        }
        else if (!tm.IsElapsed)
        {
            isShootYet = false;
            return;
        }

    }
    private void OnDrawGizmosSelected()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawSphere(transform.position, _aTtackDistance);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _patrulDistance);
    }
}