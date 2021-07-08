using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scenetransition : MonoBehaviour
{

    public GameObject plane;
    public Button transitionButton;

    private Animator transitionAnim;

    public string newScene;

    private void Start()
    {
        transitionAnim = plane.GetComponent<Animator>();
        plane.SetActive(false);
        transitionButton.onClick.AddListener(OnButtonClick);
 
    }

    


    private void OnButtonClick()
    {
        
        SceneManager.LoadScene(newScene);
    }

   
}
