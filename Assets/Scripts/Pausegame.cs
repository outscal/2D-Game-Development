using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausegame : MonoBehaviour
{
    [HideInInspector]
    public bool gameIsPaused = false;

    public GameObject pauseMenuUi;

    private void Start()
    {
        pauseMenuUi.SetActive(false);

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;

    }

    private void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("ManiMenu");
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
}
