using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSwitch : MonoBehaviour
{
    public class WeaponSwitch : MonoBehaviour
{
    public playerAttack meleeAttack; // Ссылка на скрипт атаки в ближнем бою
    public WeaponSurek surekAttack; // Ссылка на скрипт запуска снарядов

    public bool isMeleeMode = true; // Переменная для отслеживания текущего режима атаки

    // Вызывается при нажатии клавиши для переключения режима атаки
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) // АРТУР это смена режима атаки
        {
            ToggleAttackMode();
        }
    }

    // Метод для переключения режима атаки
    private void ToggleAttackMode()
    {
        isMeleeMode = !isMeleeMode; // Инвертируем значение переменной

        // Включаем или выключаем соответствующие скрипты в зависимости от режима
        meleeAttack.enabled = isMeleeMode;
        surekAttack.enabled = !isMeleeMode;
    }
}

}
