using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class MainMenu : MonoBehaviour
{

    public Button[] buttons;
    //public GameObject[] lockImages;

    private void Start()
    {
        SoundManager.instance.playGameSound(Sfx.GameSfx.MainMenu, true);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].onClick.AddListener(() => PlayUiSfx());
        }
    }


    public void PlayUiSfx()
    {
        SoundManager.instance.playUiEffectSound(Sfx.UISfx.ButtonClick, false);
    }

    public void LoadGameScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
