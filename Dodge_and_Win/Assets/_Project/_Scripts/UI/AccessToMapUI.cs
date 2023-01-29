using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AccessToMapUI : MonoBehaviour
{
    [SerializeField] private Image _map;
    [SerializeField] private Image _lockIcon;
    [SerializeField] private TextMeshProUGUI _topScore;
    [SerializeField] private GameObject _starHandler;

    [SerializeField] private int _mapID;

    private List<int> _topMapScores = new List<int>();

    private bool _isUnlock;
    public bool IsUnlock => _isUnlock;

    private void Awake()
    {
        _isUnlock = false;
    }

    private void Start()
    {
        _topMapScores = DataManager.Instance.TopMapScores;

        CheckAccessToMap();
    }

    private void CheckAccessToMap()
    {
        if (_mapID == 1 && _topMapScores[1] >= 0)
        {
            _isUnlock = true;
            MapViewSetup();
        }

        if (_mapID == 2 && _topMapScores[1] >= 25)
        {
            _isUnlock = true;
            MapViewSetup();
        }

        if (_mapID == 3 && (_topMapScores[1] >= 50 && _topMapScores[2] >= 50))
        {
            _isUnlock = true;
            MapViewSetup();
        }

        if (_mapID == 4 && (_topMapScores[1] >= 100 || _topMapScores[2] >= 100 || _topMapScores[3] >= 100))
        {
            _isUnlock = true;
            MapViewSetup();
        }

        if (_mapID == 5 && (_topMapScores[1] >= 200 || _topMapScores[3] >= 200))
        {
            _isUnlock = true;
            MapViewSetup();
        }
    }

    private void MapViewSetup()
    {
        _lockIcon.gameObject.SetActive(false);
        _map.color = new Color(200, 200, 200, 255);
        _topScore.gameObject.SetActive(true);
        _starHandler.SetActive(true);
    }
}
