using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class DataPersistanceManager : MonoBehaviour
{
    public static DataPersistanceManager Instance { get; private set; }

    [Header("FileConfiguration")]
    [Space]
    [SerializeField] string fileName;
    [Space]
    private FileDataHandler fileHandler;
    private LevelData levelData;
    private List<IDataPersistance> dataPersistances;

    public void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Alredy one");
        }
        Instance = this;
    }

    private void Start()
    {
        this.fileHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistances = FindAllDataPersistances();
        LoadGame();
    }

    private List<IDataPersistance> FindAllDataPersistances()
    {
        IEnumerable<IDataPersistance> dataPersistances = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();
        return new List<IDataPersistance>(dataPersistances);
    }

    public void NewGame()
    {
        this.levelData = new LevelData();
        Debug.Log("Load Data" + levelData.level1Clear + levelData.level2Clear + levelData.level3Clear);
        SaveGame();
    }

    public void LoadGame()
    {
        this.levelData = fileHandler.Load();
        if (this.levelData == null)
        {
            NewGame();
        }

        foreach(IDataPersistance persistance in dataPersistances)
        {
            persistance.LoadData(levelData);
        }

        Debug.Log("Load Data" + levelData.level1Clear + levelData.level2Clear + levelData.level3Clear);
    }

    public void SaveGame()
    {
        foreach (IDataPersistance persistance in dataPersistances)
        {
            persistance.SaveData(ref levelData);
        }

        fileHandler.Save(levelData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
}
