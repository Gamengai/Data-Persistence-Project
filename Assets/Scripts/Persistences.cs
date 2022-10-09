using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class Persistences : MonoBehaviour
{
    public static Persistences Instance;
    public HighScoreData HighScore = new HighScoreData();
    public string PlayerName = "";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadHighScore();
    }

    [System.Serializable]
    public class HighScoreData
    {
        public string Name;

        public int Score;
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "highscore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            HighScore = JsonUtility.FromJson<HighScoreData>(json);
        }
    }

    public void SaveHighScore()
    {
        string path = Application.persistentDataPath + "highscore.json";

        string json = JsonUtility.ToJson(HighScore);
        File.WriteAllText(path, json);
    }

    public bool TryChangeHighScore(int score)
    {
        if (HighScore.Score < score)
        {
            HighScore = new HighScoreData
            {
                Name = PlayerName,
                Score = score,
            };
            return true;
        }
        return false;
    }
}
