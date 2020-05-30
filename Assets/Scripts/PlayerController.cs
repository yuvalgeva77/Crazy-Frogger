using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
   public float speed;   //Floating point variable to store the player's movement speed.
    public Text countText;
    public Text lifeText;
    public Text winText;
    public Text loseText;
    private Rigidbody2D rb2d;
    private int count;
    private int life;
    public GameObject[] pickups;
  //  public GameObject stoneParticles;

    //Store a reference to the Rigidbody2D component required to use 2D Physics.
    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        life = 3;
        winText.text = "";
        loseText.text = "";
        SetCountText();
        SetLifeText();
    }
    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        if (life > 0)
        {
            //Store the current horizontal input in the float moveHorizontal.
            float moveHorizontal = Input.GetAxis("Horizontal");
            //Store the current vertical input in the float moveVertical.
            float moveVertical = Input.GetAxis("Vertical");
            //Use the two store floats to create a new Vector2 variable movement.
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
            rb2d.AddForce(movement * speed);
        }
        else{
            pickups = GameObject.FindGameObjectsWithTag("PickUp");
            foreach (GameObject pickup in pickups)
            {
                pickup.gameObject.SetActive(false);
            }
                countText.text = "";
                lifeText.text = "";
            }
        }

    //OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
    void OnTriggerEnter2D(Collider2D other)
    {
     
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Stone"))
        {
          //  Instantiate(stoneParticles, transform.position, Quaternion.identity);
            life = life - 1;
            SetLifeText();
        }
    }   

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 6)
        {
            winText.text = "You Win!!";
        }
    }
    void SetLifeText()
    {
        lifeText.text = "lives: " + life.ToString();
        if (life == 0)
        {
            loseText.text = "You lose!!";
        }
    }
}

