using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 10;
    public LayerMask playerLayer;
    takeDamage scriptTakeDamage;

    void Start()
    {
        Invoke(nameof(DestroySelf), 5f);
        scriptTakeDamage = GetComponent<takeDamage>();
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем, если слой объекта столкновения входит в enemyLayers
        if ((playerLayer & (1 << collision.gameObject.layer)) != 0)
        {
            Hero player = collision.gameObject.GetComponent<Hero>();
            if (player != null)
            {
                scriptTakeDamage.TakeDamage(damage);
                DestroySelf();
                Debug.Log("хлеб коснулся");
            }
        }
    }
}
