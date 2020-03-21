using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public bool isUnlocked;
    public PlayerMovement player;
    //public GameObject lockImage;
    public Key[] keys;
    private int collectedKeys = 0;
    public Text leveCountText;
    public Text keyCountText;

    void Start()
    {
        collectedKeys = 0;
    }

    public bool checkUnlock()
    {
        if (collectedKeys == keys.Length)
        {
            return true;
        }
        else
        {
            return false;
        }
        //return player.checkKeysCollected();
       
    }

    public void UpdateCurrentLevel()
    {
        leveCountText.text = "Level: " + SceneManager.GetActiveScene().buildIndex;
    }

    public void UpdateCurrentKeys()
    {
        keyCountText.text = "" + collectedKeys + "/" + keys.Length;
    }

    public void IncreaseKeyCount()
    {
        if (collectedKeys > keys.Length)
        {
            collectedKeys = 0;
            collectedKeys++;
            keyCountText.text = ""+ collectedKeys + "/" + keys.Length;
        }
        else
        {
            collectedKeys++;
            keyCountText.text = "" + collectedKeys + "/" + keys.Length;
            Debug.Log("keys= " + collectedKeys);
        }
    }


    public void ResetKeys()
    {
        //player.resetCollectedKeys();
        collectedKeys = 0;
    }

    public void unlockLevel()
    {

    }
}
