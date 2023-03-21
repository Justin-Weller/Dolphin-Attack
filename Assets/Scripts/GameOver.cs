using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Time to fade to the ending image
    public float fadeDuration = 1f;
    // Time to display the ending image
    public float displayImageDuration = 4f;
    public CanvasGroup gameOverBackgroundImage;
    public GameObject healthUI;
    public AudioSource ambientAudio;

    // Will add in group portion
    // public AudioSource gameOverAudio;
    
    private bool isGameOver;
    private float timer;
    private bool hasAudioPlayed;

    // If the player falls off the boat
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            isGameOver = true;
        }
    }

    void Update()
    {
        if(isGameOver)
        {
            endLevel();
        }
    }

    // Ends the game and returns the player to the main menu
    private void endLevel()
    {
        // Make the UI disappear
        healthUI.SetActive(false);

        // Disable the background Audio
        ambientAudio.enabled = false;

        // Play the ending audio
        if(!hasAudioPlayed)
        {
            // Uncomment during group portion
            // gameOverAudio.Play();
            hasAudioPlayed = true;
        }

        timer += Time.deltaTime;
        gameOverBackgroundImage.alpha = timer / fadeDuration;

        if (timer > fadeDuration + displayImageDuration)
        {
            // Go to the main menu once the timers are finished
            SceneManager.LoadScene("TitleScreen");
        }
    }
}