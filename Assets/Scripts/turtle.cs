using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtle : MonoBehaviour
{
    public Sprite turtleUp, turtleDown;
    public bool down = false;
    public int timeUp = 4, timeDown = 3, countdownTimer;
    // Use this for initialization
    void Awake()
    {
     

        //Typeof
        //Text ButtonText = button.GetComponentInChildren(typeof(Text)) as Text;
    }
    void Start()
    {
        activate();
     }
    private void Update()
    {
       

    }
        private void activate()
        {
            StartCoroutine(imageCountdown());

        }

        IEnumerator imageCountdown()
        {
            while (true)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = turtleUp;
                down = false;
                countdownTimer = timeUp;
            while (countdownTimer > 0)
                {
                    yield return new WaitForSeconds(1f);
                    countdownTimer--;
                }
                this.gameObject.GetComponent<SpriteRenderer>().sprite = turtleDown;
                countdownTimer = timeDown;
                down = true;


            while (countdownTimer > 0)
                {
                    yield return new WaitForSeconds(1f);
                    countdownTimer--;
                }


            }
        }

}

