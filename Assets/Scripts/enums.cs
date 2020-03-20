using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData 
{
    public static int SCORE = 0;
    public static int HEALTHCOUNT = 3;
    public static int minHealthCount = 1;
    public static int healthValue = 1;
}

public class enums : MonoBehaviour 
{
    public void LoadGameScene (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log(sceneName);
    }
}