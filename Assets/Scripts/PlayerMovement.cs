using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator moveAnim;

    private bool facingRight = true;

    // Adjustable movement values
    public float speed;
    public float jumpStrength;
    public int maxDoubleJumps = 1;
    public float groundedDistance = 0.03f;

    // Player dashing movement values
    private bool canDash = true;
    public float dashCooldown = 1f;
    public float dashPower = 24f;
    public float dashTime = 0.2f;

    // The time that the dash should be over
    private float endDashTime;
    // The time that the player can call the next dash
    private float nextDashTime;

    public GameObject dashAudio;
    private TrailRenderer dashTrail;

    private int curNumDoubleJumps;

    private bool isJumping = false;

    Vector2 newVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveAnim = GetComponent<Animator>();
        dashTrail = GetComponent<TrailRenderer>();

        curNumDoubleJumps = maxDoubleJumps;
    }

    // Update is called once per frame
    void Update()
    {
        newVelocity = Vector2.zero;

        // Maintain the same y velocity
        newVelocity.y = rb.velocity.y;

        moveHorizontally();

        jump();

        GroundDetection();

        dash();      

        // Set the new velocity
        rb.velocity = newVelocity;

        // Sets the animation depending on if the player is moving or not
        if(newVelocity == Vector2.zero)
        {
            moveAnim.SetBool("isMoving", false);
        }
        else
        {
            moveAnim.SetBool("isMoving", true);
        }
    }

    private void moveHorizontally()
    {
        // Horizontal Movement
        // If the user presses the 'A' key, moves the character left
        if(Input.GetKey(KeyCode.A))
        {
            newVelocity.x = -speed;

            if(facingRight)
                flipCharacter();
        }
        // If the user presses the 'D' key, moves the character right
        else if(Input.GetKey(KeyCode.D))
        {
            newVelocity.x = speed;

            if(!facingRight)
                flipCharacter();
        }
    }

    // Flip the direction character is facing
    private void flipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void jump()
    {
        // If the spacebar is pressed, jump
        if(Input.GetKeyDown(KeyCode.Space) && curNumDoubleJumps > 0 && !Input.GetKey(KeyCode.S))
        {
            curNumDoubleJumps--;            

            newVelocity.y = jumpStrength;
        }
    }

    // Checks if the player is currently on the ground
    public void GroundDetection()
    {
		RaycastHit2D leftFootHit = Physics2D.Raycast (GameObject.Find("PirateLeftFoot").transform.position, Vector2.down);
        RaycastHit2D rightFootHit = Physics2D.Raycast (GameObject.Find("PirateRightFoot").transform.position, Vector2.down);

		// If on the ground, reset jump counter
        if(leftFootHit.distance < groundedDistance || rightFootHit.distance < groundedDistance)
        {
            curNumDoubleJumps = maxDoubleJumps;
		}
	}

    private void dash()
    {
        // If the user presses the 'LeftShift' key and the dash isn't on cooldown, execute a dash
        if(Input.GetKey(KeyCode.LeftShift) && canDash)
        {
            endDashTime = Time.time + dashTime;
            nextDashTime = endDashTime + dashCooldown;
            // Start emitting the dash trail
            dashTrail.emitting = true;
            // Play dash audio, removed after 1 second
            Destroy(Instantiate(dashAudio), 1);
        }

        // If the player is currently dashing and the dash isn't finished
        if(Time.time < endDashTime)
        {
            newVelocity.x *= dashPower;
            // To make the dash straight
            newVelocity.y = 0; 
            canDash = false;

            // Don't allow any other movement to occur while in dash
            return;
        }

        // If the dash cooldown is over
        if(Time.time > nextDashTime)
        {
            canDash = true;
        }

        // When the dash is over
        // Stop emitting the dash trail
        dashTrail.emitting = false;
    }
}
