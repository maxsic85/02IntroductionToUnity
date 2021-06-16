using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour, IMoveble, IJumpble
{
    public Animator _animator;
    public LayerMask _groundMask;
    public AudioClip _step;
    public AudioClip _jump;
    private AudioSource _audio;


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
    private float m_FootstepDistanceCounter;

    public float Speed { get => _speed; set => _speed = value; }
    void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }
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

        if (_direction.x != 0 || _direction.z != 0)
        {
            _animator.SetBool("walk", true);
            PlayStepSound();

        }
        else
        {
            _animator.SetBool("walk", false);
          
        } 

        Vector3 mov = transform.right * _direction.x + transform.forward * _direction.z;
        _controller.Move(mov * _speed * Time.deltaTime);
        _velocity.y += _gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);

    }

    private void PlayStepSound()
    {
        float chosenFootstepSfxFrequency = 1;
                     
        if (m_FootstepDistanceCounter >= 1f / chosenFootstepSfxFrequency)
        {
            m_FootstepDistanceCounter = 0f;
            _audio.PlayOneShot(_step);
        }

        // keep track of distance traveled for footsteps sound
        m_FootstepDistanceCounter += _velocity.magnitude * Time.deltaTime;
    }

    public void Jump()
    {

        _isGround = Physics.CheckSphere(transform.position, __groundDistance, _groundMask);
        if (Input.GetButtonDown("Jump") && _isGround)
        {
            //print("I am jump");
            _velocity.y = Mathf.Sqrt(_jumpPower * -2f * _gravity);
            _audio.PlayOneShot(_jump);
        }
    }


}
