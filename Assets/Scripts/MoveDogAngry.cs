using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDogAngry : MonoBehaviour
{
    Dog DogData;
    void Start()
    {
        DogData = GetComponent<Dog>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DogData.playerDetected)
        {
            DogData.angry = true;
            DogData.chill = false;
        }

        if (DogData.angry == true) 
        {
            Angry();
        }
    }

    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, DogData.player.position, DogData.speed * Time.deltaTime);
        DogData.speed = 6;
    }
}
