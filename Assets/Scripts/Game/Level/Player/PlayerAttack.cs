using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 10;
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            Attack();
        }
    }

    void Attack()
    {
        //Play Animation
        animator.SetTrigger("Attack");

        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);


        //Damage All
        foreach(Collider2D enemy in hitEnemies)
        {
            //Debug.Log("We hit" + enemy.name);

            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }

    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
