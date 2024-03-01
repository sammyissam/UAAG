using System;
using Game.Overworld.Shop;
using Game.UI;
using UnityEngine;
using UnityEngine.Serialization;
using Utility.GameFlow;

namespace Game.Level.Player
{
    public class PlayerHealth : GiveText, IDamageable
    {
        [SerializeField] private float initialHealth;

        [SerializeField] private float currentHealth;

        [SerializeField] private TriggerParent deathTrigger;
        [SerializeField] private float defaultHealth;
        

        private void Start()
        {
            initialHealth = PlayerManager.instance.Data.healthBoostQty * 5;
            initialHealth += defaultHealth;

            currentHealth = initialHealth;
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            if (currentHealth < 0)
            {
                deathTrigger.Trigger();
            }
        }

        public override string GetText()
        {
            return "Health: " + currentHealth.ToString("N0");
        }
    }

    class TriggerSwitchScene : SwitchSceneRelay
    {
        
    }
}