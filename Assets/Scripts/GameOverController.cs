using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    //Game over when player died.

    public Button restartButton;

    private void Awake()
    {
        restartButton.onClick.AddListener(ReloadLevel);
    }
    public void GameOver()
    {
        gameObject.SetActive(true);
        //this.enabled = false;
    }
    private void ReloadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
