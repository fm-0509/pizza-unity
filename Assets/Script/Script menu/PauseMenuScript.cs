using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject pauseButton;
    private GameObject joystick;

    private float initTimeScale = 0f;

    void Start()
    {
        if(joystick == null)
            joystick = GameObject.FindWithTag("GameController");
        this.initTimeScale = Time.timeScale;
    }

    public void PauseGame()
    {
        initTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        joystick.SetActive(false);
        
    }

    public void ResumeGame()
    {
        Time.timeScale = initTimeScale;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        joystick.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void backMenu()
    {
        AsyncOperation load = SceneManager.LoadSceneAsync(0);

    }
}
