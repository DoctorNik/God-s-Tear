using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject afterDeathMenu; // Ссылка на UI-элемент, который должен появиться после смерти
    public GameObject afterVictoryMenu; // Ссылка на UI-элемент, который должен появиться после постижения победного условия

    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void ShowGameOverMenu()
    {
        afterDeathMenu.SetActive(true);
    }

    public void ShowVictoryMenu()
    {
        afterVictoryMenu.SetActive(true);
    }
}