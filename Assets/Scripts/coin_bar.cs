using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coin_bar : MonoBehaviour
{
    public static int  coins; // 
    public Slider slider;
    public void SetMaxCoins(int num)
    {
        coins = 0;
        slider.maxValue = num;
        slider.value = 0;
    }
    public void add()
    {
        coins++;
        slider.value = coins;
    }
    public int get()
    {
        return coins;
    }


}
