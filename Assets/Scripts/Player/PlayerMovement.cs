using Scriptable.Move;
using Services.InputService;
using UnityEngine;
using Zenject;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [Inject] private IInputService _inputService;
        [Inject] private Movement _movement;
        
        [SerializeField] private float jumpForce = 3f;
        [SerializeField] private float dashingPower = 20f;
        [SerializeField] private float dashingTime = 0.2f;
        [SerializeField] private float dashingCooldown = 1f;
        
        private Transform _groundCheck;
        private Rigidbody _rigidbody;
        private bool _isRight;
        public bool canDash { get; set; }
        public bool isDashing { get; set; }
        private LayerMask _groundLayer;
        
        public void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _groundLayer = LayerMask.GetMask("Ground");
            _groundCheck = GetComponentInChildren<Transform>().GetChild(0);
            _isRight = true;
            canDash = true;
        }

        public void Update()
        {
            if (isDashing) return;
            _movement.Move(_inputService.Axis, _rigidbody);
            _movement.Flip(ref _isRight, transform, _inputService.HorizontalRaw);
            _movement.Jump(GroundCheck(), jumpForce, _rigidbody);
            if (Input.GetButtonDown("Dash") && canDash) 
                StartCoroutine( _movement.Dash(dashingPower, dashingTime, dashingCooldown, _rigidbody, transform, _isRight));
        }

        private bool GroundCheck()
        {
            return Physics.CheckSphere(_groundCheck.position, .1f, _groundLayer);
        }
    }
}