using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class Leaderboard : MonoBehaviour
{
    private ScoreData data;

    public TextMeshProUGUI[] times;
    public TextMeshProUGUI[] coins;

    private void Awake()
    {
        // Gets saved high scores from JSON file, and sends them to instantiated ScoreData object
        var json = PlayerPrefs.GetString("scores", "{}");
        data = JsonUtility.FromJson<ScoreData>(json);
    }

    public IEnumerable<HighScore> GetHighScores()
    {
        // Orders objects of HighScore based on parameter of time in ascending order
        return data.scores.OrderBy(x => x.time);
    }

    public void Start()
    {
        var scores = GetHighScores().ToArray();

        // Outputs times to leaderboard
        for (int i = 0; i < scores.Length; i++)
        {
            times[i].text = scores[i].time.ToString("00:00.00");
            coins[i].text = scores[i].coins.ToString();
            Debug.Log(scores[i]);
        }
    }

}
