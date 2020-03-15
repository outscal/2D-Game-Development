using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Player controller awake.");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision: " + collision.gameObject.name);
    }
}
