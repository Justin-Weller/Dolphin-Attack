using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColourManager : MonoBehaviour
{
    public Button[] characterButtons;

    // Start is called before the first frame update
    void Start()
    {
        // Set the default buttons colour
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        changeButtonColour(selectedCharacter);
        Debug.Log("Selected Character Index: " + selectedCharacter);
    }

    public void changeButtonColour(int selectedButtonIndex)
    {
        // Set all button colors to white
        for(int i = 0; i < characterButtons.Length; i++)
        {
            // Make all buttons interactable, thus setting them all to white
            characterButtons[i].interactable = true;
        }

        // Disable interaction on selected button, thus setting the selected buttons colour
        characterButtons[selectedButtonIndex].interactable = false;
    }
}
