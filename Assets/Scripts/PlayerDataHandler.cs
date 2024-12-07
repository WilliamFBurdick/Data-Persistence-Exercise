using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerDataHandler : MonoBehaviour
{
    public static PlayerDataHandler Instance;

    public string PlayerName;

    public string HighscoreName;
    public int HighscoreScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadPlayerData();
    }

    [System.Serializable]
    class HighscoreData
    {
        public string Name;
        public int Score;
    }

    public void SavePlayerData()
    {
        HighscoreData data = new HighscoreData();
        data.Name = HighscoreName;
        data.Score = HighscoreScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighscoreData data = JsonUtility.FromJson<HighscoreData>(json);

            HighscoreName = data.Name;
            HighscoreScore = data.Score;
        }
    }
}
