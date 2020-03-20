using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            GameData.HEALTHCOUNT += GameData.healthValue;
            Debug.Log("Health= " + GameData.HEALTHCOUNT);
            Destroy(gameObject);
        }
    }
}
