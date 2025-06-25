using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class UpgradeData
{
    public int extraHealthLevel = 0;
    public int moveSpeedLevel = 0;

    public int gold = 0;
}
public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance;
    public UpgradeData data;

    private string savePath;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            savePath = Path.Combine(Application.persistentDataPath, "upgrade.json");
            Load();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
    }

    public void Load()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            data = JsonUtility.FromJson<UpgradeData>(json);
        }
        else
        {
            data = new UpgradeData();
        }
    }
    public void UpgradeHealth()
    {
        data.extraHealthLevel++;
        Save();
    }

    public void UpgradeSpeed()
    {
        data.moveSpeedLevel++;
        Save();
    }
}
