using Game.UI;
using UnityEngine;

namespace Game.Level.Player
{
    public class PlayerHealth : GiveText, IDamageable
    {
        [SerializeField] private float initialHealth;

        [SerializeField] private float currentHealth;

        
        
        
        
        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            if (currentHealth < 0)
            {
                
            }
            
        }

        public override string GetText()
        {
            return "Health: " + currentHealth.ToString("N0");
        }
    }
}