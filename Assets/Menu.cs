using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void backMenu(){
        AsyncOperation load = SceneManager.LoadSceneAsync(0);
   }
}
