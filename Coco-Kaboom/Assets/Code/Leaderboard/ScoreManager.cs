using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreManager
{
    // Adds a given score as a parameter to runtime list of scores
    public void AddScore(ScoreData data, HighScore score)
    {
        data.scores.Add(score);
    }

    // Saves the current runtime list of scores to PlayerPrefs file
    public void SaveScore(ScoreData data)
    {
        var json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("scores", json);
    }
}
