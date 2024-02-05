using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    public bool tutorialLevelCleared;
    public bool firstLevelCleared;
    public bool lastLevelCleared;

    public SaveData (LevelsCleared levelsCleared)
    {
        tutorialLevelCleared = levelsCleared.level1;
        firstLevelCleared = levelsCleared.level2;
        lastLevelCleared = levelsCleared.level3;
    }
}
