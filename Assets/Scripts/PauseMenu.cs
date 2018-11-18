using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject PauseUI;
    public GameObject GameOverUI;

    public bool paused = false;
    float timeLeft = 30.0f;

    void Start (){
        PauseUI.SetActive(false);
        GameOverUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }
        if (paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Time.timeScale = 0;
            GameOver();
        }
    }

    public void Pause()
    {
        paused = true;
        PauseUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void GameOver()
    {
        GameOverUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        paused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
