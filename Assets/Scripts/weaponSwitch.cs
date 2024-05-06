using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSwitch : MonoBehaviour
{
    /*
    public playerAttack meleeAttack; // Ссылка на скрипт атаки в ближнем бою
    public WeaponSurek surekAttack; // Ссылка на скрипт запуска снарядов
    */

    public bool isMeleeMode = true; // Переменная для отслеживания текущего режима атаки

    // Метод для переключения режима атаки
    public void ToggleAttackMode()
    {
        isMeleeMode = !isMeleeMode; // Инвертируем значение переменной

        // Включаем или выключаем соответствующие скрипты в зависимости от режима
        /*
        meleeAttack.enabled = isMeleeMode;
        surekAttack.enabled = !isMeleeMode;
        */
    }

}
