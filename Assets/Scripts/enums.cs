using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData 
{
    public static int SCORE = 0;
    public static int HEALTHCOUNT = 3;
    public static int minHealthCount = 1;
    public static int maxHealthCount = 3;
    public static int healthValue = 1;
}

public class Sfx
{
    public enum PlayerSfx
    {
        Walk,
        Jump,
        Land,
        EnemyKill,
        Death,
    }
    public enum CollectibleSfx
    {
        Coin,
        Key,
        Life,
    }

    public enum GameEffects
    {

    }

    public enum UISfx
    {
        ButtonClick,
        NextLevl,
        Restart,
        PopUp,
    }
    public enum GameSfx
    {
        Intro,
        MainMenu,
        GameBg,
        GameOver,
        LevelComplete,
        GameComplete,

    }
}

public class LevelData
{
    public static int UnlockedLevels = 1;

}

public class enums : MonoBehaviour 
{
    public void LoadGameScene (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log(sceneName);
    }
}