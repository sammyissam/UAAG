using UnityEngine;
using UnityEngine.Serialization;
using Vector2 = UnityEngine.Vector2;

namespace Game.Level.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rB2D;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private float groundRadius;


        [SerializeField] private LayerMask groundMask;

        [SerializeField] private float jumpMagnitude = 10;
        [SerializeField] private bool grounded;
        
        
        private float x;
        [SerializeField] private float playerSpeed;

        private void Update()
        {
            Jump();
            Move();
        }

        private void Move()
        {
            x = Input.GetAxis("Horizontal");
            
            rB2D.AddForce(new Vector2(x * Time.deltaTime * playerSpeed, 0f));
            
        }

        private void Jump()
        {
            if (Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundMask))
            {
                grounded = true;
            }
            else
            {
                grounded = false;
            }

            if (grounded)
            {
                if (Input.GetAxis("Jump") != 0)
                {
                    rB2D.AddForce(new Vector2(0f, jumpMagnitude));
                }
            }
        }
    }
}