using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{

    public Slider slider;
    
    public void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void setHealth(int health)
    {
        slider.value = health;
    }
}
