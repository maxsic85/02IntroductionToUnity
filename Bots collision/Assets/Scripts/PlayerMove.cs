using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour, IMoveble, IJumpble
{
    public LayerMask _groundMask;
    private bool _isGround = true;

    Vector3 _direction;
    Vector3 _velocity;

    [SerializeField, Range(0, 500)]
    float _speed = 25;
    [SerializeField, Range(-50, 50)]
    float _gravity = -25;
    [SerializeField, Range(0, 50)]
    float _jumpPower = 2;
    [SerializeField, Range(0, 50)]
    float __groundDistance = 1;
    CharacterController _controller;

    void Start()
    {
        _controller = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
    }
    void FixedUpdate()
    {
        Move();
        Jump();
    }
    public void Move()
    {
        if (_isGround && _velocity.y < 0) _velocity.y = -2f;
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");
        Vector3 mov = transform.right * _direction.x + transform.forward * _direction.z;
        _controller.Move(mov * _speed * Time.deltaTime);
        _velocity.y += _gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }
    public void Jump()
    {

        _isGround = Physics.CheckSphere(transform.position, __groundDistance, _groundMask);
        if (Input.GetButtonDown("Jump") && _isGround)
        {
            //print("I am jump");
            _velocity.y = Mathf.Sqrt(_jumpPower * -2f * _gravity);
        }
    }
}
