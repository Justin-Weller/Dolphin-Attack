using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DolphinHealth : MonoBehaviour
{
    public int health = 2;
    public GameObject deathEffect;

    // When the dolphin is hit by a bullet, they take damage
    public void damage()
    {
        health--;

        // When the dolphin runs out of health it dies (create a death effect and destroy gameobject)
        if(health == 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
