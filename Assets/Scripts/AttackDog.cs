using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDog : AttackEnemy
{
    public int dmg = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void AttackPlayer(int dmg)
    {
        scriptTakeDamage.TakeDamage(dmg);
    }
}
