using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float attackRange = 0.5f;
    public int attackDamage = 40;
    public float attackRate = 0.5f;
    private float nextAttackTime = 0f;
    public LayerMask enemyLayers;
    public Transform attackPoint;
    private weaponSwitch switchValue;
    private Rigidbody2D rb;
    private WeaponSurek weaponSurek;

    private void Start()
        {
            weaponSurek = GetComponent<WeaponSurek>(); // Получаем ссылку на компонент WeaponSurek
            switchValue = GetComponent<weaponSwitch>();
        }
        
    public void Attack()
    {
        if (switchValue.isMeleeMode)
        {
            if (Time.time < nextAttackTime)
            {
                return;
            }
            nextAttackTime = Time.time + 1f / attackRate;

            Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            foreach (Collider2D enemy in enemies)
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
        }
        else
        {
            weaponSurek.FireBullet(); // Вызываем метод FireBullet из WeaponSurek
        }
    }
}
