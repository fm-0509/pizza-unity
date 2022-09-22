using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using System.Runtime.CompilerServices;
using System;

public class leaderboard : MonoBehaviour
{

    private static leaderboard instance;


    public static leaderboard Instance()
    {
        if (instance == null)
            instance = new leaderboard();

        return instance;
    }

    private List<PlayerLeaderboardEntry> board;

    private string text;

    public Text yourScore;

    private Text Score;

    void Start()

    {
        DontDestroyOnLoad(this.gameObject);
        updateLeaderBoard(this.gameObject.GetComponent<Text>(), yourScore);
    }

    public void updateLeaderBoard(Text to10text,Text yourScore)
    {
        if (PlayfabManager.IsLoggedIn)
        {
            Score=yourScore;
            PlayFabClientAPI.GetLeaderboard(
                    // Request
                    new GetLeaderboardRequest
                    {
                        StatisticName = "level_leaderboard",
                        StartPosition = 0,
                        MaxResultsCount = 10
                    },
                    // Success
                    (GetLeaderboardResult result) =>
                    {
                        var boardName = (result.Request as GetLeaderboardRequest).StatisticName;
                        board = result.Leaderboard;
                        Debug.Log(string.Format("GetLeaderboard completed: {0}", boardName));
                        for (int i = 0; i < board.Count; i++)
                        {
                            text += "\t" + board[i].DisplayName + "\t\t\t" + board[i].StatValue + "\n";
                        }
                        to10text.text = text;
                    },
                    // Failure
                    (PlayFabError error) =>
                    {
                        Debug.LogError("GetLeaderboard failed.");
                        Debug.LogError(error.GenerateErrorReport());
                    }
                    );
            PlayFabClientAPI.GetPlayerStatistics(
                new GetPlayerStatisticsRequest(),
                OnGetStatistics,
                error => Debug.LogError(error.GenerateErrorReport())
            );
        }
            else{
            to10text.text="Error you need to login";
        }


    }

    private void OnGetStatistics(GetPlayerStatisticsResult result)
    {
        Debug.Log("Received the following Statistics:");
        foreach (var eachStat in result.Statistics)
        {
            if (eachStat.StatisticName == "level_leaderboard")
                Score.text="\tYour score \t\t"+eachStat.Value;
        }
    }

}
