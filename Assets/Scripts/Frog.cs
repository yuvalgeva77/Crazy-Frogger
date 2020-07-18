
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Frog : MonoBehaviour
{
    public Rigidbody2D rb;
    public Sprite splash, underwater, frog, frogleg;
    public AudioClip splatSound, drownSound, trombone, eagleSound;
    public AudioSource audioSrc;
    Freezer _freezer;
    public float duration = 1f;
    public int life=3;
   // public Text lifeText;
    public Vector2 startPos;
    private bool drownbool = false, hitbool = false, eatenbool=false, _isfreeze=false;
    private float _attackTimer = 0f;
    public Health_bar healthBar;
    public coinCounter coin_counter;

    playermovment frogMove;
    text_announcments levelText;
    Rigidbody m_Rigidbody;
    bool isDead = false;


    // Update is called once per frame
    void Awake()
    {

       audioSrc = GetComponent<AudioSource>();
        //  healthBar = GetComponent<Health_bar>();
    
    }
     void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = frog;
        life = 3;
        coin_counter = this.gameObject.GetComponentInChildren<coinCounter>();

        healthBar.SetMaxHealth(life);
        GameObject ngr = GameObject.FindWithTag("Manager");
        if (ngr)
        {
            _freezer = ngr.GetComponent<Freezer>();
            _freezer.Reset(duration);
           
            
        }
        frogMove = this.gameObject.GetComponent<playermovment>();
        levelText = GameObject.Find("game levels").GetComponent<text_announcments>();


    }
    //void Update()
    //{
    //    this.gameObject.GetComponent<SpriteRenderer>().sprite = frog;
        
    //    changeImage();

    //}
    private void LateUpdate()
    {
        Debug.Log("LateUpdate");
        this.gameObject.GetComponent<SpriteRenderer>().sprite = frog;

        changeImage();
        this.gameObject.GetComponent<Rigidbody2D>().WakeUp();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "car"&&!isDead)
        {
            isDead = true;
            hit();
        }
        if (col.tag == "water" && !isDead)
        {
            isDead = true;
            drown();
        }
        if (col.tag == "bird" && !isDead)
        {
            isDead = true;
            eaten();
        }
        if (col.tag == "level")
        {
            string levelT=frogMove.levelPoint(col.name);
            levelText.writeText(levelT, 2);
            _freezer.Freeze();

        }
        if (col.tag == "turtle" && !isDead)
        {
            GameObject other = col.gameObject;
            if (other.GetComponent<turtle>().isDown() == true)
            {
                isDead = true;
                Debug.Log("Youve drowned OnTriggerEnter2D");
                drown();
            }

        }
        if (col.tag == "coin")
        {
            Destroy(col.gameObject);
            coin_counter.add();
        }
        if (col.tag == "camel" && !isDead)
        {
            isDead = true;
            hit();
        }
        

    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "turtle" && !isDead)
        {

            if (col.gameObject.GetComponent<turtle>().isDown() == true)
            {
                Debug.Log("Youve drowned OnTriggerStay2D");
                isDead = true;
                drown();
            }
        }
    }


    void SetLifeText()
    {
        // lifeText.text = "lives: " + life.ToString();
        healthBar.MinusHealth();
    }
    void hit()
    {  
       // hitbool = true;
        life = life - 1;
        SetLifeText();
        hitbool = true;
        if (life > 0)
        {
            audioSrc.PlayOneShot(splatSound);
            Debug.Log("Youve been hit!");
            _freezer.Freeze();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            // this.gameObject.GetComponent<SpriteRenderer>().sprite = frog;
            //hitbool = false;
        }
        checkDead();
      
    }
    void drown()
    {
        life = life - 1;
        Debug.Log(life);
        SetLifeText();
        drownbool = true;
        if (life > 0)
        {
            audioSrc.PlayOneShot(drownSound);
            Debug.Log("Youve drowned!");
            _freezer.Freeze();
        }
        checkDead();
    }
    void eaten()
    {
        life = life - 1;
        Debug.Log(life);
        SetLifeText();
        eatenbool = true;
        if (life > 0)
        {
            audioSrc.PlayOneShot(eagleSound);
            Debug.Log("Youve been eaten!");
            _freezer.Freeze();
        }
        checkDead();
    }
   
    void changeImage()
    {
        if (hitbool == true)
        {
            _isfreeze = true;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = splash;
        }
        if (drownbool == true)
        {
            _isfreeze = true;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = underwater;
        }
        if (eatenbool == true)
        {
            _isfreeze = true;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = frogleg;
        }
        // while attacking, count up the timer.
        if (_isfreeze)
        {
            _attackTimer += Time.deltaTime;

            // once the timer is 2 seconds, stop attacking and reset the sprite.
            if (_attackTimer >= duration)
            {
                _isfreeze = false;
                hitbool = false;
                drownbool = false;
                _attackTimer = 0;
                frogMove.hit();
                isDead = false;
                eatenbool = false;
                //rb.MovePosition(startPos);
                this.gameObject.GetComponent<SpriteRenderer>().sprite = frog;
            }
        }
    }
    void dieSound()
    {
        if (hitbool == true)
        {
            audioSrc.PlayOneShot(splatSound);
        }
        if (drownbool == true)
        {
            audioSrc.PlayOneShot(drownSound);
        }
    }
    void checkDead()
    {
        if (life == 0)
        {
            dieSound();
            changeImage();
            //audioSrc.PlayOneShot(splatSound);
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = splash;
            //_freezer.Freeze();
            frogMove.enabled = false;
            //_freezer.freezebackMusic();
            audioSrc.PlayOneShot(trombone);
            Debug.Log("You loose!");

            timer gameTimer = this.gameObject.GetComponentInChildren<timer>();
            //gameTimer.waitForSong(trombone);
            Debug.Log("trombone.lengt: "+ trombone.length);

            gameTimer.restart(trombone.length);
        }
    }
}
