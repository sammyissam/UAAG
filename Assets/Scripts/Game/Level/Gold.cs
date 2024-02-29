using Game.Overworld.Shop;
using UnityEngine;

namespace Game.Level
{
    public class Gold : Item
    {
        public override void PickedUp(GameObject GO)
        {
            PlayerManager.instance.workingData.coins += 2;
        }
    }
}