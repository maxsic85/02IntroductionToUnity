using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowToPlayer : MonoBehaviour
{

    Transform _playerTransform;
    Vector3 _dir;
    [SerializeField]
    private float _speed=5f;

    // Start is called before the first frame update
    void Awake()
    {
        _playerTransform = (GameObject.FindGameObjectWithTag("Player")).transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _dir = Vector3.Lerp(transform.position, _playerTransform.position,  _speed * Time.fixedDeltaTime);
        transform.position = _dir;
    }
}
