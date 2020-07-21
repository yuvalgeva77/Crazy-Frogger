using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playermovment : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 startPos;
    public AudioClip  jump,levelup, winSound;
    public AudioSource audioSrc;
    KeyCode[] directions;
    int countlevel2, countlevel2H, countlevel3;
    // Start is called before the first frame update
    public Transform spawnPoint1, spawnPoint2;
    public GameObject frog;
    public static int numclones=0;

    void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
        startPos = rb.position;

    }
    void Start()
    {
       normalControlls();
        countlevel2 = 0;
        countlevel2H = 0;
        countlevel3 = 0;
        
    }
    // Update is called once per frame
    void LateUpdate()
    {

        //Debug.Log("in LateUpdate,rb.position " + rb.position);
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
    void normalControlls()
    {
        directions = new KeyCode[] { KeyCode.RightArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.DownArrow };

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
    }
    public void hit()
    {

        startOverLevel();
        Debug.Log("hit " + startPos);
        if (numclones >0)

        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player"); //get all obstacles
            foreach (GameObject p in players) //access them individually  
                if (p != this) {
                    p.GetComponent<playermovment>().startOverLevel();
                } 

                        
        }


    }
    public void startOverLevel ()
    {
        rb.position = startPos;
        //rb.MovePosition(startPos);
        Debug.Log("startOverLevel move to startPos:" + startPos);
       


    }
    public void setStartPoint(Vector2 start)
    {

        startPos = start;

    }
    public string levelPoint(string name)
    {

        if (name == "level2"&& countlevel2==0)
        {
            startPos = rb.position;//tofo check if works
            countlevel2++;
            easyrotateControls();
            Debug.Log("easy controls rotate");
            audioSrc.PlayOneShot(levelup);
            return "Keys rotation!!";

        }
        if (name == "level2.5" && countlevel2H == 0)
        {
            startPos = rb.position;//tofo check if works
            countlevel2H++;
            hardrotateControls();
            Debug.Log("hard controls rotate,startPos: "+ startPos);
            return  "CRAZY KEYS ROTATION!!";
        }
        if (name == "level3" && countlevel3 == 0)
        {
            startPos = rb.position;//tofo check if works
            countlevel3++;
            normalControlls();
            Debug.Log("normal controls,startPos: " + startPos);
            audioSrc.PlayOneShot(levelup);

            //spawn
            if (numclones == 0) {
                GameObject clone =Instantiate(frog, spawnPoint1.position, spawnPoint1.rotation);
                rb.position = spawnPoint2.position;
                startPos= new Vector2(spawnPoint2.position.x, spawnPoint2.position.y);
                Debug.Log("in spawn, this startPos " + startPos);

                Vector2 start = new Vector2(spawnPoint1.position.x, spawnPoint1.position.y);
                clone.GetComponent<playermovment>().setStartPoint(start);
                Debug.Log("in spawn, spawn startPos " + start);
               
                gameObject.AddComponent< FixedJoint2D >();
                gameObject.GetComponent<FixedJoint2D>().connectedBody = clone.GetComponent<Rigidbody2D>();

                clone.gameObject.GetComponent<Frog>().healthBar = gameObject.GetComponent<Frog>().healthBar;

                foreach (Transform child in clone.transform)
                {
                    GameObject.Destroy(child.gameObject);
                }
         



                coinCounter co = gameObject.GetComponent<Frog>().coin_counter;
                clone.gameObject.GetComponent<Frog>().coin_counter = gameObject.GetComponent<Frog>().coin_counter;
                co = clone.gameObject.GetComponent<Frog>().coin_counter;
                clone.gameObject.GetComponent<playermovment>().jump = null;
                clone.gameObject.GetComponent<playermovment>().levelup = null;
                clone.gameObject.GetComponent<playermovment>().winSound = null;
                clone.gameObject.GetComponent<playermovment>().rb = clone.GetComponent<Rigidbody2D>();
                clone.gameObject.GetComponent<Frog>().gameTimer = gameObject.GetComponent<Frog>().gameTimer;
                numclones = 1;
                
            }
            Vector3 vec=new Vector3(-2, 0, 0);
            GameObject camera= GameObject.Find("Main Camera");
            camera.gameObject.GetComponent<CameraControler>().shiftOffset(vec);


            return "TWINZIES!";
        }
        if (name == "win")
        {        
            audioSrc.PlayOneShot(winSound);
            Debug.Log("Youve won!");
            //Scene scene = SceneManager.GetActiveScene();
            //SceneManager.LoadScene(scene.name);
            this.gameObject.GetComponent<playermovment>().enabled = false;
            timer gameTimer = this.gameObject.GetComponentInChildren<timer>();
            //gameTimer.waitForSong(winSound);
            Debug.Log("winSound.lengt: " + winSound.length);
            gameTimer.restart(winSound.length);
            return "YOU WIN!!";
        }

        else return "";
    }
    public void RemoteSettingsnumClones()
    {
        numclones = 0;
    }

}

