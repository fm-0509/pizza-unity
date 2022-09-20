using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScriptMusica : MonoBehaviour
{
    public static ScriptMusica instance;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject); 

        if (instance == null) 
        {
            instance = this;
          /*  if (PlayerPrefs.HasKey("volume"))
            {
                instance.ChangeVolume(PlayerPrefs.GetFloat("volume"));
                Debug.Log("volume found: " + PlayerPrefs.GetFloat("volume"));
                    

            }*/

        }
        else 
        {
            Destroy(gameObject); 
        }
    }

    public void ChangeVolume(float value){
        AudioListener.volume=value;
        PlayerPrefs.SetFloat("volume", value);
       
        PlayerPrefs.Save();
       // Debug.Log("volume set to "+AudioListener.volume);

    }

}

