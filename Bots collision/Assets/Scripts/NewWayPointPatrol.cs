using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum team
{
    RED,
    BLUE
}

public class NewWayPointPatrol : MonoBehaviour, IMoveble
{
    public GameObject _builetPref;

    public Transform _transformBulletStart;
    public NavMeshAgent _navMeshAgent;
    public team _currentTeam;
    public Animator _animator;

    [SerializeField]
    private bool isFollowDistance;
    [SerializeField]
    private bool isAttackDistance;
    [SerializeField]
    private float _followingDistance = 7;
    [SerializeField]
    private float _aTtackDistance = 4;
    [SerializeField]
    private Transform[] _currentPoints;
    [SerializeField]
    private int _shootDelay = 1;
    [SerializeField]
    private int _shootPeriod = 250;
    private timeManager tm;
    private Shoot shooting;
    private System.Random r;
    private GameObject _player;
    private List<Transform> _waypoints;
    private bool isShootYet;
    int m_CurrentWaypointIndex;
    LayerMask _enemyMask;
    [SerializeField]
    private float _speed = 3f;


    #region implem IMove
    public float Speed { get => _speed; set => _speed = value; }
    public void Move()
    {
        throw new NotImplementedException();
    }
    #endregion

    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Start()
    {
        shooting = new Shoot(this.gameObject);
        r = new System.Random();
        _waypoints = new List<Transform>();
        tm = new timeManager(_shootDelay, _shootPeriod);
        SetTeam();
        tm.StartTimerWithOutDispose(this);
        GetListPoints();
        CreateRandomPOintsForPatrul(2, out Transform[] points);
        _currentPoints = points;
    }
    private void SetTeam()
    {
        switch (_currentTeam)
        {
            case team.RED:
                _enemyMask = LayerMask.NameToLayer("PlayerMask");
                break;
            case team.BLUE:
                _enemyMask = LayerMask.NameToLayer("BotMask");
                break;
            default:
                break;
        }
    }
    void Update()
    {
        AI(_enemyMask);
        FollowToWayPoints(_currentPoints);
        ChechMoving();
    }
    private void ChechMoving()
    {
        if (_navMeshAgent.velocity.x != 0 || _navMeshAgent.velocity.z != 0) _animator.SetBool("BotWalk", true);
        else _animator.SetBool("BotWalk", false);
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
    private void AI(LayerMask currentMask)
    {
        Collider[] hitColliders2 = Physics.OverlapSphere(transform.position, _aTtackDistance);
        foreach (var hitCollider in hitColliders2)
        {
            LayerMask mask = hitCollider.gameObject.layer;
            if (mask == currentMask)
            {
                isAttackDistance = true;
                Attack(hitCollider.transform);
                if (hitCollider.transform == null || gameObject.transform == null || (Vector3.Distance(transform.position, hitCollider.transform.position) > _aTtackDistance))
                {
                    isAttackDistance = false;
                }
                return;
            }
            else
            {
                isAttackDistance = false;
            }
        }
        if (!isAttackDistance)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _followingDistance);
            foreach (var hitCollider in hitColliders)
            {
                LayerMask mask = hitCollider.gameObject.layer;
                if (mask == currentMask)
                {
                    isFollowDistance = true;
                    FollowToEnemy(hitCollider.transform);
                    if (hitCollider.transform == null || gameObject.transform == null || (Vector3.Distance(transform.position, hitCollider.transform.position) > _followingDistance))
                    {
                        isFollowDistance = false;
                    }
                    return;
                }
                else
                {
                    isFollowDistance = false;
                }
            }
        }
    }
    private void Attack(Transform followingPosition)
    {
        transform.LookAt(followingPosition.transform);
        var a = Physics.Raycast(transform.position, transform.forward, out RaycastHit info);
        if (info.transform == null) return;
        if (info.transform.name != followingPosition.name)
        {
            _navMeshAgent.SetDestination(followingPosition.position);
          
        }
        else
        {
            _navMeshAgent.SetDestination(transform.position);
            if (tm.IsElapsed && !isShootYet)
            {
                _animator.SetBool("BotShoot", true);
                isShootYet = true;
                shooting.Shooting(transform.position, transform.forward, _transformBulletStart.position, 50f, _builetPref, 10f, 10f);
            }
            else if (!tm.IsElapsed)
            {
                _animator.SetBool("BotShoot", false);

                isShootYet = false;
                return;
            }
        }
    }
    private void FollowToEnemy(Transform followingPosition)
    {
        _speed = 7f;
        _navMeshAgent.acceleration = _speed;
        _navMeshAgent.speed = _speed;
        transform.LookAt(followingPosition.transform);
        _navMeshAgent.SetDestination(followingPosition.transform.position);
    }
    private void FollowToWayPoints(Transform[] point)
    {
        if (!isFollowDistance && !isAttackDistance)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                _navMeshAgent.speed = _speed;
                m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % point.Length;
                _navMeshAgent.SetDestination(point[m_CurrentWaypointIndex].position);
                transform.LookAt(point[m_CurrentWaypointIndex].position);
            }
        }
    }

}
