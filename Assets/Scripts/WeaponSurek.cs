using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBullet : MonoBehaviour
{
    
    public Transform shotpos;
    public GameObject Bullet;
    
    public void FireBullet()
    {
        Instantiate(Bullet, shotpos.transform.position, transform.rotation);
    }
}
