using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour {
    void Start () {

    }

    private void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.tag == "player") {
            GamaeData.SCORE++;
            Debug.Log ("Score= " + GamaeData.SCORE);
            Destroy (gameObject);
        }
    }

    void Update () {

    }
}