using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class coinCounter : MonoBehaviour
{
    Text Ttext;
    static int coins=0;
    public AudioClip coinSound;
    public AudioSource audioSrc;


    private void Awake()
    {
        Ttext = this.GetComponentInChildren<Text>();
        audioSrc = GetComponent<AudioSource>();


    }
    void Start()
    {
        Ttext.text = "0";
        coins = 0;

    }
    
    public void add()
    {
        coins++;
        Ttext.text = coins.ToString();
        Debug.Log("got a coin. total coins:" + coins.ToString());
        audioSrc.PlayOneShot(coinSound);


    }
    public int get()
    {
        return coins;
    }


}
