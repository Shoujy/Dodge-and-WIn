using System.IO;
using UnityEngine;

public class SessionData : MonoBehaviour
{
    public static SessionData Instance;

    [SerializeField] private int _gameCount;
    public int GameCount => _gameCount;

    public int GeneralGameCount { get; private set; }

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

        _gameCount = 0;
        LoadData();
    }

    private void OnDestroy()
    {
        SaveData();
    }

    private class Data
    {
        public int GeneralGameCount;
    }

    public void IncreaseGameCount()
    {
        _gameCount++;
    }

    public void SaveData()
    {
        Data data = new Data();
        data.GeneralGameCount = GeneralGameCount + _gameCount;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/gamecount.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/gamecount.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Data data = JsonUtility.FromJson<Data>(json);
            
            GeneralGameCount = data.GeneralGameCount;
        }
    }
}
