using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour {
    public Image loading;
    public Text timeText;
    public int minutesOnStart;
    public int  sectesOnStart;
    private int minutes,sec;
    int totalSeconds = 0;
    int TOTAL_SECONDS = 0;
    float fillamount;
    public AudioClip clockRing;
    public AudioSource audioSrc;
    bool timesUp = false;
    Freezer _freezer;
    float restartduration = 10f;
   public bool timergoint = false;

    void Start()
    {
        timergoint = false;
        sec = sectesOnStart;
        minutes = minutesOnStart;
        audioSrc = GetComponent<AudioSource>();
        GameObject ngr = GameObject.FindWithTag("Manager");
        if (ngr)
        {
            _freezer = ngr.GetComponent<Freezer>();
        }
        timeText.text = 0 + " : " + 0;

    }
    private void Awake()
    {
        //Instance = this;
    }
    public void beginTimer()
    {      
        //timer
        timeText.text = minutes + " : " + sec;
        if (minutes > 0)
            totalSeconds += minutes * 60;
        if (sec > 0)
            totalSeconds += sec;
        TOTAL_SECONDS = totalSeconds;
        StartCoroutine(second());
        timergoint = true;
    }
    void Update()
    { 
        //time ended
        if (sec == 0 && minutes == 0 )
        {
            timeText.text = "Time's Up!";
            if (!timesUp) {
                audioSrc.PlayOneShot(clockRing);
                _freezer.FreezeAndRestartScene(restartduration);
                StopCoroutine(second());
                timesUp = true;
            }


        }
    }
    IEnumerator second()
    {
        
            yield return new WaitForSeconds(1f);
            if (sec > 0)
                sec--;
            if (sec == 0 && minutes != 0)
            {
                sec = 60;
                minutes--;
            }
            timeText.text = minutes + " : " + sec;
            fillLoading();
            StartCoroutine(second());
        
    }

    void fillLoading()
    {
        totalSeconds--;
        float fill = (float)totalSeconds / TOTAL_SECONDS;
        loading.fillAmount = fill;
    }
}

