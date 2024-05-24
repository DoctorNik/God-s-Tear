using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Thrower : MonoBehaviour
{
    public int lives = 100;
    public float speed;
    public int positionOfPatrol;
    public Transform PatrolPoint;
    public bool movingRight;

    [HideInInspector] public Transform player;
    public float stoppingDistance;

    public bool chill = false;
    public bool angry = false;

    public float attackRange = 0.5f; 

    public int damage = 10; 
    public float attackRate = 0.1f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        lives -= damage;

        // play hurt animation

        if (lives <= 0)
            Die();
    }

    private void Die()
    {
        Debug.Log("Enemy deid!");

        // die animation

        // disable the enemy
        gameObject.SetActive(false);
        GetComponent<Collider2D>().enabled = false;
        AudioManager.instance.Play("Victory");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
