﻿
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Frog : MonoBehaviour
{
    public Rigidbody2D rb;
    public Sprite splash, underwater, frog;
    public AudioClip splatSound, drownSound, trombone;
    public AudioSource audioSrc;
    Freezer _freezer;
    public float duration = 1f;
    public int life=3;
   // public Text lifeText;
    public Vector2 startPos;
    private bool drownbool = false, hitbool = false, _isfreeze=false;
    private float _attackTimer = 0f;
    public Health_bar healthBar;
    playermovment frogMove;
    text_announcments levelText;

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
    void Update()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = frog;
        
        changeImage();


    }
    void OnTriggerEnter2D(Collider2D col) 

    {
        if (col.tag == "car")
        {
            hit();
        }
        if (col.tag == "water")
        {
            drown();
        }
        if (col.tag == "level")
        {
            string levelT=frogMove.levelPoint(col.name);
            levelText.writeText(levelT, 2);
            _freezer.Freeze();

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
            _freezer.Freeze();
            _freezer.freezebackMusic();
            audioSrc.PlayOneShot(trombone);
            Debug.Log("You loose!");
            Destroy(this);
        }
    }
}
