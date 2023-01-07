using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private int _score;

    private void Start()
    {
        _score = 0;
    }

    public void IncreaseScore()
    {
        _score++;
        _scoreText.SetText(_score.ToString());
    }
}
