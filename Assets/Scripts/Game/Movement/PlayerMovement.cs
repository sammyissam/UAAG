using UnityEngine;
using Utility.ScriptableObjects;
using Utility.UI;

namespace Game.Movement
{
    public class PlayerMovement : Pauseable
    {
        [SerializeField] private IntReference speed;
        [SerializeField] private bool rawInputs;

        [SerializeField] private Transform left;
        [SerializeField] private Transform right;

        [SerializeField] private float maxDelta;
        [SerializeField] private LayerMask groundLayer;

        private void Update()
        {
            float x;
            if (rawInputs)
            {
                x = Input.GetAxisRaw("Horizontal");
            }
            else
            {
                x = Input.GetAxis("Horizontal");
            }

            
            x *= Time.deltaTime;


            if (x > 0)
            {
                //Checks if theres a wall to the right of the player within the max delta distance. 
                if (Physics2D.Raycast(right.position, Vector2.right, maxDelta, groundLayer))
                {
                    x = 0; // Disables Horizontal movement
                }
            }
            else if (x < 0) 
            {
                // Checks if theres a wall to the left of player within maxDelta Distance
                if (Physics2D.Raycast(left.position, Vector2.left, maxDelta, groundLayer))
                {
                    x = 0; // Disables Horizontal movement
                }
            }

            
            //I dont know why we use Vars here but my IDE recommends it so i trust it 
            var transform1 = transform;
            var vector3 = transform1.position;
            
            
            vector3.x += x * speed.i; 
            transform1.position = vector3;
        }
    }
}