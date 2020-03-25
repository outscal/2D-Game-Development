using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Level[] levels;
    public GameObject[] lockImages;


    private void Start()
    {
        for (int i = 0; i < levels.Length; i++)
        {
          
        }
    }

    public void LoadGameScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
