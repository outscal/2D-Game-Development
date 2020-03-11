using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIButtonsManager : MonoBehaviour
{

    // Start is called before the first frame update


    private void Start()
    {
    }

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
        UIManager.instance.LevelCompletePanel.SetActive(false);
        if (UIManager.instance.LevelCompleteUI.activeSelf)
            UIManager.instance.LevelCompleteUI.SetActive(false);
        else if (UIManager.instance.LevelIncompleteUI.activeSelf)
            UIManager.instance.LevelIncompleteUI.SetActive(false);

    }

}
