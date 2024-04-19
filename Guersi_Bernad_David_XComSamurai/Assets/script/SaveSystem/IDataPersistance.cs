using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistance
{
    void LoadData(LevelData levelData);

    void SaveData(ref LevelData levelData);
}

