using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    public string elapsedTimeStr;

    public bool isTiming = true;

    Collider2D winBox;

    public void Start()
    {
        elapsedTimeStr = Time.timeSinceLevelLoad.ToString("00:00.00");
    }

    public void Update()
    {
        if (isTiming)
        {
            elapsedTimeStr = Time.timeSinceLevelLoad.ToString("00:00.00");
            timeText.text = elapsedTimeStr;
        }
    }

    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
