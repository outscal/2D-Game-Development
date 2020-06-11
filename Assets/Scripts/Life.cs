using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public GameObject coinEffect;
    public AudioClip lifeCollectClip;
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {   if (GameData.HEALTHCOUNT < GameData.maxHealthCount)
            {
                HealthManager.instance.IncreaseHealth(GameData.healthValue);
            }
            coinEffect.SetActive(true);
            SoundManager.instance.playCollectibleSound(Sfx.CollectibleSfx.Life, false);
            Destroy(gameObject,0.3f);
        }
    }
}
