using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreController : MonoBehaviour
{
   
    private TextMeshProUGUI scroreText;
    private int score = 0;

    private void Start()
    {
        RefreshUI();
    }

    private void Awake()
    {
        scroreText = GetComponent<TextMeshProUGUI>();
    }

    public void IncreaseScore(int incrmnt)
    {
        score += incrmnt;

        RefreshUI();
    }

    private void RefreshUI()
    {
        scroreText.text = "Score: " + score;
    }
}
