using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Levelcomplete : MonoBehaviour
{

    public GameObject UI;
    private Scene scene;
    public Button resartButton;

    private void Start()
    {
        //UI display off.
        UI.SetActive(false);

        //Restart button game component set.
        resartButton = gameObject.GetComponent<Button>();

        scene = SceneManager.GetActiveScene();
        Debug.Log("Active scene is " + scene.name);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent("Movement") != null)
        {
            // UI display activated and restart button should be activated.

            UI.SetActive(true);
            Time.timeScale = 0f;
            resartButton.onClick.AddListener(restartScene);

        }
    }

    private void restartScene()
    {
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1f;
    }

}
