using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    // Start is called before the first frame update
    public UIManager.Collectables collectableType;
    public enum collectableEnum
    {
        waterDrops, health, craftingItems,

    }
    public collectableEnum thisCollectable;
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (thisCollectable == collectableEnum.waterDrops)
            {
                //collectableType.waterDrops++;
                UIManager.instance.UpdateCollectableUI();
                Destroy(this.gameObject);
            }
        }
    }
}
