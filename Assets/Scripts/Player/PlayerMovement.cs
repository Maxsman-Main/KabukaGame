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
        
        [SerializeField] private float jumpForce = 15f;
        
        private Transform groundCheck;
        private Rigidbody _rigidbody;
        private bool isRight;
        private LayerMask groundLayer;
        
        public void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            groundLayer = LayerMask.GetMask("Ground");
            groundCheck = GetComponentInChildren<Transform>();
            isRight = true;
        }

        public void Update()
        {
            _movement.Move(_inputService.Axis, _rigidbody);
            _movement.Flip(ref isRight, transform, _inputService.HorizontalRaw);
        }
    }
}