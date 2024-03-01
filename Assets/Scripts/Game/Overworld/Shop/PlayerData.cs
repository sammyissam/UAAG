using System;

namespace Game.Overworld.Shop
{
    [Serializable]
    public class PlayerData : ICloneable
    {
        public float coins;

        //This is the Qty of all Shop Items
        public float speedBoostQty;
        public float healthBoostQty;
        public float extraAmmoQty;

        public bool hasSword;
        public bool hasGun;

        public PlayerData()
        {
        }

        public PlayerData(float coins, float speedBoostQty, float healthBoostQty, float extraAmmoQty, bool hasSword, bool hasGun)
        {
            this.coins = coins;
            this.speedBoostQty = speedBoostQty;
            this.healthBoostQty = healthBoostQty;
            this.extraAmmoQty = extraAmmoQty;
            this.hasSword = hasSword;
            this.hasGun = hasGun;
        }


        public object Clone()
        {
            return new PlayerData(coins, speedBoostQty, healthBoostQty, extraAmmoQty, hasSword, hasGun);
        }
    }
}