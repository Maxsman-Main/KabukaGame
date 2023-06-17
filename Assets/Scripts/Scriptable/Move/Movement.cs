using System.Collections;
using UnityEngine;

namespace Scriptable.Move
{
    public abstract class Movement : ScriptableObject
    {
        public float movementSpeed;

        public abstract void Move(Vector3 input, Rigidbody rigidbody, JoystickInput joystickInput);
        public abstract void Flip(ref bool isRight, Transform transform, float horizontal);
        public abstract void Jump(bool isGrounded, float jumpForce, Rigidbody rigidbody);
        public abstract IEnumerator Dash(float dashingPower, float dashingTime, float dashingCooldown, Rigidbody rigidbody, Transform transform, bool isRight);
    }
}