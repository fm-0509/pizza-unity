using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour
{
    // async scene load
    // TODO: add loading screen
    public void PlayGame(){
        AsyncOperation load = SceneManager.LoadSceneAsync(1);
   }

   public void OpenStats()
   {
    AsyncOperation load = SceneManager.LoadSceneAsync(3);
   }

}
