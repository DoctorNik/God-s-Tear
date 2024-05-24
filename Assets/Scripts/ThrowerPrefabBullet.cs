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
        if ((playerLayer.value & (1 << collision.gameObject.layer)) != 0)
        {
            takeDamage player = collision.gameObject.GetComponent<takeDamage>();
            if (player != null)
            {
                player.TakeDamage(damage);
                DestroySelf();
            }
        }
    }
}
