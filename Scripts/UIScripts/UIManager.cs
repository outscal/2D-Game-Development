using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    public GameObject LevelCompleteUI;
    public GameObject LevelIncompleteUI;
    public GameObject LevelCompletePanel;
    public GameObject RestartButton;
    public static UIManager instance;
    public TextMeshProUGUI collectableText;


    public struct Collectables
    {
        public int waterDrops;
        public int health;
        public int craftingItems;
        string intialText;
    }
    private Collectables thisCollectable;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }
    private void Start()
    {

        collectableText.text = collectableText.text + thisCollectable.waterDrops.ToString();
        thisCollectable.waterDrops = 0;
    }

    public void LevelCompleteCheck()
    {
        LevelCompletePanel.SetActive(true);

        if (thisCollectable.waterDrops == 5)
        {
            LevelCompleteUI.SetActive(true);
            RestartButton.SetActive(true);
        }
        else
        {
            LevelIncompleteUI.SetActive(true);
        }
        PlayerController.instance.gamePaused = true;
    }
    public void UpdateCollectableUI()
    {
        thisCollectable.waterDrops++;
        collectableText.text = thisCollectable.waterDrops.ToString();
    }
}
