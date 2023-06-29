using System;
using Scriptable.Move;
using Services.InputService;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [Inject] private IInputService _inputService;
        [Inject] private Movement _movement;
        [Inject] private JoystickInput _joystickInput;
        [Inject] private Animator animator;
        
        [SerializeField] private Button _dashbtn;
        [SerializeField] private float jumpForce = 3f;
        [SerializeField] private float dashingPower = 20f;
        [SerializeField] private float dashingTime = 0.2f;
        [SerializeField] private float dashingCooldown = 1f;
        
        private const float RadiusGround = 0.2f;

        private ParticleSystem _particleSystem;
        private Transform _groundCheck;
        private Rigidbody _rigidbody;
        private bool _isRight;
        private bool dashBtn;
        public bool canDash { get; set; }
        public bool isDashing { get; set; }
        private LayerMask _groundLayer;
        
        public void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _groundLayer = LayerMask.GetMask("Ground");
            _groundCheck = GetComponentInChildren<Transform>().GetChild(0);
            _particleSystem = GetComponentInChildren<Transform>().GetChild(2).GetComponent<ParticleSystem>();
            _isRight = true;
            canDash = true;
            dashBtn = false;
        }

        public void Update()
        {
            if (isDashing) return;
            _movement.Move(_inputService.Axis, _rigidbody, _joystickInput);
            _movement.Flip(ref _isRight, transform, _inputService.HorizontalRaw + _joystickInput.Horizontal);
            _movement.Jump(GroundCheck(), jumpForce, _rigidbody, animator);
            if ((dashBtn || Input.GetButtonDown("Dash")) && canDash)
            {
                animator.SetBool("isDashing", true);
                dashBtn = false;
                StartCoroutine( _movement.Dash(dashingPower, dashingTime, dashingCooldown, _rigidbody, transform, _isRight, animator));
            }
            if (canDash)
            {
                _dashbtn.interactable = true;
            }

            var speedFloat = Math.Abs(_inputService.Axis.x + _joystickInput.Horizontal);
            animator.SetFloat("Run", speedFloat);
            if (speedFloat > 0 && GroundCheck())
            {
                SoundManager.Instance.PlayFootstep();
            }
            else
            {
                SoundManager.Instance.StopFootstep();
            }
            if (!GroundCheck())
                _particleSystem.Stop();
            else
                if (!_particleSystem.isPlaying)
                    _particleSystem.Play();
        }

        private bool GroundCheck()
        {
            return Physics.CheckSphere(_groundCheck.position, RadiusGround, _groundLayer);
        }

        public void DashBtn()
        {
            dashBtn = true;
        }
    }
}