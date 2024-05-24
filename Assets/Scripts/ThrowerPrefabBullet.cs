using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 10;
    public LayerMask playerLayer;

    void Start()
    {
        Invoke(nameof(DestroySelf), 5f);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Collision with {collision.gameObject.name} on layer {collision.gameObject.layer}");
        if ((playerLayer.value & (1 << collision.gameObject.layer)) != 0)
        {
            Debug.Log("Collided with player layer.");
            takeDamage player = collision.gameObject.GetComponent<takeDamage>();
            if (player != null)
            {
                Debug.Log("takeDamage component found. Inflicting damage.");
                player.TakeDamage(damage);
                DestroySelf();
                Debug.Log("Projectile destroyed after collision with player.");
            }
            else
            {
                Debug.Log("takeDamage component not found on collided object.");
            }
        }
        else
        {
            Debug.Log("Collided object is not on the player layer.");
        }
    }
}
