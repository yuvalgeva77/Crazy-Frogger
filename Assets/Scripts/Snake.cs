
using UnityEngine;
using Random = UnityEngine.Random;

public class Snake : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 1f;
    public float minSpeed = 2f;
    public float maxSspeed = 5f;

    void Start()
    {
      //  speed = Random.Range(minSpeed, maxSspeed);
        speed = 1f;
    }

    void FixedUpdate()
    {
        int randomIndex = Random.Range(0,4);
        ////Vector2 vright = new Vector2(transform.right.x, transform.right.y);
        ////Vector2 vleft = new Vector2(transform.right.x*-1, transform.right.y);
        ////Vector2 vup = new Vector2(transform.up.x, transform.up.y);
        ////Vector2 vdown = new Vector2(transform.up.x, transform.up.y * -1);
        ////Vector2[] directions = new Vector2[ 4 ];
        ////directions[0] = vright;
        ////directions[1] = vleft;
        ////directions[2] = vup;
        ////directions[3] = vdown;
      
      //  Vector2 vright = new Vector2(transform.right.x, transform.right.y);
       // Vector2 vup = new Vector2(transform.up.x, transform.up.y);
      // Vector2 vleft = new Vector2 (-1,0);
        //Vector2 vup = new Vector2(0, 1);
        //Vector2 vdown = new Vector2(-1*transform.up.x, transform.up.y);
        Vector2[] directions = new Vector2[4];
        directions[0] = Vector2.left;
        directions[1] = Vector2.down;
        directions[3] = Vector2.up;
        directions[2] = Vector2.right;
        rb.MovePosition(rb.position + directions[randomIndex ]* Time.fixedDeltaTime * speed);
       

    }
    void OnTriggerEnter2D(Collider2D col)

    {
        if (col.tag == "wall")
        {
            Destroy(this.gameObject);

        }

    }

}
