using System.Collections;
using UnityEngine;

public class MoveThrowerChill : MonoBehaviour
{
    Thrower ThrowerData;
    private bool isWaiting = false;

    void Start()
    {
        ThrowerData = GetComponent<Thrower>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, ThrowerData.PatrolPoint.position) < ThrowerData.positionOfPatrol && !ThrowerData.angry)
        {
            ThrowerData.chill = true;
        }

        if (ThrowerData.chill && !isWaiting)
        {
            Chill();
        }
    }

    void Chill()
    {
        if (!isWaiting)
        {
            if (transform.position.x > ThrowerData.PatrolPoint.position.x + ThrowerData.positionOfPatrol)
            {
                ThrowerData.movingRight = false;
                StartCoroutine(WaitBeforeMoving());
            }
            else if (transform.position.x < ThrowerData.PatrolPoint.position.x - ThrowerData.positionOfPatrol)
            {
                ThrowerData.movingRight = true;
                StartCoroutine(WaitBeforeMoving());
            }

            if (ThrowerData.movingRight)
            {
                transform.position = new Vector2(transform.position.x + ThrowerData.speed * Time.deltaTime, transform.position.y);
            }
            else
            {
                transform.position = new Vector2(transform.position.x - ThrowerData.speed * Time.deltaTime, transform.position.y);
            }
        }
    }

    IEnumerator WaitBeforeMoving()
    {
        isWaiting = true;
        yield return new WaitForSeconds(2);
        isWaiting = false;
    }
}
