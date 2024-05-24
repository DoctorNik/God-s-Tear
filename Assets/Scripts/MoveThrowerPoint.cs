using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveThrowerPoint : MonoBehaviour
{
    Thrower ThrowerData;
    private bool wasPlayerInRange = true; // Для отслеживания состояния игрока в предыдущем кадре

    void Start()
    {
        ThrowerData = GetComponent<Thrower>();
    }

    void Update()
    {
        bool isPlayerInRange = Vector2.Distance(transform.position, ThrowerData.player.position) <= ThrowerData.stoppingDistance;

        if (!isPlayerInRange && wasPlayerInRange)
        {
            // Игрок только что вышел из радиуса
            ThrowerData.angry = false;
            ThrowerData.PatrolPoint.position = transform.position;
            ThrowerData.speed = 2;
        }
        else if (isPlayerInRange && !wasPlayerInRange)
        {
            // Игрок только что вошел в радиус
            ThrowerData.angry = true;
        }

        // Обновляем состояние для следующего кадра
        wasPlayerInRange = isPlayerInRange;
    }
}
