using UnityEngine;
using UnityEngine.SceneManagement;
using Assests.Scripts.Level;
using UnityEngine.UI;

public class LevelCompleteController : MonoBehaviour
{
    [SerializeField] GameCompleteMenuController gameCompleteMenuController;

    void OnTriggerEnter2D(Collider2D collision) {
        
        if(collision.gameObject.CompareTag("Player")) 
        {
            //Game is over           
            Debug.Log("Level finished by the player");
            LevelManager.Instance.MarkCurrentLevelComplete();
            gameCompleteMenuController.LevelComplete();
        }
    }
}
