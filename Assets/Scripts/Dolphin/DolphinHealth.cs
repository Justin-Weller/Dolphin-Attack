using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DolphinHealth : MonoBehaviour
{
    public int health = 2;

    // When the dolphin is hit by a bullet, they take damage
    public void damage()
    {
        health--;

        // When the dolphin runs out of health it dies
        if(health == 0)
        {
            Destroy(gameObject);
        }
    }
}
