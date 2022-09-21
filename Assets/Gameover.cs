using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class Gameover : MonoBehaviour
{
   

    // Start is called before the first frame update
    void Start()
    {
        if(PlayfabManager.IsLoggedIn){
            PlayfabManager.UpdateStatistic("level_leaderboard", Partita.getLivelloCorrente());
            Debug.Log(Partita.getLivelloCorrente());
        }
        gameObject.GetComponent<Text>().text="Level " + Partita.getLivelloCorrente();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}