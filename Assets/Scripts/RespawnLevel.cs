using UnityEngine;
using UnityEngine.SceneManagement;
using Assests.Scripts.Level;

/// <summary>
/// Implemented respawn.
/// </summary>
public class RespawnLevel : MonoBehaviour
{
    LevelManager levelManager;
    public static RespawnLevel instance;
    public Transform respawnPoint;
    public GameObject playerPrefab;

    private void Awake() {
        instance = this;
    }

    public void Respawn() {
        Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
