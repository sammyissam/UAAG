using UnityEngine;

namespace Game.Level.Movement
{
    public class PlayerJump : JumpBase
    {
        internal void Update()
        {

            if (grounded)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    Jump();
                }
            }
        }
    }
}