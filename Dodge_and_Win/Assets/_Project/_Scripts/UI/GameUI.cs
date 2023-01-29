using DG.Tweening;
using TMPro;
using UnityEngine;
using System.Collections;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    [Header("Notification settings")]
    [SerializeField] private TextMeshProUGUI _levelCompleteNotification;
    [SerializeField] private float _scaleTo;
    [SerializeField] private float _scaleDuration;
    [SerializeField] private int _lifeTime;

    private UnitSpawner _unitSpawner;

    private int _score;

    public int Score => _score;

    private void Awake()
    {
        _unitSpawner = FindObjectOfType<UnitSpawner>();
    }

    private void Start()
    {
        _score = 0;
        _levelCompleteNotification.transform.DOScale(_scaleTo, _scaleDuration).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDestroy()
    {
        _levelCompleteNotification.transform.DOKill();
        StopAllCoroutines();
        _levelCompleteNotification.gameObject.SetActive(false);
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
                _unitSpawner.UpgradeDifficult();
                ShowLevelNotification("Level 1 Completed!");
                break;

            case 50:
                _unitSpawner.UpgradeDifficult();
                ShowLevelNotification("Level 2 Completed!");
                break;

            case 100:
                _unitSpawner.UpgradeDifficult();
                ShowLevelNotification("Level 3 Completed!");
                break;

            case 200:
                _unitSpawner.UpgradeDifficult();
                ShowLevelNotification("Level 4 Completed!");
                break;

            case 500:
                _unitSpawner.UpgradeDifficult();
                ShowLevelNotification("Level 5 Completed!");
                break;

            default:
                break;
        }
    }

    private void ShowLevelNotification(string notification)
    {
        _levelCompleteNotification.SetText(notification);

        _levelCompleteNotification.transform.DOPlay();

        _levelCompleteNotification.gameObject.SetActive(true);

        StartCoroutine(StartCountdown(_lifeTime));
    }

    private IEnumerator StartCountdown(int timeToWait)
    {
        int counter = timeToWait;

        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }

        _levelCompleteNotification.transform.DOPause();
        _levelCompleteNotification.gameObject.SetActive(false);
    }
}
