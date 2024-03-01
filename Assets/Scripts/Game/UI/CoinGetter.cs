using System;
using Game.Overworld.Shop;
using TMPro;
using UnityEngine;

namespace Game.UI
{
    public class CoinGetter : MonoBehaviour
    {
        [SerializeField] private bool useWorkingData;
        [SerializeField] private TextMeshProUGUI textMeshProUGUI;

        private void Update()
        {
            if (useWorkingData)
            {
                textMeshProUGUI.text = "Coins: " + PlayerManager.instance.workingData.coins;
            }
            else
            {
                textMeshProUGUI.text = "Coins: " + PlayerManager.instance.Data.coins;
            }
        }
    }
}