using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  public class SoundManager : MonoBehaviour{

    private static SoundManager instance = null;
  
    public static SoundManager Instance {
        get { return instance; }
    }

    void Awake()
    {
       if(instance!=null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = null;
        }
        DontDestroyOnLoad(this.gameObject);

     }
    //Play Global End


}
