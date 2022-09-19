using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject joystick;

 

    public void PauseGame()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;

        pauseMenu.SetActive(true);
        joystick.SetActive(false);
        pauseButton.SetActive(false);
        
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseMenu.SetActive(false);
        joystick.SetActive(true);
        pauseButton.SetActive(true);
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void backMenu()
    {
        Time.timeScale = 1;
        Player.finisci2();
        AudioListener.pause = false; 
    }
}
