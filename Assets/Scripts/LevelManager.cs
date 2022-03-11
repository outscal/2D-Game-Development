using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Implemented respawn.
/// </summary>
public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public string LevelOne;
    public Transform respawnPoint;
    public GameObject playerPrefab;

    private void Awake() {
        instance = this;
    }

    public void Respawn() {
        Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
        SceneManager.LoadScene(LevelOne);
    }
}
