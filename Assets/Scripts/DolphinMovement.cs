using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DolphinMovement : MonoBehaviour
{
    // public float speed;
    private Transform playerPos;
    private Vector2 target;
    private Rigidbody2D rb;

    [Tooltip("The max angle that the dolphin launches at. Must be <= 90. If less than the minimum angle, the minimum angle is used.")]
    public float maxAngle;

    public float maxVelocity = 110;

    private Vector2 startPos; // Used for testing

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerPos = player.transform;

        // When the dolphin is spawned, it aims for the location the player was initially
        target = playerPos.position;
        
        rb = GetComponent<Rigidbody2D>();

        startPos = transform.position; // Used for testing


        // NEW TEST CODE

        Vector3 p = target;
 
        float gravity = rb.gravityScale * Physics.gravity.magnitude;        

        // Determine the angle it will move towards the player at
        float randomAngle = calculateRandomAngle();

        // float randomAngle = 60;
        
        Debug.Log("Final Angle: " + randomAngle);

        // Selected angle in radians
        float angle = randomAngle * Mathf.Deg2Rad;

        // Positions of this object and the target on the same plane
        Vector3 planarTarget = new Vector3(p.x, 0, 0);
        Vector3 planarPostion = new Vector3(transform.position.x, 0, transform.position.z);
 
        // Planar distance between objects
        float distance = Vector3.Distance(planarTarget, planarPostion);
        // Distance along the y axis between objects
        float yOffset = transform.position.y - p.y;
 
        float initialVelocity = (1 / Mathf.Cos(angle)) * Mathf.Sqrt((0.5f * gravity * Mathf.Pow(distance, 2)) / (distance * Mathf.Tan(angle) + yOffset));
 
        Vector3 velocity = new Vector3(0, initialVelocity * Mathf.Sin(angle), initialVelocity * Mathf.Cos(angle));

        // Rotate our velocity to match the direction between the two objects
        float angleBetweenObjects = Vector3.Angle(Vector3.forward, planarTarget - planarPostion);
        
        // If the dolphin is on the right side of the player, invert the angle
        if(transform.position.x > target.x)
        {
            angleBetweenObjects *= -1;
        }

        Vector3 finalVelocity = Quaternion.AngleAxis(angleBetweenObjects, Vector3.up) * velocity;
 
        // Fire!
        rb.velocity = Vector2.ClampMagnitude(finalVelocity, maxVelocity);
    }

    // private float calculateXVelocity()
    // {

    // }

    // Update is called once per frame
    void Update()
    {

        // Vector2 nextPos = Vector2.MoveTowards(transform.position, playerPos.position, Time.deltaTime*speed);
        // transform.position = nextPos;
        // Vector2 moveDir = nextPos - (Vector2)transform.position;
        // transform.rotation = Quaternion.LookRotation(Vector3.forward, moveDir);
        // transform.LookAt(playerPos, Vector3.right);
        
    }

    // Returns a valid random angle that the dolphin can launch at
    private float calculateRandomAngle()
    {
        // The amount to increase the minimum angle by. Set this to at least 5.
        float minAngleIncrement = 5;

        // The minimum angle is the angle between the dolphin's y axis and the
        // straight line between the dolphin and player
        float minAngle = Vector2.Angle(transform.right, target - (Vector2)transform.position) + minAngleIncrement;

        // The max angle should be no higher than 90 degrees
        maxAngle = 80;

        // If the dolphin is on the right side of the player, adjust the angle to be within 90
        if(transform.position.x > target.x)
            minAngle = 90 - (minAngle - 90);

        // If the minimum angle is less than 50 degrees, add 5 to it
        if(minAngle < 50)
        {
            minAngle += 5;
        }
        else if(minAngle > 90)
        {
            minAngle = 90;
        }         

        Debug.Log("Minimum Angle: " + minAngle);

        // If the minimum angle is larger than the max angle, return the min angle
        if(minAngle > maxAngle)
            return minAngle;             

        return Random.Range(minAngle, maxAngle);
        // return minAngle;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Player hit!"); // Used for testing
        }
        else if(other.tag == "SeaBorder")
        {
            transform.position = startPos; // Used for testing
            Start();
        }
    }
}
