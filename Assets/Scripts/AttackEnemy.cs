using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    [HideInInspector] public takeDamage  scriptTakeDamage;
    

    public void Start()
    {
        scriptTakeDamage = GetComponent<takeDamage>();
    }

    // Update is called once per frame
    public virtual void AttackPlayer(int dmg)
    {
        scriptTakeDamage.TakeDamage(dmg);
    }
}
