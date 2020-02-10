using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPaused;


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Pausar();
        }
    }

    public void Pausar()
    {
        if (isPaused)
        {
            if (pauseMenu)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
                
            }

        }
        else
        {
            if (pauseMenu)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }

        isPaused = !isPaused;
    }

    public void BackToMainMenu()
    {

        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame()
    {

        SceneManager.LoadScene("SampleScene");

    }
}
