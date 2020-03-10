using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {
    public GameObject levelComplteUI;
    public int score;
    public Text scoreText;
    void Start () {
        GamaeData.SCORE = 0;
        score = GamaeData.SCORE;
        scoreText.text = "Score: " + score;
        levelComplteUI.SetActive (false);
        Debug.Log ("enum = " + score);
    }

    private void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.tag == "player") {
            levelComplteUI.SetActive (true);
            Time.timeScale = 0;
        }
    }

    void Update () {
        score = GamaeData.SCORE;
        scoreText.text = "Score: " + score;
    }

}