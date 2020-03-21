using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            GameData.SCORE++;
            LevelController.instance.UpdateScore();
            Destroy(gameObject);
        }
    }

   
}