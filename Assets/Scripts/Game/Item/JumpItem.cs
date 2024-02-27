using Game.Movement;
using UnityEngine;

namespace Game.Item
{
    public class JumpItem : Item
    {
        [SerializeField] private PlayerJump playerJump;
        
        
        private protected override void Pickup()
        {

            playerJump.maxJumps += 1;

        }
    }
}