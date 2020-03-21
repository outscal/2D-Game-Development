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
    public Text  collectKeyUI;
    public GameObject[] lockImages;
    public int score;
    public Text scoreText;
    public List<Level> levels;
    private int currentLevel;
    private bool isLevelCompleted;



   

    void Start ()

    {
        instance = this;
        CheckAllLevelUnlocks();
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        GameData.SCORE = 0;
    }

    private void OnCollisionEnter2D (Collision2D other) 
    {
        if (other.gameObject.tag == "player") {
            levelComplteUI.SetActive (true);
            Time.timeScale = 0;
        }
    }


    public void CheckAllLevelUnlocks()
    {
        if (levels.Count <2 )
        {
            levels[0] = GameObject.FindObjectOfType<Level>();
            levels[0].UpdateCurrentLevel();
            levels[0].UpdateCurrentKeys();
            return;
        }
        else
        {
            if (PlayerPrefs.GetInt("Level1")==1)
            {
                for (int i = 0; i < levels.Count; i++)
                {
                    if (PlayerPrefs.GetInt("Level" +  (i+1).ToString())== (i+1))
                    {
                        lockImages[i].SetActive(false);
                    }
                    else
                    {
                        lockImages[i].SetActive(true);
                    }
                }
            }
            else
            {
                lockImages[0].SetActive(false);
            }
        }
    }

    public void LoadNextLevel()
    {
        if (currentLevel == 1)
        {
            PlayerPrefs.SetInt("Level" + currentLevel.ToString() , currentLevel );
            PlayerPrefs.SetInt("Level" + (currentLevel+1).ToString() , currentLevel+1 );
            SceneManager.LoadScene(currentLevel + 1);
            levelComplteUI.SetActive(false);

        }
        else
        {
            PlayerPrefs.SetInt("Level" + (currentLevel+1).ToString() , currentLevel+1 );
            SceneManager.LoadScene(currentLevel + 1);
            levelComplteUI.SetActive(false);

        }
    }

    public void UpdateScore()
    {
        score = GameData.SCORE;
        scoreText.text = "Score: " + score;
    }

    public void LevelCheck()
    {
        
         isLevelCompleted = levels[0].checkUnlock();
        if(isLevelCompleted)
        {

            if (currentLevel == (SceneManager.sceneCountInBuildSettings-1))
            {
                gameCompleteUI.SetActive(true);
                levels[0].ResetKeys();
            }
            else
            {
                levelComplteUI.SetActive(true);
                levels[0].ResetKeys();
            }
        }
        else
        {   
            collectKeyUI.text = "Please collect all keys";
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
        levelComplteUI.SetActive(false);
        SceneManager.LoadScene (currentLevel);
    }
    public void LoadMainMenu()
    {
        levelComplteUI.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }

}