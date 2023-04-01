using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Nickname : MonoBehaviour
{
	
	public TextMeshProUGUI userInput;
	
	public void saveName()
	{
		PlayerPrefs.SetString("nickname", userInput.text);
		//nick = inputTxt;
		//PlayerPrefs.SetString("nickname",nick);
		
	}
}
