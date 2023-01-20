using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlow : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;

    private bool _isGameOver;

    public bool IsGameOver => _isGameOver;

    private void Awake()
    {
        _isGameOver = false;
    }

    public void ChangeGameState()
    {
        _isGameOver = true;

        var gameUI = FindObjectOfType<GameUI>();

        if(gameUI.Score > DataManager.Instance.TopMapScores[SceneManager.GetActiveScene().buildIndex])
        {
            DataManager.Instance.TopMapScores[SceneManager.GetActiveScene().buildIndex] = gameUI.Score;
            DataManager.Instance.SaveData();
        }

        SessionData.Instance.IncreaseGameCount();

        _gameOverPanel.SetActive(true);
    }
}
