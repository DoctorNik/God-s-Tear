using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
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
		Time.timeScale = 0f;
        UIManager.Instance.ShowGameOverMenu();
    }

    public void Victory()
    {
		Time.timeScale = 0f;
        UIManager.Instance.ShowVictoryMenu();
    }

	public void NextLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	
	public void ToMenu()
	{
		SceneManager.LoadScene(0);
	}

}
