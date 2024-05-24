using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private HeroAnimControl animator;
    [SerializeField] public float attackRange = 0.5f;
    public int attackDamage = 40;
    public float attackRate = 0.5f;
    public float nextAttackTime = 0f;
    public LayerMask enemyLayers;
    public Transform attackPoint;
    private weaponSwitch switchValue;
    private Rigidbody2D rb;
    private WeaponBullet weaponSurek;
    private MeleeAttack meleeAttackSword;
    
    private void Awake()
    {
        animator = GetComponent<HeroAnimControl>();
    }
    private void Start()
        {
            weaponSurek = GetComponent<WeaponBullet>(); // Получаем ссылку на компонент WeaponSurek
            switchValue = GetComponent<weaponSwitch>();
            meleeAttackSword = GetComponent<MeleeAttack>();
        }
        
    public void Attack()
    {
        //animator.SetAttack();
        if (switchValue.isMeleeMode)
        {
            meleeAttackSword.AttackSword();
        }
        else
        {
            weaponSurek.FireBullet(); // Вызываем метод FireBullet из WeaponSurek
        }
    }
}
