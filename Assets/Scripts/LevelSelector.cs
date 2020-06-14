using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
	public Button[] levelButtons;

	void Start()
	{
		int levelAt = PlayerPrefs.GetInt("levelAt", 2);
		for(int i = 0; i < levelButtons.Length; i++)
		{
			if(i + 2 > levelAt)
			{
				levelButtons[i].interactable = false;
				Debug.Log("interactable is false");
			}
		}
	}

	public void LoadLevel (int sceneIndex)
	{
		StartCoroutine(LoadAsynchronously(sceneIndex));
	}

	IEnumerator LoadAsynchronously (int sceneIndex)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

		while(!operation.isDone)
		{
			yield return null;
		}
	}

}