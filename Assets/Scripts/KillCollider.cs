using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillCollider : MonoBehaviour
{
    public GameObject gameovertext;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.gameObject.CompareTag("Player"))
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Game Over");
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.KillPlayer();
        }
    }
}