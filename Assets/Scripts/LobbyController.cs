using UnityEngine;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button startButton;
    public GameObject LevelSelection;

    private void Start()
    {
        startButton.onClick.AddListener(PlayGame);
    }

    public void PlayGame()
    {
        LevelSelection.SetActive(true);
    }
}
