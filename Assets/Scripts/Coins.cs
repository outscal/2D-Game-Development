using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour {
    

    //private void OnCollisionEnter2D (Collision2D other) {
    //    if (other.gameObject.tag == "player") {
    //        GamaeData.SCORE++;
    //        Debug.Log ("Score= " + GamaeData.SCORE);
    //        Destroy (gameObject);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            GameData.SCORE++;
            Debug.Log("Score= " + GameData.SCORE);
            Destroy(gameObject);
        }
    }

   
}