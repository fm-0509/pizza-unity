using System.Collections;
using System.Collections.Generic;
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
        }
        else 
        {
            Destroy(gameObject); 
        }
    }

    public void ChangeVolume(float value){
        AudioListener.volume=value;
    }
}

