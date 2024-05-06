using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSurek : MonoBehaviour
{
    
    public Transform shotpos;
    public GameObject Bullet;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    public void FireBullet()
    {
        Instantiate(Bullet, shotpos.transform.position, transform.rotation);
    }
}
