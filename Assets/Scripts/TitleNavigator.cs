using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleNavigator : MonoBehaviour
{
    // If the start button is pushed, launch the game
    public void startGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void startMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void startLeaderboard()
    {
        SceneManager.LoadScene("LeaderboardScreen");
    }

    public void startCharacterSelection()
    {
        SceneManager.LoadScene("CharacterScreen");
    }

    // If the exit button is pushed, quit the game
    public void exitGame()
    {
        Application.Quit();
    }
}
