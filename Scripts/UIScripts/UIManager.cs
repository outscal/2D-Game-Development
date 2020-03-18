using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Texts")]
    public TextMeshProUGUI LevelCompleteUI;
    public TextMeshProUGUI LevelIncompleteUI;
    public TextMeshProUGUI waterCounterText;

    [Header("Images")]
    public Image LevelCompletePanel;
    public Image GameOverImage;

    [Header("HealthUI")]
    public List<Image> ListOfHearts;
    private Image HeartToBeDisabled;

    [Header("Buttons")]
    public GameObject RestartButton;

    [Header("Unity Essentials")]
    public static UIManager instance;
    private Collectables thisCollectable;
    public struct Collectables
    {
        public int waterDrops;
        //add here other collectables as per need...:) 
    }
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }
    private void Start()
    {
        if (waterCounterText)
            waterCounterText.text = waterCounterText.text + thisCollectable.waterDrops.ToString();
        thisCollectable.waterDrops = 0;
    }

    public void Level1CompleteCheck()
    {
        LevelCompletePanel.enabled = true;

        if (thisCollectable.waterDrops == 5)
        {
            LevelCompleteUI.enabled = true;
            LoadLevelManager.instance.UnlockLevel(2);
            RestartButton.SetActive(true);
        }
        else
        {
            LevelIncompleteUI.enabled = true;
        }
        PlayerController.instance.gamePaused = true;
    }
    public void UpdateWaterCounterUI()
    {
        thisCollectable.waterDrops++;
        waterCounterText.text = "X" + thisCollectable.waterDrops.ToString();
    }

    public void UpdateHealthUI()
    {
        PlayerStats.instance.currentHeartcount -= 1;
        HeartToBeDisabled = ListOfHearts[PlayerStats.instance.currentHeartcount];
        HeartToBeDisabled.enabled = false;
    }
    public void DeathUI()
    {
        GameOverImage.enabled = true;
        RestartButton.SetActive(true);
    }

}

