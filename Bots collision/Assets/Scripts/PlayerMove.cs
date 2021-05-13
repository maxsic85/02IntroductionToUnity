using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Vector3 _direction;
    Vector3 _velocity;

    [SerializeField, Range(0, 500)]
    float _speed = 25;
    [SerializeField, Range(-50, 50)]
    float _gravity = -25;
    CharacterController _controller;

    void Start()
    {
        _controller = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
    }


    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");
        Vector3 mov = transform.right * _direction.x + transform.forward * _direction.z;
        _controller.Move(mov * _speed * Time.deltaTime);
        _velocity.y += _gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }
}
