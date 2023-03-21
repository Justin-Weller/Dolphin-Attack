using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        // Pause/unpause the game when the ESC button is pressed
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                resumeGame();
            }
            else
            {
                pauseGame();
            }
        }
    }

    public void resumeGame()
    {
        // Removes the pause menu
        pauseMenu.SetActive(false);

        // Unfreezes time in the game
        Time.timeScale = 1f;

        isPaused = false;
    }

    void pauseGame()
    {
        // Displays the pause menu
        pauseMenu.SetActive(true);

        // Freezes time in the game
        Time.timeScale = 0f;

        isPaused = true;
    }

    public void restartGame()
    {
        SceneManager.LoadScene("Game");
        resumeGame();
    }

    public void exitGame()
    {
        SceneManager.LoadScene("TitleScreen");
        resumeGame();
    }
}
