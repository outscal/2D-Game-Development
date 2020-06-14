using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public GameObject LevelCompleteUI;

	public int nextSceneLoad;

	private void Start()
	{
		nextSceneLoad = SceneManager.GetActiveScene().buildIndex +1;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.gameObject.CompareTag("Player"))
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            //Level is over
            Debug.Log("Level is finished");
            LevelCompleteUI.SetActive(true);
        }
    }
	public void NextLevel()
	{
		if(SceneManager.GetActiveScene().buildIndex == 6)
		{
			Debug.Log("YOU WIN THE GAME");
		}
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		else
		{
			SceneManager.LoadScene(nextSceneLoad);

			if(nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
			{
				PlayerPrefs.SetInt("levelAt", nextSceneLoad);
			}
		}
	}

	public void ReloadLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void levelSelector()
	{
		SceneManager.LoadScene(1);
	}
}
