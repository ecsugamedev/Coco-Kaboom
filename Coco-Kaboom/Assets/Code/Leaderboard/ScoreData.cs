using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class ScoreData : ScoreManager
{
    // runtime data structure of JSON saved high scores
    public List<HighScore> scores = new List<HighScore>();
}
