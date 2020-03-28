using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour 
{
    public static LevelController instance;

    public GameObject levelComplteUI;
    public GameObject gameCompleteUI;
    public GameObject gameOverUI;
    public Text  collectKeyUI;
    public GameObject[] lockImages;
    public int score;
    public Text scoreText;
    public List<Level> levels;
    private int currentLevel;
    private bool isLevelCompleted;
    private Dictionary<string, int> levelsInfo;

    private void Awake()
    {
        setLevelInfo();

    }
    void Start ()
    {
        levelsInfo = new Dictionary<string, int>();
        instance = this;
        CheckAllLevelUnlocks();
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        GameData.SCORE = 0;
        checkLevelInfo();
    }

    private void checkLevelInfo()
    {
        if(levels.Count > 2)
        {
        readLevelInfo();
        applyLevelInfo();
        }

    }

    private void setLevelInfo()
    {
        if (PlayerPrefs.GetInt("SetLevelInfo") == 0)
        {
             PlayerPrefs.SetInt("level1", 1);
             for (int i = 0; i < levels.Count; i++)
             {
                  Debug.Log("level set");
                  PlayerPrefs.SetInt("level" + (i + 2).ToString(), 0);
             }
        }
        else
        {
            return;
        }
        PlayerPrefs.SetInt("SetLevelInfo", 1);
    }

    private void readLevelInfo()
    {
        for (int i = 0; i < levels.Count; i++)
        {
            levelsInfo["Level" + (i + 1).ToString()] = PlayerPrefs.GetInt("level" + (i + 1).ToString());

        }
    }

    public void applyLevelInfo()
    {
        for (int i = 0; i < levels.Count; i++)
        {
            if (levelsInfo["Level" + (i + 1).ToString()] == 1)
            {
            lockImages[i].SetActive(false);
            }
            else
            {
             lockImages[i].SetActive(true);
            }

        }
    }


    public void SetGameoverUI()
    {
        StartCoroutine(GameOverUI());
    }

    IEnumerator GameOverUI()
    {
        yield return new WaitForSeconds(1f);
        gameOverUI.SetActive(true);
        SoundManager.instance.playGameSound(Sfx.GameSfx.GameOver, true);
    }
    
    public void SetGameCompleteUI()
    {
        SoundManager.instance.playPlayerSound(Sfx.PlayerSfx.Death,false);
        StartCoroutine(GameCompleteUI());
    }

    IEnumerator GameCompleteUI()
    {
        yield return new WaitForSeconds(1f);
        gameCompleteUI.SetActive(true);
        SoundManager.instance.playGameSound(Sfx.GameSfx.GameComplete, true);
    } 
    public void SetLevelCompleteUI()
    {
        StartCoroutine(LevelCompleteUI());
    }

    IEnumerator LevelCompleteUI()
    {
        yield return new WaitForSeconds(1f);
        levelComplteUI.SetActive(true);
        SoundManager.instance.playGameSound(Sfx.GameSfx.LevelComplete, true);
    }




    public void CheckAllLevelUnlocks()
    {
        if (levels.Count <2 )
        {
            SoundManager.instance.playGameSound(Sfx.GameSfx.GameBg,true);
            levels[0] = GameObject.FindObjectOfType<Level>();
            levels[0].UpdateCurrentLevel();
            levels[0].UpdateCurrentKeys();
        }
    }

    public void LoadNextLevel()
    {
        PlayUISfx();
        PlayerPrefs.SetInt("level" + (currentLevel+1).ToString() , 1 );
        SceneManager.LoadScene(currentLevel + 1);
        levelComplteUI.SetActive(false);
    }

    public void PlayUISfx()
    {
        SoundManager.instance.playUiEffectSound(Sfx.UISfx.ButtonClick, false);
    }

    public void UpdateScore()
    {
        score = GameData.SCORE;
        scoreText.text = "Score: " + score;
    }

    public bool LevelCheck()
    {
        
         isLevelCompleted = levels[0].checkUnlock();
        if(isLevelCompleted)
        {

            if (currentLevel == (SceneManager.sceneCountInBuildSettings-1))
            {
                SetGameCompleteUI();
            }
            else
            {
                SetLevelCompleteUI();
            }
            levels[0].ResetKeys();
            return true; // so the player can be destroyed from door script
        }
        else
        {   
            collectKeyUI.text = "Please collect all keys";
            return false;
        }
    }
     
    public void IncreseLevelKeyCount()
    {
        levels[0].IncreaseKeyCount();
    }

    public void UncompleteLevelCheck()
    {
        collectKeyUI.text = "";
    }

    public void RestartGame () 
    {
        PlayUISfx();
        levelComplteUI.SetActive(false);
        SceneManager.LoadScene (currentLevel);
    }
    public void LoadMainMenu()
    {   
        PlayUISfx();
        levelComplteUI.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }

}