using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveThrowerAngry : MonoBehaviour
{
    Thrower ThrowerData;
    public GameObject projectilePrefab; // Префаб объекта, который будет бросаться
    public Transform throwPoint; // Точка, из которой будет бросаться объект
    public float minThrowForce = 5f; // Минимальная сила броска
    public float maxThrowForce = 15f; // Максимальная сила броска
    public float attackCooldown = 2f; // Время между атаками
    private float lastAttackTime;
    public float approachDistance = 2f; // Расстояние, на которое враг подходит к игроку

    void Start()
    {
        ThrowerData = GetComponent<Thrower>();
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, ThrowerData.player.position);
        if (distanceToPlayer < ThrowerData.stoppingDistance)
        {
            ThrowerData.angry = true;
            ThrowerData.chill = false;
        }

        if (ThrowerData.angry)
        {
            Angry(distanceToPlayer);
        }
    }

    void Angry(float distanceToPlayer)
    {
        if (distanceToPlayer > approachDistance)
        {
            // Подходим к игроку
            transform.position = Vector2.MoveTowards(transform.position, ThrowerData.player.position, ThrowerData.speed * Time.deltaTime);
        }
        else
        {
            // Останавливаемся и атакуем
            if (Time.time > lastAttackTime + attackCooldown)
            {
                float normalizedDistance = Mathf.Clamp01(distanceToPlayer / approachDistance); // Нормализуем расстояние до игрока
                float throwForce = Mathf.Lerp(minThrowForce, maxThrowForce, normalizedDistance); // Интерполируем между максимальной и минимальной силой броска
                ThrowProjectile(throwForce);
                lastAttackTime = Time.time;
            }
        }

        // Поворачиваем врага в зависимости от направления
        Vector2 direction = ThrowerData.player.position - transform.position;
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Повернуть вправо
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Повернуть влево
        }

        ThrowerData.speed = 4;
    }

    void ThrowProjectile(float throwForce)
    {
        // Создаем префаб объекта и бросаем его с учетом расчитанной силы
        GameObject projectile = Instantiate(projectilePrefab, throwPoint.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 direction = (ThrowerData.player.position - throwPoint.position).normalized;
            rb.AddForce(CalculateThrowVelocity(direction, throwForce), ForceMode2D.Impulse);
        }
    }

    Vector2 CalculateThrowVelocity(Vector2 direction, float force)
    {
        // Рассчитываем начальную скорость для параболического броска
        float angle = 45f; // Угол броска в градусах
        float angleRad = angle * Mathf.Deg2Rad;
        Vector2 velocity = new Vector2(direction.x * Mathf.Cos(angleRad), Mathf.Sin(angleRad)) * force;
        return velocity;
    }
}