using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animalMovment : MonoBehaviour
{ 
    // Array of waypoints to walk from one to the next one
    [SerializeField]
    public Transform[] waypoints;

// Walk speed that can be set in Inspector
[SerializeField]
public float moveSpeed = 2f;

// Index of current waypoint from which Enemy walks
// to the next one
private int waypointIndex = 0;
//
public bool loop = true;
public bool sideToside = false;


// Use this for initialization
private void Start()
{

    // Set position of Enemy as position of the first waypoint
    transform.position = waypoints[waypointIndex].transform.position;
    Quaternion toAngle = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 0, 0f));
    if (loop)
    {
        toAngle = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 0, -90f));
    }
    else if (sideToside)
    {
        // toAngle = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 0, -180f));
    }

    Quaternion fromAngle = transform.rotation;
    transform.rotation = Quaternion.Lerp(fromAngle, toAngle, 1f);
}

// Update is called once per frame
private void Update()
{

    // Move Enemy
    Move();
}
private void rotate()
{
    // Quaternion toAngle = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 0, 0f));
    //    if (loop)
    //{
    //     toAngle = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 0, 90f));
    //}
    //else if (sideToside)
    //{
    //     toAngle = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 0, 180f));
    //}      
    //Quaternion fromAngle = transform.rotation;
    //transform.rotation = Quaternion.Lerp(fromAngle, toAngle, 1f);
    updateAngle();
}
private void updateAngle()
    {
        Quaternion oldRotation = transform.rotation;

        Vector3 direction = waypoints[waypointIndex].position - transform.position;
    //calculate angle usind inverst tan
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
    //define rotation on specific axes
    Quaternion angleAxis = Quaternion.AngleAxis(angle, Vector3.forward);
    transform.rotation = Quaternion.Slerp(transform.rotation, angleAxis, 1f);

        if (angle==- 90 )
        {

            transform.RotateAround(transform.position, transform.up, 180f);

        }
        if (angle == 90)
        {

            //transform.RotateAround(transform.position, transform.up, -180f);

        }
    }
    // Method that actually make Enemy walk
    private void Move()
{
    // If Enemy didn't reach last waypoint it can move
    // If enemy reached last waypoint then it starts over
    if (waypointIndex > waypoints.Length - 1)
        waypointIndex = 0;
    {

        // Move Enemy from current waypoint to the next one
        // using MoveTowards method
        transform.position = Vector2.MoveTowards(transform.position,
           waypoints[waypointIndex].transform.position,
           moveSpeed * Time.deltaTime);

        // If Enemy reaches position of waypoint he walked towards
        // then waypointIndex is increased by 1
        // and Enemy starts to walk to the next waypoint
        if (transform.position == waypoints[waypointIndex].transform.position)
        {
            if (waypointIndex == waypoints.Length - 1)
                waypointIndex = 0;
            else waypointIndex += 1;
            updateAngle();


        }
    }

}
}

