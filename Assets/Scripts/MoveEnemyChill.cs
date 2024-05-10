using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyChill : MonoBehaviour
{
    Enemy EnemyData;

    void Start()
    {
        EnemyData = GetComponent<Enemy>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, EnemyData.point.position) < EnemyData.positionOfPatrol && EnemyData.angry == false)
        {
            EnemyData.chill = true;
        }

        if (EnemyData.chill == true)
        {
            Chill();
        }
    }
    void Chill()
    {
        if (transform.position.x > EnemyData.point.position.x + EnemyData.positionOfPatrol)
        {
            EnemyData.movingRight = false;
        }
        else if (transform.position.x < EnemyData.point.position.x - EnemyData.positionOfPatrol)
        {
            EnemyData.movingRight = true;
        }

        if (EnemyData.movingRight)
        {
            transform.position = new Vector2(transform.position.x + EnemyData.speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - EnemyData.speed * Time.deltaTime, transform.position.y);
        }

        EnemyData.speed = 3;
    }
}
