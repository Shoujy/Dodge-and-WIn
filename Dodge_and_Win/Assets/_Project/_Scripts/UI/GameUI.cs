using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private SpawnManager _spawnManager;

    private int _score;

    public int Score => _score;

    private void Awake()
    {
        _spawnManager = FindObjectOfType<SpawnManager>();
    }

    private void Start()
    {
        _score = 0;
    }

    public void IncreaseScore()
    {
        _score++;
        _scoreText.SetText(_score.ToString());
    }

    public void ScoreChange()
    {
        switch (_score)
        {
            case 20:
                _spawnManager.UpgradeDifficult();
                break;

            case 50:
                _spawnManager.UpgradeDifficult();
                break;

            case 100:
                _spawnManager.UpgradeDifficult();
                break;

            case 200:
                _spawnManager.UpgradeDifficult();
                break;

            case 500:
                _spawnManager.UpgradeDifficult();
                break;

            default:
                break;
        }
    }
}
