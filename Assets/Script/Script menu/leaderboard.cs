using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using System.Runtime.CompilerServices;

public class leaderboard : MonoBehaviour
{

    public Text Top10Text;

    private static leaderboard instance;

    public static leaderboard Instance()
    {
        if (instance == null)
            instance = new leaderboard();

        return instance;
    }
    
    private List<PlayerLeaderboardEntry> board;

    private string text;

    public void updateLeaderBoard()
    {
        if (!PlayfabManager.IsLoggedIn)
            return;

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
                        text += board[i].Position + " " + board[i].DisplayName + ":" + board[i].StatValue + "\n";

                    Debug.Log(text);    
                    this.Top10Text.text = text;
                },
                // Failure
                (PlayFabError error) =>
                {
                    Debug.LogError("GetLeaderboard failed.");
                    Debug.LogError(error.GenerateErrorReport());
                }
                );
    }


    void Start()

    { 
        this.Top10Text = this.GetComponent<Text>();
        Debug.Log(this.Top10Text);
        DontDestroyOnLoad(gameObject);
        this.updateLeaderBoard();
    }
    
        
   

}
