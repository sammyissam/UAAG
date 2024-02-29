using System;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace Game.Level
{
    public class JumpBase : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rB2D;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private float groundRadius;


        [SerializeField] private LayerMask groundMask;

        [SerializeField] private float jumpMagnitude = 10;
        [SerializeField] internal bool grounded;
  


        internal virtual void FixedUpdate()
        {
            JumpLogic();
        }

      

        private void JumpLogic()
        {
            if (Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundMask))
            {
                grounded = true;
            }
            else
            {
                grounded = false;
            }
        }

        internal void Jump()
        {
            rB2D.AddForce(new Vector2(0f, jumpMagnitude));
        }
    }
}