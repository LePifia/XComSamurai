using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsShown : MonoBehaviour, IDataPersistance
{
    [Header("Levels Shown")]
    [Space]

    [SerializeField] GameObject level2;
    [SerializeField] GameObject level3;
    [SerializeField] GameObject endingConfirmation;

    [SerializeField] bool level1Cleared;
    [SerializeField] bool level2Cleared;
    [SerializeField] bool level3Cleared;

    public void LoadData(LevelData levelData)
    {
        level1Cleared = levelData.level1Clear;
        level2Cleared = levelData.level2Clear;
        level3Cleared = levelData.level3Clear;
    }

    public void SaveData(ref LevelData levelData)
    {
        levelData.level1Clear = level1Cleared;
        levelData.level2Clear = level2Cleared;
        levelData.level3Clear = level3Cleared;
    }

 
    void Start()
    {
        
        if (level1Cleared && level2 != null)
        {
            level2.SetActive(true);
        }
        else if (level2 != null) { level2.SetActive(false); }

        if (level2Cleared && level3 != null)
        {
            level3.SetActive(true);
        }
        else if (level3 != null) { level3.SetActive(false); }

        if (level3Cleared && endingConfirmation != null)
        {
            endingConfirmation.SetActive(true);
        }
        else if (endingConfirmation != null) {  endingConfirmation.SetActive(false); }
    }

    public void Level1Won()
    {
        level1Cleared = true;
    }
    public void Level2Won()
    {
        level2Cleared = true;
    }

    public void Level3Won()
    {
        level3Cleared = true;
    }

    public void ResetData()
    {
        level1Cleared = false;
        level2Cleared = false;
        level3Cleared = false;
    }
}
