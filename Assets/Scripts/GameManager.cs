using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private string bestPlayerName = string.Empty;
    [SerializeField] private string playerName = string.Empty;
    [SerializeField] private int bestScore = 0;

    public string PlayerName 
    { 
        get { return playerName; } 
        set { playerName = value; }
    }

    public string BestPlayerName
    {
        get { return bestPlayerName; }
        set { bestPlayerName = value; }
    }

    public int BestScore
    {
        get { return bestScore; }
        set { bestScore = value; }
    }

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadBestPlayer();
    }

    [System.Serializable]
    class ScoreData
    {
        public string Name;
        public int Score;
    }

    public void SaveBestPlayer()
    {
        ScoreData data = new ScoreData();
        data.Name = bestPlayerName;
        data.Score = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestPlayer()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            ScoreData data = JsonUtility.FromJson<ScoreData>(json);

            bestPlayerName = data.Name;
            bestScore = data.Score;
        }
    }
}