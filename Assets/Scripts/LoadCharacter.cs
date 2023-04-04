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

		// Change the collider based on the character
		BoxCollider2D collider = GetComponent<BoxCollider2D>();

		// If the character is the pirate, set the collider position lower
		if(selectedCharacter == 5)
			collider.offset = new Vector2(collider.offset.x, -0.1013f);
		else
			collider.offset = new Vector2(collider.offset.x, -0.0785f);
    }

}
