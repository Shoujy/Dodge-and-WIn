using UnityEngine;

public class SessionData : MonoBehaviour
{
    public static SessionData Instance;

    [SerializeField] private int _gameCount;
    public int GameCount => _gameCount;

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
    }

    public void IncreaseGameCount()
    {
        _gameCount++;
    }
}
