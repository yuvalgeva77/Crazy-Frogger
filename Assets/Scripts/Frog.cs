﻿
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Frog : MonoBehaviour
{
    public Rigidbody2D rb;
    public Sprite splash, underwater, frog;
    public AudioClip splatSound, drownSound, trombone,jump;
    public AudioSource audioSrc;
    Freezer _freezer;
    public float duration = 1f;
    public int life=3;
   // public Text lifeText;
    public Vector2 startPos;
    private bool drownbool = false, hitbool = false, _isfreeze=false;
    private float _attackTimer = 0f;
    public Health_bar healthBar;

    // Update is called once per frame
    void Awake()
    {

       audioSrc = GetComponent<AudioSource>();
      //  healthBar = GetComponent<Health_bar>();
    }
     void Start()
    {
        //this.gameObject.GetComponent<SpriteRenderer>().sprite = frog;
        life = 3;
        
        healthBar.SetMaxHealth(life);
        startPos = rb.position;
        GameObject ngr = GameObject.FindWithTag("Manager");
        if (ngr)
        {
            _freezer = ngr.GetComponent<Freezer>();
            _freezer.Reset(duration);
           
            
        }
       
    }
    void Update()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = frog;
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            audioSrc.PlayOneShot(jump);
            rb.MovePosition(rb.position + Vector2.right);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            audioSrc.PlayOneShot(jump);
            rb.MovePosition(rb.position + Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            audioSrc.PlayOneShot(jump);
            rb.MovePosition(rb.position + Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            audioSrc.PlayOneShot(jump);
            rb.MovePosition(rb.position + Vector2.down);
        }
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
                rb.MovePosition(startPos);
                this.gameObject.GetComponent<SpriteRenderer>().sprite = frog;
            }
        }
    }
    void checkDead()
    {
        if (life == 0)
        {
            audioSrc.PlayOneShot(splatSound);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = splash;
            _freezer.Freeze();
            _freezer.freezebackMusic();
            audioSrc.PlayOneShot(trombone);
            Debug.Log("You loose!");
            Destroy(this);
        }
    }
}
