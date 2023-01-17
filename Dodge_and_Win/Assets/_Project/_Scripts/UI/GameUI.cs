using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private UnitSpawner __unitSpawner;

    private int _score;

    public int Score => _score;

    private void Awake()
    {
        __unitSpawner = FindObjectOfType<UnitSpawner>();
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
                __unitSpawner.UpgradeDifficult();
                break;

            case 50:
                __unitSpawner.UpgradeDifficult();
                break;

            case 100:
                __unitSpawner.UpgradeDifficult();
                break;

            case 200:
                __unitSpawner.UpgradeDifficult();
                break;

            case 500:
                __unitSpawner.UpgradeDifficult();
                break;

            default:
                break;
        }
    }
}
