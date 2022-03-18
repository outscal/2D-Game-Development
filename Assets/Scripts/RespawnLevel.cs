using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Implemented respawn.
/// </summary>
public class RespawnLevel : MonoBehaviour
{
    public static RespawnLevel instance;
    public Transform respawnPoint;
    public GameObject playerPrefab;

    private void Awake() {
        instance = this;
    }

    public void Respawn() {
        Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
        SceneManager.LoadScene(1);
    }
}
