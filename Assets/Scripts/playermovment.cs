using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovment : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 startPos;
    public AudioClip  jump;
    public AudioSource audioSrc;
    KeyCode[] directions;
    int countlevel2, countlevel2H;
    // Start is called before the first frame update

    void Awake()
    {

        audioSrc = GetComponent<AudioSource>();
        startPos = rb.position;

    }
    void Start()
    {
        directions = new KeyCode[] { KeyCode.RightArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.DownArrow };
        countlevel2 = 0;
        countlevel2H = 0;
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("playermovment Update");

        KeyCode right = directions[0];
        KeyCode left = directions[1];
        KeyCode up = directions[2];
        KeyCode down = directions[3];
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            easyrotateControls();
        }
        //move:
        if (Input.GetKeyDown(right))
        {
            audioSrc.PlayOneShot(jump);
            rb.MovePosition(rb.position + Vector2.right);
        }
        else if (Input.GetKeyDown(left))
        {
            audioSrc.PlayOneShot(jump);
            rb.MovePosition(rb.position + Vector2.left);
        }
        else if (Input.GetKeyDown(up))
        {
            audioSrc.PlayOneShot(jump);
            rb.MovePosition(rb.position + Vector2.up);
        }
        else if (Input.GetKeyDown(down))
        {
            audioSrc.PlayOneShot(jump);
            rb.MovePosition(rb.position + Vector2.down);
        }
    }
    void easyrotateControls()
    {
        KeyCode dTemp = directions[1];
        directions[1] = directions[0];
        directions[0] = dTemp;
        dTemp = directions[3];
        directions[3] = directions[2];
        directions[2] = dTemp;
    }
    void hardrotateControls()
    {   directions= new KeyCode[] { KeyCode.UpArrow,  KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow};
        //KeyCode dTemp = directions[3];
        //for (int i = 2; i >= 0; i--)
        //{
        //    directions[i + 1] = directions[i];

        //}
        //directions[0] = dTemp;
    }
    public void hit()
    {
        rb.MovePosition(startPos);
    }
    public string levelPoint(string name)
    {

        if (name == "level2"&& countlevel2==0)
        {
            startPos = rb.position;//tofo check if works
            countlevel2++;
            easyrotateControls();
            Debug.Log("easy controls rotate");
            return  "Keys rotation!!";

        }
        if (name == "level2.5" && countlevel2H == 0)
        {
            startPos = rb.position;//tofo check if works
            countlevel2H++;
            hardrotateControls();
            Debug.Log("hard controls rotate");
            return  "CRAZY KEYS ROTATION!!";
        }
        else return "";
    }
}

