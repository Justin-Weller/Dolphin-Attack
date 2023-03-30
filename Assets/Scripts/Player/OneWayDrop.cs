using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayDrop : MonoBehaviour
{
    private BoxCollider2D playerCollider;
    private GameObject currOneWayPlatform;

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // If both space and the 'S' key are pressed
        if(Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.S))
        {
            // If on a one way platform
            if(currOneWayPlatform != null)
            {
                // Drop through it
                StartCoroutine(dropThroughPlatform());
            }
        }
    }

    // Detects when the player lands on a one way platform
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currOneWayPlatform = collision.gameObject;
        }
    }

    // Detects when the player leaves a one way platform
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currOneWayPlatform = null;
        }
    }

    // Drops the player through the platform
    private IEnumerator dropThroughPlatform()
    {
        // Removes the collider interaction for a short period then re-adds it
        BoxCollider2D currOneWayCollider = currOneWayPlatform.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(playerCollider, currOneWayCollider);
        yield return new WaitForSeconds(0.05f);
        Physics2D.IgnoreCollision(playerCollider, currOneWayCollider, false);
    }
}
