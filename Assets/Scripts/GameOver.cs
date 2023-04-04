using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    // Time to fade to the ending image
    public float fadeDuration = 1f;
    // Time to display the ending image
    public float displayImageDuration = 4f;
    public CanvasGroup gameOverBackgroundImage;
    public GameObject healthUI;
    public AudioSource ambientAudio;
	public TextMeshProUGUI endingText;
	public GameObject scoreText;


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
    
    public void killedPlayer()
    {
        isGameOver = true;
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
        //Getting final score from WaveManager (subtract 1 to indicate number of waves survived)
        int finalScore = GameObject.Find("EventSystem").GetComponent<WaveManager>().waveNumber - 1;

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
		
		endingText.text = "You lasted " + finalScore + " waves.";
		scoreText.SetActive(true);

        if (timer > fadeDuration + displayImageDuration)
        {
            //Add leaderboard entry
			string nickName = "Dude";
			if(PlayerPrefs.GetString("nickname")!="")
			{
				nickName = PlayerPrefs.GetString("nickname");
			}
			
			string character;
			switch (PlayerPrefs.GetInt("selectedCharacter"))
        {
            case 2:
				character = "BigGuns";
                break;
            case 1:
                character = "CannonFondler";
                break;
            case 5:
                character = "Captain";
                break;
            case 3:
                character = "Hunter";
                break;
            case 0:
                character = "Scouter";
                break;
            case 4:
                character = "Soldier";
                break;
            default:
                //Debug.Log("Invalid spriteName. Displaying default.");
                character = "Captain";
                break;
        }
			
			
			
			
            GameObject.Find("EventSystem").GetComponent<LeaderboardManager>().submitLeaderboardEntry(nickName, finalScore, character);

            // Go to the main menu once the timers are finished
            SceneManager.LoadScene("TitleScreen");
        }
    }
}
