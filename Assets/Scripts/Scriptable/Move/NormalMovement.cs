using UnityEngine;

namespace Scriptable.Move
{
    [CreateAssetMenu(fileName = FileName, menuName = MenuName)]
    public class NormalMovement : Movement
    {
        private const string FileName = "NormalMovement";
        private const string MenuName = "Movement/NormalMovement";

        public override void Move(Vector3 input, Rigidbody rigidbody)
        {
            Vector2 newVelocity = new Vector2(input.x * movementSpeed, rigidbody.velocity.y); 
            rigidbody.velocity = newVelocity;
        }

        public override void Flip(ref bool isRight, Transform transform, float horizontal)
        {
            if (isRight && horizontal < 0f || !isRight && horizontal > 0f)
            {
                var rotate = transform.rotation.normalized;
                if (isRight)
                {
                    rotate.y = 180;
                }
                else
                {
                    rotate.y = 0;
                }
                transform.rotation = rotate;
                
                isRight = !isRight;
            }
        }
    }
}