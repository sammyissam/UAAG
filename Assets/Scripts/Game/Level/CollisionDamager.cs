using System;
using Game.Level.Player;
using UnityEngine;

namespace Game.Level.Enemy
{
    public class CollisionDamager : MonoBehaviour
    {
        [Space(20)] [SerializeField] private Transform left;
        [SerializeField] private Transform right;
        [SerializeField] private float threshhold;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private PlayerHealth playerHealth;
        [SerializeField] private float amountOfDamage;

        [SerializeField] private float timeCooldown;

        private float cooldown;


        private void Start()
        {
            playerHealth = PlayerSpawnerManager.instance.player.GetComponent<PlayerHealth>();
        }

        // Im aware this is horrible code, i just have bigger priorities than to fix this.
        private void Update()
        {
            cooldown -= Time.deltaTime;

            if (Physics2D.Raycast(left.position, Vector2.left, threshhold, layerMask))
            {
                if (cooldown < 0)
                {
                    playerHealth.TakeDamage(amountOfDamage);
                    cooldown = timeCooldown;
                }
            }
            else if (Physics2D.Raycast(right.position, Vector2.right, threshhold, layerMask))
            {
                if (cooldown < 0)
                {
                    playerHealth.TakeDamage(amountOfDamage);
                    cooldown = timeCooldown;
                }
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.layer == 3)
            {
                playerHealth.TakeDamage(amountOfDamage);
            }
        }
    }
}