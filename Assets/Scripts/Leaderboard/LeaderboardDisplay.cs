using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardDisplay : MonoBehaviour
{

    //public Transform listPanelParent;
    public LeaderboardItemDisplay leaderboardItemDisplayPrefab;

    void Start()
    {
        GameObject EventSystem = GameObject.Find("EventSystem");

        //leaderboard test data
        //lb.GetComponent<LeaderboardManager>().submitLeaderboardEntry("Connor", 2, "BigGuns");
        //lb.GetComponent<LeaderboardManager>().submitLeaderboardEntry("Justin", 5, "Soldier");
        //lb.GetComponent<LeaderboardManager>().submitLeaderboardEntry("Zak", 3, "CannonFondler");
        //lb.GetComponent<LeaderboardManager>().submitLeaderboardEntry("Finn", 1, "Hunter");
        //lb.GetComponent<LeaderboardManager>().submitLeaderboardEntry("Connor", 4, "Captain");
        //lb.GetComponent<LeaderboardManager>().submitLeaderboardEntry("Finn", 7, "Scouter");

        //get leaderboard data from manager (playerPrefs)
        List<LeaderboardItemData> leaderboardData = EventSystem.GetComponent<LeaderboardManager>().getLeaderboardData(5);
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
