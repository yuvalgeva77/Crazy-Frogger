
using UnityEngine;
using Random = UnityEngine.Random;

public class Car : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed=1f ;
    public float minSpeed = 2f;
    public float maxSspeed = 5f;

    void Start()
    {
        speed = Random.Range(minSpeed, maxSspeed);
        //speed = 100f;
    }

    void FixedUpdate()
    {
        Vector2 forward = new Vector2(transform.right.x, transform.right.y);
        rb.MovePosition(rb.position + forward * Time.fixedDeltaTime * speed);
    }
    void OnTriggerEnter2D(Collider2D col)

    {
        if (col.tag == "wall")
        {
            Destroy(this.gameObject);

        }

    }

}
