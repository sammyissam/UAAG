/*
    This is the ShopManager script. This manages everything that happens
    in the Shop.

    Item1 = SpeedBoost
    Item2 = HealthBoost
    Item3 = ExtraAmmo

*/

using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Overworld.Shop
{
    public class ShopManager : MonoBehaviour
    {
        public int[,] shopItems = new int[5, 5];
        public float coins;
        public TMP_Text coinsTxt;

        private PlayerManager _playerManager; //This is the PlayerManager script

        // Start is called before the first frame update
        void Start()
        {
            //This finds the PlayerManager script on the PlayerManager object
            _playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();

            //ID's
            shopItems[1, 1] = 1;
            shopItems[1, 2] = 2;
            shopItems[1, 3] = 3;
            shopItems[1, 4] = 4;

            //Price
            shopItems[2, 1] = 10;
            shopItems[2, 2] = 20;
            shopItems[2, 3] = 30;
            shopItems[2, 4] = 40;

            //This will load the data from PlayerManager and set the coins 
            //and quantity of all the items in the shop.
            _playerManager.LoadData();
            coins = _playerManager.Data.coins;

            //Quantity
            shopItems[3, 1] = Mathf.FloorToInt(_playerManager.Data.speedBoostQty);
            shopItems[3, 2] = Mathf.FloorToInt(_playerManager.Data.healthBoostQty);
            shopItems[3, 3] = Mathf.FloorToInt(_playerManager.Data.extraAmmoQty);
            shopItems[3, 4] = 0;

            //This update the coins text
            coinsTxt.text = "Coins:" + coins.ToString("N0");
        }

        //This runs when an item button is pressed
        public void Buy()
        {
            GameObject buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>()
                .currentSelectedGameObject;

            if (coins >= shopItems[2, buttonRef.GetComponent<ButtonInfo>().ItemID])
            {
                coins -= shopItems[2, buttonRef.GetComponent<ButtonInfo>().ItemID];
                shopItems[3, buttonRef.GetComponent<ButtonInfo>().ItemID]++;
                coinsTxt.text = "Coins: " + coins;
                buttonRef.GetComponent<ButtonInfo>().QuantityTxt.text =
                    shopItems[3, buttonRef.GetComponent<ButtonInfo>().ItemID].ToString();

                //This saves the amount of current coins and quantity of each item
                _playerManager.Data.coins = coins;
                _playerManager.Data.speedBoostQty = shopItems[3, 1];
                _playerManager.Data.healthBoostQty = shopItems[3, 2];
                _playerManager.Data.extraAmmoQty = shopItems[3, 3];

                _playerManager.SaveData();
            }
        }
    }
}