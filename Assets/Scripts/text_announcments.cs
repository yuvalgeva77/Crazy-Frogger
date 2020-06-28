using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text_announcments : MonoBehaviour
{
    Text Ttext;
    public int countdoenTimer;

    // Use this for initialization
    void Awake()
    {
        Ttext =  this.GetComponentInChildren<Text>();

        //Typeof
        //Text ButtonText = button.GetComponentInChildren(typeof(Text)) as Text;
    }
    void Start()
    {
        Ttext.text = "";

    }

    public void writeText(string text, int second)
    {
        Ttext.text = text;
        countdoenTimer = second;
        //Ttext.gameObject.SetActive(true);
        StartCoroutine(TextCountdown());
    }

    IEnumerator TextCountdown()
    {
        while (countdoenTimer > 0)
        {
            yield return new WaitForSeconds(1f);
            countdoenTimer--;
        }
        //Ttext.gameObject.SetActive(false);
        Ttext.text = "";


    }
}