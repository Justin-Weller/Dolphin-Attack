using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeaderboardItemDisplay : MonoBehaviour
{
    //UI elements
    public TMP_Text placeNum;
    public TMP_Text username;
    public Image spriteImage;
    public TMP_Text score;

    // sprite Icons
    public Sprite BigGuns;
    public Sprite CannonFondler;
    public Sprite Captain;
    public Sprite Hunter;
    public Sprite Scouter;
    public Sprite Soldier;


    void Start()
    {
        //test
        //LeaderboardItemData test = new LeaderboardItemData("Connor", 5, "CannonFondler");
        //prime(test, 2.ToString());
    }

    public void prime(LeaderboardItemData itemData, string place)
    {
        this.placeNum.text = place;
        this.username.text = itemData.displayName;
        this.score.text = itemData.score.ToString();

        switch (itemData.spriteName)
        {
            case "BigGuns":
                spriteImage.sprite = BigGuns;
                break;
            case "CannonFondler":
                spriteImage.sprite = CannonFondler;
                break;
            case "Captain":
                spriteImage.sprite = Captain;
                break;
            case "Hunter":
                spriteImage.sprite = Hunter;
                break;
            case "Scouter":
                spriteImage.sprite = Scouter;
                break;
            case "Soldier":
                spriteImage.sprite = Soldier;
                break;
            default:
                Debug.Log("Invalid spriteName. Displaying default.");
                spriteImage.sprite = Captain;
                break;
        }
    }
}
