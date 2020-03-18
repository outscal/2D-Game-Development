using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {
    public GameObject levelComplteUI;
    public int score;
    public Text scoreText;

    void Start () {
        GameData.SCORE = 0;
        score = GameData.SCORE;
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
        score = GameData.SCORE;
        scoreText.text = "Score: " + score;
    }
    public void RestartGame () {
        Time.timeScale = 1;
        SceneManager.LoadScene ("Scene1");
    }

}