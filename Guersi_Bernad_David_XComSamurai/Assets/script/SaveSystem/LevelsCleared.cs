using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsCleared : MonoBehaviour
{
    public static LevelsCleared instance { get; private set; }

    public bool level1;
    public  bool level2;
    public bool level3;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void SaveThisData()
    {
        SaveSystem.SaveLevels(this);
    }

    public void LoadThisData()
    {
        SaveData data = SaveSystem.LoadData();

        level1 = data.tutorialLevelCleared;
        level2 = data.firstLevelCleared;
        level3 = data.lastLevelCleared;
    }
}
