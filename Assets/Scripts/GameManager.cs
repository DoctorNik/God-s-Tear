using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player; // Ссылка на игрока
    public GameObject afterDeathMenu; // Ссылка на UI-элемент, который должен появиться после смерти
    public GameObject afterVictoryMenu; // Ссылка на UI-элемент, который должен появиться после постижения победного условия

    void Awake ()
	{
		if (instance != null)
		{
			Destroy(gameObject);
			return;
		} else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

    public void GameOver()
    {
        afterDeathMenu.SetActive(true);
    }

    public void Victory()
    {
        afterVictoryMenu.SetActive(true);
    }
}
