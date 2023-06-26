using System.Collections;
using Player;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Scriptable.Move
{
    [CreateAssetMenu(fileName = FileName, menuName = MenuName)]
    public class NormalMovement : Movement
    {
        private const string FileName = "NormalMovement";
        private const string MenuName = "Movement/NormalMovement";
        
        private float coyoteTimeCounter;
        private float jumpBufferCounter;
        
        

        public override void Move(Vector3 input, Rigidbody rigidbody, JoystickInput joystickInput)
        {
            Vector2 newVelocity = new Vector2((input.x + joystickInput.Horizontal) * movementSpeed, rigidbody.velocity.y); 
            rigidbody.velocity = newVelocity;
        }

        public override void Flip(ref bool isRight, Transform transform, float horizontal)
        {
            if ((!isRight || !(horizontal < 0f)) && (isRight || !(horizontal > 0f))) return;
            var rotate = transform.rotation.normalized; //use rotation because rigidbody3d don't support scale with minus
            rotate.y = isRight ? 180 : 0;
                
            transform.rotation = rotate;
                
            isRight = !isRight;
        }

        public override void Jump(bool isGrounded, float jumpForce, Rigidbody rigidbody, Animator animator)
        {
            if (isGrounded)
            {
                coyoteTimeCounter = 0.2f;
                animator.SetBool("isJumping", false);
            }
            else
            {
                animator.SetBool("isJumping", true);
                coyoteTimeCounter -= Time.deltaTime;
            }

            if (jumpClick.isUIButtonDown || Input.GetButtonDown("Jump"))
            {
                animator.SetBool("isJumping", true);
                jumpBufferCounter = 0.2f;
                jumpClick.isUIButtonDown = false;
            }
            else 
                jumpBufferCounter -= Time.deltaTime;
            
            if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
                jumpBufferCounter = 0f;
            }
            
            
            if ((Input.GetButtonUp("Jump") || jumpClick.isUIButtonUp) && rigidbody.velocity.y > -0.5f )
            {
                jumpClick.isUIButtonUp = false;
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y * 0.5f);
                coyoteTimeCounter = 0f;
            }
        }

        public override IEnumerator Dash(float dashingPower, float dashingTime, float dashingCooldown, Rigidbody rigidbody, Transform transform, bool isRight, Animator animator)
        {
            PlayerMovement _playerMovement = transform.gameObject.GetComponent<PlayerMovement>();
            _playerMovement.canDash = false;
            
            _playerMovement.isDashing = true;
            
            rigidbody.useGravity = false;
            
            rigidbody.velocity = isRight
                ? new Vector2(transform.localScale.x * dashingPower, 0f)
                : new Vector2(-transform.localScale.x * dashingPower, 0f);
            yield return new WaitForSeconds(dashingTime);
            animator.SetBool("isDashing", false);
            rigidbody.useGravity = true;
            
            _playerMovement.isDashing = false;
            
            yield return new WaitForSeconds(dashingCooldown);
            
            _playerMovement.canDash = true;
        }
    }
}