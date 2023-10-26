using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Awake()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Leaderboard()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
