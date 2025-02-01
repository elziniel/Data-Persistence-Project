using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager instance;

    public string playerName;
    public string highScorePlayerName;
    public int playerScore;
    public int highScorePlayerScore;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int score;
    }

    public void SaveHighScore()
    {
        SaveData data = new()
        {
            name = highScorePlayerName,
            score = highScorePlayerScore
        };

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/savefile.json");
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScorePlayerName = data.name;
            highScorePlayerScore = data.score;
        }
    }
}
