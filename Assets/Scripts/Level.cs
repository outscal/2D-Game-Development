using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public bool isUnlocked;
    //public GameObject lockImage;

    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Scene1")
        {
            isUnlocked = true;
            Debug.Log("scene loaded");
        }
        else
        {
            isUnlocked = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
