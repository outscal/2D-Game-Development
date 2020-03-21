using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public GameObject keyEffect;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            //collision.gameObject.GetComponent<PlayerMovement>().IncreaseKeyCount();
            LevelController.instance.IncreseLevelKeyCount();
            keyEffect.SetActive(true);
            StartCoroutine(Destroy());
        }
    }

   

  

    IEnumerator Destroy()
    {
        
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);

    }


}
