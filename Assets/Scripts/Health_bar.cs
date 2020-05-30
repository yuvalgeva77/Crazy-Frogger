using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_bar : MonoBehaviour
{
    public static int  health; // player life +1
    public Slider slider;
    public void SetMaxHealth(int life)
    {
        health = life + 1;
        slider.maxValue = health;
        slider.value = health;
    }
    public void MinusHealth()
    {
        health--;
        slider.value = health;
    }
    public void SetHealth(int life)
    {
        health = life + 1;
        slider.value = health;
    }
    public int GetLife()
    {
        return (health - 1);
    }
}
