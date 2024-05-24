using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeDamage : MonoBehaviour
{
    [SerializeField] public int lives = 100;

    void Start()
    {
        // Необязательный код инициализации
    }

    public void TakeDamage(int damageAmount)
    {
        lives -= damageAmount;
        Debug.Log($"Player has taken {damageAmount} damage. Remaining lives: {lives}");
        if (lives <= 0)
        {
            Debug.Log("Player has died.");
            GameManager.instance.GameOver();
        }
    }
}
