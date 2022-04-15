
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string playerName;
    public int playerScore;
    public string playerHighScoreName;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadPlayerName();
        LoadPlayerScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int playerScore;
        public string playerHighScoreName;
    }

    public void LoadPlayerNameJighScore() //Must start in awake
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerHighScoreName = data.playerHighScoreName;
        }
    }


    public void SavePlayerName()
    {
        SaveData data = new SaveData();

        data.playerName = playerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log("Nombre guardado " + data.playerName);
    }

    public void SavePlayerScoreNameAndHighScoreName()//a
    {
        SaveData data = new SaveData();

        data.playerScore = playerScore;
        data.playerName = playerName;
        data.playerHighScoreName = playerHighScoreName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log("Score");
    }

    public void LoadPlayerName() //Must start in awake
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
        }
    }

    public void LoadPlayerScore()//Must start in awake
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerScore = data.playerScore;
        }
    }

}