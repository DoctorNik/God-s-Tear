using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDogChill : MonoBehaviour
{
    Dog DogData;
    void Start()
    {
        DogData = GetComponent<Dog>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DogData.chill == true)
        {
            DogData.speed = 0f;
        }
    }
}
