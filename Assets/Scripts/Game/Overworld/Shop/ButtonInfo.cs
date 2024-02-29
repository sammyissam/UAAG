/*
    This script goes on every button in the shop to buy goods
    and power ups.

*/

using Game.Overworld.Shop;
using UnityEngine;
using TMPro;

public class ButtonInfo : MonoBehaviour
{
    public int ItemID; //This is the ID of the Button and powerUp
    public TMP_Text PriceTxt; //This is the price text on the button
    public TMP_Text QuantityTxt; //This is the quantity of the item text
    public GameObject ShopManager; //This is the ShopManager object
    private ShopManager _shopManager;

    private void Start()
    {
        _shopManager = ShopManager.GetComponent<ShopManager>();
    }

    void Update()
    {
        //This will update both the price and quantity text on the botton
        PriceTxt.text = "Price: $" + _shopManager.shopItems[2, ItemID];
        QuantityTxt.text = _shopManager.shopItems[3, ItemID].ToString();
    }
}