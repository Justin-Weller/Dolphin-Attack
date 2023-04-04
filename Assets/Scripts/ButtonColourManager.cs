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
            // ColorBlock oldButtonColors = characterButtons[i].colors;
            // oldButtonColors.normalColor = new Color32(255, 255, 255, 255);
            // oldButtonColors.selectedColor = new Color32(255, 255, 255, 255);
            // characterButtons[i].colors = oldButtonColors;

            // Make all buttons interactable
            characterButtons[i].interactable = true;
        }

        // Set the selected buttons color
        // ColorBlock selectedButtonColors = characterButtons[selectedButtonIndex].colors;
        // selectedButtonColors.normalColor = new Color32(255, 221, 168, 255);
        // selectedButtonColors.selectedColor = new Color32(255,221, 168, 255);
        // characterButtons[selectedButtonIndex].colors = selectedButtonColors;

        // Disable interaction on selected button
        characterButtons[selectedButtonIndex].interactable = false;
    }
}
