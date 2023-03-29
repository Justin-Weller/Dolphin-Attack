using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardItemData : MonoBehaviour
{

    // Class used to store data for one leaderboard item

    public string displayName;
    public int score;
    public string spriteName;

    public LeaderboardItemData(string name, int score, string sprite)
    {
        this.displayName = name;
        this.score = score;
        this.spriteName = sprite;
    }

}
