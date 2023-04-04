using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
	public Sprite[] characters;
	public RuntimeAnimatorController[] anims;
	public Animator ani;
	public SpriteRenderer spr;
    // Start is called before the first frame update
    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
		spr.sprite = characters[selectedCharacter];
		ani.runtimeAnimatorController = anims[selectedCharacter];
    }

}
