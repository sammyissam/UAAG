using System;

namespace Game.Overworld.Shop
{
    [System.Serializable]
    public class PlayerData : ICloneable
    {
        public float coins;

        //This is the Qty of all Shop Items
        public float speedBoostQty;
        public float healthBoostQty;
        public float extraAmmoQty;

        public PlayerData()
        {
            
        }
        public PlayerData(float coins, float speedBoostQty, float healthBoostQty, float extraAmmoQty)
        {
            this.coins = coins;
            this.speedBoostQty = speedBoostQty;
            this.healthBoostQty = healthBoostQty;
            this.extraAmmoQty = extraAmmoQty;
        }


        public object Clone()
        {
            return new PlayerData(coins, speedBoostQty, healthBoostQty, extraAmmoQty);
        }
    }
}