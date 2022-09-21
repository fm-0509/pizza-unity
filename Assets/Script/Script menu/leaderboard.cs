using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class leaderboard : MonoBehaviour
{
    
    private List<PlayerLeaderboardEntry> board;

    private string text;

    void Start()
    {
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
                    board=result.Leaderboard;
                    Debug.Log(string.Format("GetLeaderboard completed: {0}", boardName));
                    for(int i=0; i<board.Count; i++){
                        if(board[i]!=null){
                            text+=board[i].DisplayName+"\t"+board[i].StatValue+"/n";
                        }
                    }
                    gameObject.GetComponent<Text>().text=text;
                },
                // Failure
                (PlayFabError error) =>
                {
                    Debug.LogError("GetLeaderboard failed.");
                    Debug.LogError(error.GenerateErrorReport());
                }
                );
    }

   

}
