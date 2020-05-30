
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public AudioClip levelUp,winSound;
    public AudioSource audioSrc;
    private bool hitbool = false, _isfreeze = false;
    Freezer _freezer;
    public float duration = 1f;
    // Start is called before the first frame update
    void Awake()
    {

        audioSrc = GetComponent<AudioSource>();

    }
    void Start()
    {
        GameObject ngr = GameObject.FindWithTag("Manager");
        if (ngr)
        {
            _freezer = ngr.GetComponent<Freezer>();
            _freezer.Reset(duration);


        }

    }

    // Update is called once per frame
    void Update() { }
    
    void OnTriggerEnter2D(Collider2D col) { 

    
        Scene cs = SceneManager.GetActiveScene();
        if (cs.name != "FroggerLevel3")
        {
            audioSrc.PlayOneShot(levelUp);
            Debug.Log("Level up!");
            _freezer.FreezeAndNextScene();



        }
        else
        {
            audioSrc.PlayOneShot(winSound);
            Debug.Log("You win!");
            _freezer.FreezeAndEnd();
        }

    }
  
    //void freeze()
    //{
    //    if (hitbool == true)
    //    {
    //        _isfreeze = true;

    //    }
    // while attacking, count up the timer.
    //if (_isfreeze)
    //{
    //    _attackTimer += Time.deltaTime;

    //    // once the timer is 2 seconds, stop attacking and reset the sprite.
    //    if (_attackTimer >= duration)
    //    {
    //        _isfreeze = false;
    //        hitbool = false;
    //        _attackTimer = 0;
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    //        //   hitbool = false;

    //    }
    //}
    //}
}
