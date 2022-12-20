using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class GameData
{
    public int difficultyLevel;
    public int musicCheckbox;
    public int maxScore;
    public int rockChoice;

    public GameData(int difficultyLevel, int musicCheckbox, int maxScore, int rockChoice)
    {
        this.difficultyLevel = difficultyLevel;
        this.musicCheckbox = musicCheckbox;
        this.maxScore = maxScore;
        this.rockChoice = rockChoice;
    }
}
