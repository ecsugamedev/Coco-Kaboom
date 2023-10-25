using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public string elapsedTimeStr;

    public bool isTiming = true;

    public float finalTime;

    private ScoreData addScore;

    [SerializeField]
    GameObject HUD;

    private float currentTimer;

    private float bestTime;

    private bool scoreSet = false;

    GameObject cc;

    void Start()
    {
        cc = GameObject.Find("Player");

        // Gets saved high scores from JSON file, and sends them to instantiated ScoreData object
        var json = PlayerPrefs.GetString("scores", "{}");
        addScore = JsonUtility.FromJson<ScoreData>(json);

        // Sets the timer to 00:00.00
        elapsedTimeStr = Time.timeSinceLevelLoad.ToString("00:00.00");

        // Saves bestTime as the first object in JSON, and if null sets best time to positive infinity
        if (addScore.scores.Count > 0)
        {
            bestTime = addScore.scores[0].time;
        }
        else
        {
            // Really any score will beat it
            bestTime = Mathf.Infinity;
        }
    }

    public void Update()
    {
        // Ref from "WinCondition.cs"
        if (isTiming)
        {
            // Saves current time, and displays it.
            currentTimer = Time.timeSinceLevelLoad;
            elapsedTimeStr = currentTimer.ToString("00:00.00");
            HUD.GetComponent<HUD>().timeText.text = elapsedTimeStr;
        }
        else
        {
            finalTime = currentTimer;
            // Shows final time
            HUD.GetComponent<HUD>().finalTime.text = elapsedTimeStr;

            if (finalTime < bestTime && !scoreSet)
            {
                // Saves the current timer time as the registry's high score if less than previous, and number of coins
                HighScore score = new HighScore(finalTime, cc.GetComponent<coincollecter>().cc.coinCount);

                // Adds new high score to List, and then saves the current list to JSON Pref
                addScore.scores.Add(score);
                addScore.SaveScore(addScore);

                // Shows new high score
                HUD.GetComponent<HUD>().highScore.text = finalTime.ToString("00:00.00");

                scoreSet = true;
            }
            else if (!scoreSet)
            {
                // Shows previous high score
                HUD.GetComponent<HUD>().highScore.text = bestTime.ToString("00:00.00");

                // Saves the current timer time and number of coins
                HighScore score = new HighScore(finalTime, cc.GetComponent<coincollecter>().cc.coinCount);

                // Adds new score to List, and then saves the current list to JSON Pref
                addScore.scores.Add(score);
                addScore.SaveScore(addScore);
            }
        }
    }
}
