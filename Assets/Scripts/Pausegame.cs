using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausegame : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            Time.timeScale = 0;
        }
        if (Input.GetKey(KeyCode.R))
        {
            Time.timeScale = 1;
        }
    }
}
