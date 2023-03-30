using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DolphinMovement : MonoBehaviour
{
    [Tooltip("The max angle that the dolphin launches at. Must be <= 90 but is recommended to be <= 80. If less than the minimum angle, the minimum angle is used.")]
    public float maxAngle;
    private float minAngle;

    // The max velocity of the dolphin. Scales based on the gravity of the world and the dolphin's Rigidbody gravity scale.
    private float maxVelocity;

    [Tooltip("The delay before the dolphin rejumps out of the water.")]
    public float jumpDelay = 0.5f;

    private PlayerHealth playerHealth;

    private Transform playerPos;
    private Rigidbody2D rb;
    private SpriteRenderer sr;    

    private Transform[] spawnPoints;

    private bool rotatingRight;

    private bool inWater = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerPos = player.transform;
        
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();

        spawnPoints = GameObject.Find("SpawnPoints").GetComponentsInChildren<Transform>();
 
        jump();
    }

    // Makes the dolphin jump towards the player's initial position by setting its initial velocity
    private void jump()
    {
        // When the dolphin is spawned, it aims for the location the player was initially
        Vector2 target = playerPos.position;
        
        // Must multiply the worlds gravity by the amount that gravity affects the dolphin
        float gravity = rb.gravityScale * Physics.gravity.magnitude;     

        // Determine the angle it will move towards the player at and convert it to radians
        float randomAngle = calculateRandomAngle(target);
        float angle = randomAngle * Mathf.Deg2Rad;
                
        // The target and dolphin positions on the same x axis
        Vector2 targetXPosition = new Vector2(target.x, 0);
        Vector2 dolphinXPosition = new Vector2(transform.position.x, 0);
 
        // Get the distance between the two x positions
        float horizDistance = Vector2.Distance(targetXPosition, dolphinXPosition);
        
        // The distance between the dolphin and the target in terms of the y axis
        float yOffset = transform.position.y - target.y;        
        
        // Plugin the above values into this projectile motion equation to get the initial velocity's magnitude
        float initialMagnitude = (1 / Mathf.Cos(angle)) * Mathf.Sqrt((0.5f * gravity * Mathf.Pow(horizDistance, 2)) / (horizDistance * Mathf.Tan(angle) + yOffset));

        // If the initial magnitude is undefined and the angle is less than 90 degrees, increase the angle 1.570796
        while(float.IsNaN(initialMagnitude) && angle < 90 * Mathf.Deg2Rad)
        {
            angle += 0.01f;

            // If the new angle is above 90 degrees, set it to 90 degrees
            if(angle > 90 * Mathf.Deg2Rad)
            {
                angle = 90 * Mathf.Deg2Rad;

                // If the player is on top of the dolphin, ensure the x distance is not 0
                if(horizDistance < 0.001f)
                    horizDistance = 0.001f;
            }
                
            initialMagnitude = (1 / Mathf.Cos(angle)) * Mathf.Sqrt((0.5f * gravity * Mathf.Pow(horizDistance, 2)) / (horizDistance * Mathf.Tan(angle) + yOffset));
        }

        // As a background check for the initial magnitude, if still undefined, set manually
        if(float.IsNaN(initialMagnitude))
        {
            initialMagnitude = gravity + 45;
            
            // // Due to manual velocity limitations, increase angle fired at
            if(80 < randomAngle && randomAngle < 85)
            {
                angle = 87 * Mathf.Deg2Rad;
            }
             else if(75 < randomAngle && randomAngle < 80)
             {
                angle = 80 * Mathf.Deg2Rad;
             }   
        }

        // Calculate the initial velocity using the defined magnitude and angle
        Vector3 velocity = new Vector3(0, initialMagnitude * Mathf.Sin(angle), initialMagnitude * Mathf.Cos(angle));

        // Rotates the angle fired at based on the positions of the two objects
        float angleBetweenObjects = Vector3.Angle(Vector3.forward, targetXPosition - dolphinXPosition);
        
        // If the dolphin is on the right side of the player, invert the angle it jumps at. 
        // Also, fix the direction of the sprite
        if(transform.position.x > target.x)
        {
            angleBetweenObjects *= -1;
            sr.flipX = false;
            rotatingRight = false;
        }
        else
        {
            sr = GetComponent<SpriteRenderer>();
            sr.flipX = true;
            rotatingRight = true;
        }

        Vector3 finalVelocity = Quaternion.AngleAxis(angleBetweenObjects, Vector3.up) * velocity;
 
        // Set the dolphin's velocity to the calculated velocity to make it jump.
        // If the dolphin is jumping at a steep angle and the player is standing far away from the dolphin's spawn point, don't limit velocity
        if(randomAngle - minAngle > 20)
        {
            rb.velocity = finalVelocity;
        }
        else
        {
            // Set the max velocity based on the gravity factor
            maxVelocity = gravity + 55;   

            // Limit was added to prevent extreme buggy velocity speeds.
            rb.velocity = Vector2.ClampMagnitude(finalVelocity, maxVelocity);
        }
    }

    // Handles the physics rotation of the dolphin
    void FixedUpdate()
    {
        var dir = rb.velocity;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if(rotatingRight)
        {
            rb.MoveRotation(angle);
        }
        else
        {
            rb.MoveRotation((380-(angle/Mathf.Rad2Deg)) * Mathf.Rad2Deg * -1);
        }
    }

    // Returns a valid random angle that the dolphin can launch at
    private float calculateRandomAngle(Vector2 target)
    {
        // The amount to increase the minimum angle by. Set this to at least 5.
        float minAngleIncrement = 5;

        // The minimum angle is the angle between the dolphin's y axis and the
        // straight line between the dolphin and player
        minAngle = Vector2.Angle(transform.right, target - (Vector2)transform.position) + minAngleIncrement;

        // If the dolphin is on the right side of the player, adjust the angle to be within 90
        if(transform.position.x > target.x)
            minAngle = 180 - minAngle;

        // If the minimum angle is less than 50 degrees, add 5 to it
        if(minAngle < 50)
        {
            minAngle += 5;
        }
        else if(minAngle > 90)
        {
            minAngle = 90;
        }         

        // If the minimum angle is larger than the max angle, return the min angle
        if(minAngle > maxAngle)
            return minAngle;             

        return Random.Range(minAngle, maxAngle);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            playerHealth.damage();
        }
        // If the dolphin is out of view and hits the sea and is not already in the sea (prevents multiple collisions)
        else if(other.tag == "SeaBorder" && inWater == false)
        {
            inWater = true;
            StartCoroutine(resetJump());
        }
    }

    private IEnumerator resetJump()
    {
        // Delay before rejumping
        yield return new WaitForSeconds(jumpDelay);

        // Choose a random spawn location. Exclude the parent at index 0
        int randSpawnIndex = Random.Range(1, spawnPoints.Length);
        transform.position = spawnPoints[randSpawnIndex].position;
        // transform.position = spawnPoints[3].position; // Test code

        // Reset the rotation
        transform.rotation = Quaternion.Euler(0,0,0);

        inWater = false;

        // Jump
        jump();
    }
}
