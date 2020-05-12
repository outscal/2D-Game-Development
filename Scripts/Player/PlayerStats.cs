using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int playerHeartCount = 3;
    public int currentHeartcount;


    public bool isDead;


    public static PlayerStats instance;
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }
    private void Start()
    {
        currentHeartcount = playerHeartCount;
    }
    private void Update()
    {
        if (currentHeartcount <= 0 && !isDead)
            PlayerDeath();
    }

    public void DamagePlayer()

    {
        PlayerController.instance.HurtAnim();
        UIManager.instance.UpdateHealthUI();
    }

    public void PlayerDeath()
    {
        //Anims and Vars
        PlayerController.instance.DeadAnim();
        isDead = true;
        UIManager.instance.DeathUI();
    }



}
