using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using playerMovement;

public class LevelCompleteController : MonoBehaviour
{
    public string LevelTwo;
    private void OnTriggerEnter2D(Collider2D collision) {
        
        if(collision.gameObject.GetComponent<PlayerController>() != null) {
            //Game is over
            Debug.Log("Level finished by the player");
            SceneManager.LoadScene(LevelTwo);
        }
    }
}
