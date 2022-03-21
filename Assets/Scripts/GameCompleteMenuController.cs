using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameCompleteMenuController : MonoBehaviour
{
    public Button nextButton;
    public Button backButton;

    private void Awake()
    {
        nextButton.onClick.AddListener(NextLevel);
        backButton.onClick.AddListener(BackToLobby);
    }
    public void LevelComplete()
    {
        gameObject.SetActive(true);
    }
    public void NextLevel()
    {
        Debug.Log("Reloading Scene...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BackToLobby()
    {
        Debug.Log("Reloading the lobby Scene...");
        SceneManager.LoadScene(0);
    }
}
