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

        private Rigidbody _rigidbody;

        public void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Update()
        {
            _movement.Move(_inputService.Axis, _rigidbody);
        }
    }
}