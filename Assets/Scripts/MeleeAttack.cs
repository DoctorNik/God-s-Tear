using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    playerAttack playerAttackData;
    void Start()
    {
        playerAttackData = GetComponent<playerAttack>();
    }

    // Update is called once per frame
    public void AttackSword()
    {
        if (Time.time < playerAttackData.nextAttackTime)
            {
                return;
            }
            playerAttackData.nextAttackTime = Time.time + 1f / playerAttackData.attackRate;

            Collider2D[] enemies = Physics2D.OverlapCircleAll(playerAttackData.attackPoint.position, playerAttackData.attackRange, playerAttackData.enemyLayers);

            foreach (Collider2D enemy in enemies)
            {
                if (enemy.CompareTag("Enemy"))
                {
                    enemy.GetComponent<Enemy>().TakeDamage(playerAttackData.attackDamage);
                }
                else if (enemy.CompareTag("Thrower"))
                {
                    enemy.GetComponent<Thrower>().TakeDamage(playerAttackData.attackDamage);
                }
                else if (enemy.CompareTag("Dog"))
                {
                    enemy.GetComponent<Dog>().TakeDamage(playerAttackData.attackDamage);
                }
            }
    }
}
