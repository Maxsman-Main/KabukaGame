using UnityEngine;

namespace Scriptable.Move
{
    public abstract class Movement : ScriptableObject
    {
        public float movementSpeed;

        public abstract void Move(Vector3 input, Rigidbody rigidbody);
    }
}