using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeDamage : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damageAmount)
    {
         currentHealth -= damageAmount;
        healthBar.SetHealth(currentHealth);
        Debug.Log($"Player has taken {damageAmount} damage. Remaining lives: {currentHealth}");
        if (currentHealth <= 0)
        {
            Debug.Log("Player has died.");
            GameManager.instance.GameOver();
        }
    }
}
