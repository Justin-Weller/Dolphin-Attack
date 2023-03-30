using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunProjectile : MonoBehaviour
{
    Rigidbody2D rb;
    public float timeExists;
    public float speed;
    private Vector2 direction;
    public GameObject shotAudio;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // When shot, the projectile plays a sound, removed after 1 second
        Destroy(Instantiate(shotAudio), 1);

        // Delete the projectile after timeExists seconds
        Destroy(gameObject, timeExists);

        // Get the direction between the bullet spawn point and the mouse
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            Debug.Log("Hit Dolphin!");

            // Damage the dolphin
            other.GetComponent<DolphinHealth>().damage();

            // Destroy the bullet when it hits the dolphin
            Destroy(gameObject);
        }
    }
}
