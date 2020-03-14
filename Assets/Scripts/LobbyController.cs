using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{

    public Button buttonPlay;
    // Start is called before the first frame update

    private void Awake()
    {
        buttonPlay.onClick.AddListener(PlayGame);
    }

    // Update is called once per frame
    private void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
