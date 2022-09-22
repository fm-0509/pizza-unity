using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using System;

public class Gameover : MonoBehaviour
{
   private int score;

   public GameObject record;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayfabManager.IsLoggedIn){
            PlayFabClientAPI.GetPlayerStatistics(
                new GetPlayerStatisticsRequest(),
                OnGetStatistics,
                error => Debug.LogError(error.GenerateErrorReport())
            );
            PlayfabManager.UpdateStatistic("level_leaderboard", Partita.getLivelloCorrente());
        }
        gameObject.GetComponent<Text>().text="Level " + Partita.getLivelloCorrente();


    }

    private void OnGetStatistics(GetPlayerStatisticsResult result)
    {
        Debug.Log("Received the following Statistics:");
        foreach (var eachStat in result.Statistics){
            if(eachStat.StatisticName=="level_leaderboard")
                this.score= eachStat.Value;
        }
        if(Partita.getLivelloCorrente() > score){
                record.SetActive(true);
            }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
