using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public GameObject keyEffect;
    public AudioClip keyCollectClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            //collision.gameObject.GetComponent<PlayerMovement>().IncreaseKeyCount();
            LevelController.instance.IncreseLevelKeyCount();
            keyEffect.SetActive(true);
            SoundManager.instance.playEffect(keyCollectClip);
            Destroy(gameObject,0.3f);
            //StartCoroutine(Destroy());
        }
    }

   

  

    IEnumerator Destroy()
    {
        
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);

    }


}
