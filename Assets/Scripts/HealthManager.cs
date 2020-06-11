using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Slider slider;
    public static HealthManager instance;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        GameData.HEALTHCOUNT = 3;
        slider.value = GameData.HEALTHCOUNT;
    }

    public void DecreaseHealth(int healthValue)
    {
        GameData.HEALTHCOUNT-= healthValue;
        slider.value = GameData.HEALTHCOUNT;
    }

    public void IncreaseHealth(int healthValue)
    {
        GameData.HEALTHCOUNT += GameData.healthValue;
        slider.value = GameData.HEALTHCOUNT;
    }
}
