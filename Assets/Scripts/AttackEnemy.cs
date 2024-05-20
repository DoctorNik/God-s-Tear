using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    public takeDamage  scriptTakeDamage;
    

    void Start()
    {
        scriptTakeDamage = GetComponent<takeDamage>();
        if (scriptTakeDamage == null)
        {
            Debug.LogError("takeDamage script not found on this GameObject!");
        }
    }

    // Update is called once per frame
    public virtual void AttackPlayer(int dmg)
    {
        scriptTakeDamage.TakeDamage(dmg);
    }
}
