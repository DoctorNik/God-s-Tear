using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeDamage : MonoBehaviour
{
    [SerializeField] public int lives = 100;

    void Start()
    {
        
    }
    public void TakeDamage(int damageAmount)
    {
        lives -= damageAmount;
        if (lives <= 0)
        Debug.Log("PLayer has taken " + damageAmount);
        {
            GameManager.instance.GameOver();
        }
    }

    
} 
