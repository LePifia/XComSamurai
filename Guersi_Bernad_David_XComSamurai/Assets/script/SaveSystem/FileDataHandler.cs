using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{

    private readonly string dataDirPath = "";
    private readonly string dataFileName = "";
   

    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public LevelData Load()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        LevelData loadedData = null;

        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";
                using (FileStream stream = new(fullPath, FileMode.Open))
                {
                    using StreamReader sr = new(stream);
                    dataToLoad = sr.ReadToEnd();
                }


                //Deserialize
                loadedData = JsonUtility.FromJson<LevelData>(dataToLoad);
            }
            catch (Exception)
            {
                Debug.Log("Error ocurred while loading" + fullPath); 
            
            }
        }
        return loadedData;
    }

    public void Save(LevelData levelData)
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            string dataToStore = JsonUtility.ToJson(levelData, true);

            using (FileStream stream = new(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new(stream))
                {
                    writer.Write(dataToStore);
                }
            }
            
            
        }
        catch (Exception)
        {
            Debug.Log("Error ocurred when trying to save data to file:" + fullPath); 
        }
    }
}
