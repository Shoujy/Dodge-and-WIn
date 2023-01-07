using UnityEngine;

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
        _gameOverPanel.SetActive(true);
    }
}
