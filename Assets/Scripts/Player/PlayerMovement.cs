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
        
        private Transform _groundCheck;
        private Rigidbody _rigidbody;
        private bool _isRight;
        private LayerMask _groundLayer;
        
        public void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _groundLayer = LayerMask.GetMask("Ground");
            _groundCheck = GetComponentInChildren<Transform>().GetChild(0);
            _isRight = true;
        }

        public void Update()
        {
            _movement.Move(_inputService.Axis, _rigidbody);
            _movement.Flip(ref _isRight, transform, _inputService.HorizontalRaw);
            _movement.Jump(GroundCheck(), jumpForce, _rigidbody);
        }

        private bool GroundCheck()
        {
            return Physics.CheckSphere(_groundCheck.position, .1f, _groundLayer);
        }
    }
}