using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponSwitch : MonoBehaviour
{
    /*
    public playerAttack meleeAttack; // Ссылка на скрипт атаки в ближнем бою
    public WeaponSurek surekAttack; // Ссылка на скрипт запуска снарядов
    */
    public Image attackIcon; // Ссылка на изображение иконки атаки в GUI
    public Sprite meleeAttackIcon; // Иконка для ближнего боя
    public Sprite rangedAttackIcon; // Иконка для дальнего боя

    public bool isMeleeMode = true; // Переменная для отслеживания текущего режима атаки

    // Метод для переключения режима атаки
    public void ToggleAttackMode()
    {
        isMeleeMode = !isMeleeMode; // Инвертируем значение переменной
        UpdateAttackIcon();
        // Включаем или выключаем соответствующие скрипты в зависимости от режима
        /*
        meleeAttack.enabled = isMeleeMode;
        surekAttack.enabled = !isMeleeMode;
        */
    }

    private void UpdateAttackIcon()
    {
        if (attackIcon != null)
        {
            attackIcon.sprite = isMeleeMode ? meleeAttackIcon : rangedAttackIcon; // Устанавливаем нужную иконку в зависимости от режима
        }
    }

}
