using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    // Start is called before the first frame update
	public GameObject[] characters;
	public int selectedCharacter=0;


public void selectCharacter(int i)
{
	selectedCharacter = i;
	PlayerPrefs.SetInt("selectedCharacter",selectedCharacter);
}
public void setCharacter()
{
	PlayerPrefs.SetInt("selectedCharacter",selectedCharacter);
}


}
