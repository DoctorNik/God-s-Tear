using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Dog : MonoBehaviour
{
    [HideInInspector] public Transform player;
    public int lives = 100;
    public bool chill = false;
    public bool angry = false;
    public float attackRange = 10f; 
    public float speed = 0f;

    public int damage = 10; 
    public float attackRate = 0.1f;
    private float nextAttackTime = 1f;
    public GameObject alertIconPrefab; // Префаб значка
    private GameObject alertIconInstance;
    public bool playerDetected = false;
    public float detectionTime = 3.0f; // Время, через которое враг начнет атаку
    private float detectionTimer = 0.0f; // Таймер для отслеживания времени в поле зрения
    AttackDog scriptAttackDog;
    private bool alertIconAlive = true; 
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        alertIconInstance = Instantiate(alertIconPrefab, transform);
        alertIconInstance.SetActive(false);
        scriptAttackDog = GetComponent<AttackDog>();
        if (alertIconInstance != null)
        {
            Vector3 iconPosition = transform.position + Vector3.up * 2; // Смещение значка над врагом
            alertIconInstance.transform.position = iconPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
         // Проверить, находится ли игрок в зоне видимости (простая проверка дистанции)
        float detectionRange = 6.0f;
        if (Vector3.Distance(transform.position, player.position) <= detectionRange)
        {
            detectionTimer += Time.deltaTime;
            if (alertIconAlive)
            {
                alertIconInstance.SetActive(true);
            }

            if (detectionTimer >= detectionTime)
            {
                playerDetected = true;
                alertIconInstance.SetActive(false);
//                Destroy(alertIconInstance); // Удалить значок
//                alertIconInstance = null;
                alertIconAlive = false;
                Debug.Log("Player detected for 3 seconds, attacking.");
            }
        }
        else
        {
            detectionTimer = 0.0f;
            if (alertIconAlive)
            {
                alertIconInstance.SetActive(false); // Скрыть значок, когда игрок выходит из зоны видимости
            }
            if (playerDetected)
            {
                playerDetected = false;
                Debug.Log("Player not detected, hiding alert icon.");
            }
        }
        
        if (Time.time >= nextAttackTime)
        {
            if (Vector2.Distance(transform.position, player.position) <= attackRange)
            {
                scriptAttackDog.AttackPlayer(damage);
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
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
