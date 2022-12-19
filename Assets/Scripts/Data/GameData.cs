using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class GameData
{
    public int difficultyLevel;
    public int musicCheckbox;
    public int maxScore;

    public GameData(int difficultyLevel, int musicCheckbox, int maxScore)
    {
        this.difficultyLevel = difficultyLevel;
        this.musicCheckbox = musicCheckbox;
        this.maxScore = maxScore;
    }
}
