using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public List<int> TopMapScores = new List<int>(6);

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Debug.Log(Application.persistentDataPath);

        for (int i = 0; i < TopMapScores.Count; i++)
        {
            TopMapScores[i] = 0;
        }
    }

    class Data
    {
        public List<int> TopMapScores = new List<int>(6);
    }

    public void SaveData()
    {
        Data data = new Data();
        data.TopMapScores = TopMapScores;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savemap.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savemap.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Data data = JsonUtility.FromJson<Data>(json);

            TopMapScores = data.TopMapScores;
        }
    }
}
