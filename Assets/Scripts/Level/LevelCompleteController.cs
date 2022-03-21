using UnityEngine;
using UnityEngine.SceneManagement;
using Assests.Scripts.Level;

public class LevelCompleteController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        
        if(collision.gameObject.CompareTag("Player")) 
        {
            //Game is over
            int currentIndex = SceneManager.GetActiveScene().buildIndex;
            Debug.Log("Level finished by the player");
            LevelManager.Instance.MarkCurrentLevelComplete();
            SceneManager.LoadScene(currentIndex + 1);
        }
    }
}
