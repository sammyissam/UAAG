using UnityEngine;

namespace Game.Overworld
{
    public class OverworldMovement : MonoBehaviour
    {

        public Rigidbody2D rb;

        public float speed = 5;







        void Update()

        {
            // four way movement code
            //gets the up and down movement
            Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            //gives the speed
            rb.velocity = movement * speed;

        }

    }
}