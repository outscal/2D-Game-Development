using UnityEngine;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button startButton;
    public GameObject LevelSelection;
    /*public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }*/

    private void Awake()
    {
        startButton.onClick.AddListener(PlayGame);
    }

    public void PlayGame()
    {
        //SceneManager.LoadScene(1);
        LevelSelection.SetActive(true);
    }
}
