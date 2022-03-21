﻿using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{

    public Button restartButton;
    public Button backButton;

    private void Awake()
    {
        restartButton.onClick.AddListener(ReloadLevel);
        backButton.onClick.AddListener(BackToLobby);
    }
    public void GameOver()
    {
        gameObject.SetActive(true);
    }
    private void ReloadLevel()
    {
        Debug.Log("Reloading Scene...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToLobby()
    {
        Debug.Log("Reloading the lobby Scene...");
        SceneManager.LoadScene(0);
    }
}
