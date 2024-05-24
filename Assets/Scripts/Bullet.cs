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
        Invoke(nameof(DestroySelf), 5f);
    }
    
    void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((enemyLayers & 1 << collision.gameObject.layer) != 0)
        {
            if (collision.CompareTag("Dog"))
            {
                collision.GetComponent<Dog>().TakeDamage(surekDamage);
            }
            else if (collision.CompareTag("Thrower"))
            {
                collision.GetComponent<Thrower>().TakeDamage(surekDamage);
            }
            else if (collision.CompareTag("Enemy"))
            {
                collision.GetComponent<Enemy>().TakeDamage(surekDamage);
            }
            
            DestroySelf();
        }
    }
}
