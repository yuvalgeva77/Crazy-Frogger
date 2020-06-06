using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class restartCountdown : MonoBehaviour
{
    public int countdoenTimer;
    public Text countdownDisplay;
    Freezer _freezer;
    timer StartTimer;

    // Start is called before the first frame update
    void Start()
    {
        GameObject ngr = GameObject.FindWithTag("Manager");
        if (ngr)
        {
            _freezer = ngr.GetComponent<Freezer>();
        }
        StartCoroutine(CountdownToStart());
        GameObject gameTimer = GameObject.FindWithTag("timer");
        if (gameTimer)
        {
            StartTimer = gameTimer.GetComponent<timer>();
        }
    }
  
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator CountdownToStart()
    {
        while (countdoenTimer > 0)
        {
            countdownDisplay.text = countdoenTimer.ToString();
            yield return new WaitForSeconds(1f);
            countdoenTimer--;
        }
        countdownDisplay.text = "GO!";
        //shouls restart life and clock
        StartTimer.beginTimer();
        //_freezer.FreezeAndRestartScene(3f);
        yield return new WaitForSeconds(1f);
        countdownDisplay.gameObject.SetActive(false);
    }
}
