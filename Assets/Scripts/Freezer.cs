using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Freezer : MonoBehaviour
{
   // public float duration = 1f;
    bool _isFrozen = false;
    float _pendingFreezeDuration = 0f;
    private float duration=1f;
    bool nextScene = false;
    bool endScene = false;
    AudioSource backMusic ;



    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("backMusic");

        if (objs.Length == 1)
        {
            backMusic = objs[0].GetComponent<AudioSource>();
        }
        
        
        //SoundManager.Instance.gameObject.GetComponent<AudioSource>();
    }
    public void Reset(float durationInput)
    {
        duration = durationInput;
    }

    // Update is called once per frame
    void Update()
    {
        if(_pendingFreezeDuration> 0 && !_isFrozen)
        {
            StartCoroutine(DoFreeze());
        }
    }
    
    public void Freeze()
    {
        _pendingFreezeDuration = duration;
    }
    public void FreezeAndNextScene()
    {
        _pendingFreezeDuration = duration;
        nextScene = true;
    }
    public void FreezeAndEnd()
    {
        _pendingFreezeDuration = duration;
        endScene = true;
    }
    IEnumerator DoFreeze()
    {
        
        backMusic.Pause();
        _isFrozen = true;
        var orginal = Time.timeScale;
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = orginal;
        _pendingFreezeDuration = 0;
        _isFrozen = false;
        if(nextScene==false&& endScene==false)
        backMusic.UnPause();
        if (nextScene == true)
            nextScenefunc();
        if (endScene == true)       
            endGame();

    }
    void nextScenefunc()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        nextScene = false;
        backMusic.UnPause();
    }

    void endGame()
    {
        GameObject[] frogs = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject frog in frogs)
        {
            Destroy(frog);
        }
        endScene = false;
    }
    public void freezebackMusic()
    {
        backMusic.Stop();
    }
}
