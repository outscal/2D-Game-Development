using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {   if (GameData.HEALTHCOUNT < GameData.maxHealthCount)
            {
            GameData.HEALTHCOUNT += GameData.healthValue;
            }
            Destroy(gameObject);
        }
    }
}
