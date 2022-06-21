using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Difficulty
{
    public static float secondsToMaxDifficulty = 30;

    public static float GetDifficulty()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);
    }
}
