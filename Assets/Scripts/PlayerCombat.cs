using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;


    public Transform attackPoint;
    public float attackRange = 0.5f;

    public LayerMask enemyLayers;
    public int attackDamage = 40;

    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Attack();
        }
    }
    void Attack(){
        //play an attack animation
        animator.SetTrigger("Attack");
        ///Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange, enemyLayers);
        //Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(20);
        }
    }
    void OnDrawGizmosSelected(){
        if(attackPoint == null)
        return;
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
}
