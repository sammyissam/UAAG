using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float MaxHealth = 100f;
    public float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
