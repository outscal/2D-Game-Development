using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public UIManager.Collectables collectableType;
    public enum collectableEnum
    {
        waterDrops, health, craftingItems,

    }
    public collectableEnum thisCollectable;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (thisCollectable == collectableEnum.waterDrops)
            {
                //collectableType.waterDrops++;
                //^------ why this not works and incr. in UI manager Works??? :/
                UIManager.instance.UpdateWaterCounterUI();
                Destroy(this.gameObject);
            }
        }
    }
}
