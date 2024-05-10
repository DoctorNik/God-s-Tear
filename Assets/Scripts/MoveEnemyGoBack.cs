using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyGoBack : MonoBehaviour
{
    Enemy EnemyData;
    void Start()
    {
        EnemyData = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, EnemyData.player.position) > EnemyData.stoppingDistance)
        {
            EnemyData.goBack = true;
            EnemyData.angry = false;
        }

        if (EnemyData.goBack == true)
        {
            GoBack();
        }
    }

    void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, EnemyData.point.position, EnemyData.speed * Time.deltaTime);
        EnemyData.speed = 3;
    }

    
}
