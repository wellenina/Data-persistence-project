using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string currentUsername;
    public string bestScoreUsername;
    public int highestScore = 99;
    public int[] highScores = new int[5];

    // ONLY FOR TESTING
    void Start()
    {
        currentUsername = "Giulia";
        bestScoreUsername = "Matteo";
        highScores = new int[] {1, 5, 10, 15, 30};
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadData();
    }


    [System.Serializable]
    class SavedData
    {
        public string bestScoreUsername;
        public int highestScore;
        public int[] highScores;
        
    }

    public void SaveData()
    {
        SavedData data = new SavedData();
        data.bestScoreUsername = bestScoreUsername;
        data.highestScore = highestScore;
        data.highScores = highScores;

        string jsonStr = JsonUtility.ToJson(data);
    
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", jsonStr);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string jsonStr = File.ReadAllText(path);
            SavedData data = JsonUtility.FromJson<SavedData>(jsonStr);

            bestScoreUsername = data.bestScoreUsername;
            highestScore = data.highestScore;
            highScores = data.highScores;
        }
    }
}
