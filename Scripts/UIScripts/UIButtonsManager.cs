using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIButtonsManager : MonoBehaviour
{

    public void StartTheGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }

    public void RestartTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OkButton()
    {
        UIManager.instance.LevelCompletePanel.enabled = false;
        if (UIManager.instance.LevelCompleteUI.enabled)
            UIManager.instance.LevelCompleteUI.enabled = false;
        else if (UIManager.instance.LevelIncompleteUI.enabled)
            UIManager.instance.LevelIncompleteUI.enabled = true;

    }

}
