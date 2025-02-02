using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager instance;

    public string playerName;
    public List<SaveData> highScores;
    private string filePath;

    [System.Serializable]
    public class SaveData
    {
        public string name;
        public int score;

        public SaveData(string _name, int _score)
        {
            name = _name;
            score = _score;
        }
    }

    [System.Serializable]
    private class SerializableSaveData
    {
        public List<SaveData> scores;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        filePath = Application.persistentDataPath + "/highScores.json";
        DontDestroyOnLoad(gameObject);
        LoadHighScores();
    }

    public void AddScore(string playerName, int score)
    {
        highScores.Add(new SaveData(playerName, score));
        highScores.Sort((a, b) => b.score.CompareTo(a.score)); // Sort descending

        // Keep only top 10
        if (highScores.Count > 10)
        {
            highScores.RemoveRange(10, highScores.Count - 10);
        }
        SaveHighScores();
    }

    public void SaveHighScores()
    {
        SerializableSaveData data = new()
        {
            scores = highScores
        };
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, json);
    }

    public void LoadHighScores()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            SerializableSaveData data = JsonUtility.FromJson<SerializableSaveData>(json);

            highScores = data.scores;
        }
    }

    public override string ToString()
    {
        string highScoreText = "";
        for (int i = 0; i < highScores.Count; i++)
        {
            highScoreText += $"{i + 1}.\t{highScores[i].score}\t{highScores[i].name}\n";
        }
        return highScoreText;
    }
}
