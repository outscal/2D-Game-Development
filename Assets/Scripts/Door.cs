using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isCompleted = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
           isCompleted =  LevelController.instance.LevelCheck();
            if(isCompleted == true)
            {
                Destroy(collision.gameObject);
            }
            //Debug.Log("level successfully checked");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            LevelController.instance.UncompleteLevelCheck();

        }
    }

}
