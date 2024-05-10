using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public LayerMask enemyLayers;
    public int surekDamage;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((enemyLayers & 1 << collision.gameObject.layer) != 0)
        {
            collision.GetComponent<Enemy>().TakeDamage(surekDamage);
            Destroy(gameObject);
        }
    }
}
