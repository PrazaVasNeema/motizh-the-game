using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class GameData
{
    public int difficultyLevel;
    public int musicCheckbox;
    public int maxScoreNormal;
    public int maxScoreHard;
    public int hatChoice;
    public int plowChoice;
    public int rockChoice;

    public GameData(int difficultyLevel, int musicCheckbox, int maxScoreNormal, int maxScoreHard, int hatChoice, int plowChoice, int rockChoice)
    {
        this.difficultyLevel = difficultyLevel;
        this.musicCheckbox = musicCheckbox;
        this.maxScoreNormal = maxScoreNormal;
        this.maxScoreHard = maxScoreHard;
        this.hatChoice = hatChoice;
        this.plowChoice = plowChoice;
        this.rockChoice = rockChoice;
    }
}
