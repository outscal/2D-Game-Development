using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
    public GameObject levelComplteUI;
    void Start () {
        levelComplteUI.SetActive (false);
    }

    private void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.tag == "player") {
            levelComplteUI.SetActive (true);
            Time.timeScale = 0;
        }
    }

}