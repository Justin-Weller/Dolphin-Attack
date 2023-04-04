using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int health = 5;
    public float invincibilityDuration = 1;
    private bool isInvincible = false;
    public GameOver ending;
    public TextMeshProUGUI healthText;
    private AudioSource hurtAudio;

    // Start is called before the first frame update
    void Start()
    {
        healthText.text = health.ToString();
        hurtAudio = this.GetComponent<AudioSource>();
    }

    // If the player takes damage
    public void damage()
    {
        // If the player has not been recently damaged
        if(!isInvincible)
        {
            if (health > 0)
            {
                hurtAudio.Play();
                health--;
                healthText.text = health.ToString();
                // Play player hurt audio, removed after 1 second
                // Destroy(Instantiate(hurtAudio), 1);

                StartCoroutine(becomeInvincible());
            }
            
            // If they die
            if(health == 0)
            {
                ending.killedPlayer();
            }
        }
    }

    // Gives the player a brief period of invincibility after being damaged
    private IEnumerator becomeInvincible()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }

    // If the player picks up a heart and heals
    public void heal()
    {
        health++;
        healthText.text = health.ToString();
    }
}
