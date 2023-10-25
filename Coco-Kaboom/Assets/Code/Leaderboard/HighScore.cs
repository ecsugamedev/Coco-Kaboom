using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HighScore
// Constructor Class
{
    public float time;
    public float coins;

    public HighScore(float time, float coins)
    {
        this.time = time;
        this.coins = coins;
    }
}
