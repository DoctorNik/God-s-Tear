using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyAngry : MonoBehaviour
{
    Enemy EnemyData;
    void Start()
    {
        EnemyData = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, EnemyData.player.position) < EnemyData.stoppingDistance)
        {
            EnemyData.angry = true;
            EnemyData.chill = false;
            EnemyData.goBack = false;
        }

        if (EnemyData.angry == true)
        {
            Angry();
        }
    }

    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, EnemyData.player.position, EnemyData.speed * Time.deltaTime);
        EnemyData.speed = 4;
    }
}
