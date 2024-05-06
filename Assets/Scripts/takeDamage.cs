using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeDamage : MonoBehaviour
{
    Hero playerHero;
    public void TakeDamage(int damageAmount)
    {
        playerHero.lives -= damageAmount;
        if (playerHero.lives < 0)
        Debug.Log("PLayer has taken " + damageAmount);
        {
             Debug.Log("Player has taken too much damage and DIE");
        }
    }
} 
