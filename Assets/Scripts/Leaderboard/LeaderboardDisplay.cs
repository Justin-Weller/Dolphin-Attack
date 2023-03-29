using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardDisplay : MonoBehaviour
{

    //public Transform listPanelParent;
    public LeaderboardItemDisplay leaderboardItemDisplayPrefab;

    void Start()
    {

        //get data

        //test data
        List<LeaderboardItemData> leaderboardData = new List<LeaderboardItemData>();

        LeaderboardItemData test1 = new LeaderboardItemData("Connor", 5, "BigGuns");
        LeaderboardItemData test2 = new LeaderboardItemData("Justin", 5, "Soldier");
        LeaderboardItemData test3 = new LeaderboardItemData("Zak", 5, "CannonFondler");
        LeaderboardItemData test4 = new LeaderboardItemData("Finn", 5, "Hunter");
        LeaderboardItemData test5 = new LeaderboardItemData("Connor", 5, "Captain");
        leaderboardData.Add(test1);
        leaderboardData.Add(test2);
        leaderboardData.Add(test3);
        leaderboardData.Add(test4);
        leaderboardData.Add(test5);

        displayItems(leaderboardData);

    }

    //displays content of LeaderboardItemData list
    private void displayItems(List<LeaderboardItemData> items)
    {
        int place = 1;
        foreach (LeaderboardItemData item in items)
        {
            LeaderboardItemDisplay display = (LeaderboardItemDisplay)Instantiate(leaderboardItemDisplayPrefab);
            display.transform.SetParent(gameObject.transform, false);
            display.prime(item, place.ToString());
            place++;
        }
    }

}
