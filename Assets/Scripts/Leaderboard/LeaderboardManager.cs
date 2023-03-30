using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LeaderboardManager : MonoBehaviour
{
    public const string listCountKey = "listCount";
    public const string usernameKey = "username_";
    public const string scoreKey = "score_";
    public const string spriteNameKey = "spriteName_";

    private static int listCount;

    // Start is called before the first frame update
    void Start()
    {
        refreshCount();
    }

    private void refreshCount()
    {
        if (!PlayerPrefs.HasKey(listCountKey))
        {
            PlayerPrefs.SetInt(listCountKey, 0);
            PlayerPrefs.Save();
        }
        listCount = PlayerPrefs.GetInt(listCountKey);

        Debug.Log("Count: " + listCount.ToString());
    }

    public void submitLeaderboardEntry(string username, int score, string spriteName)
    {
        List<LeaderboardItemData> leaderboard = getLeaderboardData(0);
        LeaderboardItemData newEntry = new LeaderboardItemData(username, score, spriteName);

        //add to list
        leaderboard.Add(newEntry);
        savePlayerPrefsList(leaderboard);
    }

    // returns leaderboard data from playerPrefs, sorted by score at insertion
    // count is number of items returned
    public List<LeaderboardItemData> getLeaderboardData(int count)
    {
        refreshCount();
        List<LeaderboardItemData> currentLeaderboard = new List<LeaderboardItemData>();

        //guard clause
        if (!PlayerPrefs.HasKey(usernameKey + 0.ToString())) return currentLeaderboard;

        // return full list if count is less than 1 or greater than listCount
        if (count < 1 || count > listCount) count = listCount;

        //get data from playerPrefs (sorted at insertion)
        for (var i = 0; i < count; i++)
        {
            string indexStr = i.ToString();
            string username = PlayerPrefs.GetString(usernameKey + indexStr);
            int score = PlayerPrefs.GetInt(scoreKey + indexStr);
            string spriteName = PlayerPrefs.GetString(spriteNameKey + indexStr);

            LeaderboardItemData newItemData = new LeaderboardItemData(username, score, spriteName);
            currentLeaderboard.Add(newItemData);
        }

        return currentLeaderboard;

    }

    private void savePlayerPrefsList(List<LeaderboardItemData> leaderboard)
    {
        //sort list by score using LINQ before saving
        leaderboard = leaderboard.OrderByDescending(lid => lid.score).ToList();

        //update listCount
        listCount = leaderboard.Count;
        PlayerPrefs.SetInt(listCountKey, listCount);

        int i = 0;
        foreach (LeaderboardItemData item in leaderboard)
        {
            string indexStr = i.ToString();
            PlayerPrefs.SetString(usernameKey + indexStr, item.displayName);
            PlayerPrefs.SetInt(scoreKey + indexStr, item.score);
            PlayerPrefs.SetString(spriteNameKey + indexStr, item.spriteName);

            Debug.Log("Saved to playerPrefs " + item.displayName);

            i++;
        }
        PlayerPrefs.Save();
    }

}
