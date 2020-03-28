using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour {

    public GameObject coinEffect;
    public AudioClip coinCollectClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            coinEffect.SetActive(true);
            SoundManager.instance.playCollectibleSound(Sfx.CollectibleSfx.Coin, false);
            GameData.SCORE++;
            LevelController.instance.UpdateScore();
            Destroy(gameObject,0.3f);
        }
    }

   
}