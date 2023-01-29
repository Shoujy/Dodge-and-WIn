using System.Collections.Generic;
using UnityEngine;

public class AchieveHandler : MonoBehaviour
{
    [SerializeField] private List<GameObject> _achieveBadges;
    [SerializeField] private List<bool> _isAchieveOpens;

    private List<int> _topMapScores = new List<int>();

    private void Start()
    {
        _topMapScores = DataManager.Instance.TopMapScores;

        for (int i = 0; i < _achieveBadges.Count; i++)
        {
            _isAchieveOpens.Add(false);
        }

        CheckAchieveCondition();

        AchieveBadgeSetup();
    }

    private void AchieveBadgeSetup()
    {
        for (int i = 0; i < _achieveBadges.Count; i++)
        {
            if (_isAchieveOpens[i] == true)
            {
                _achieveBadges[i].SetActive(true);
            }
            else
            {
                _achieveBadges[i].SetActive(false);
            }
        }
    }

    private void CheckAchieveCondition()
    {
        FirstBadgeCondition();

        SecondAndFifthBadgeCondition();

        ThirdAndFourthBadgeCondition();
    }

    private void FirstBadgeCondition()
    {
        int openMapsCount = 0;

        for (int i = 0; i < _topMapScores.Count; i++)
        {
            if (_topMapScores[i] > 0)
            {
                openMapsCount++;
            }
        }

        if (openMapsCount == 5)
        {
            _isAchieveOpens[0] = true;
        }
    }

    private void SecondAndFifthBadgeCondition()
    {
        int fiveStarMapCount = 0;

        for (int i = 0; i < _topMapScores.Count; i++)
        {
            if (_topMapScores[i] >= 500)
            {
                _isAchieveOpens[1] = true;
                fiveStarMapCount++;
            }
        }

        if (fiveStarMapCount == 5)
        {
            _isAchieveOpens[4] = true;
        }
    }

    private void ThirdAndFourthBadgeCondition()
    {
        if (SessionData.Instance.GeneralGameCount >= 100)
        {
            _isAchieveOpens[2] = true;
        }

        if (SessionData.Instance.GeneralGameCount >= 500)
        {
            _isAchieveOpens[3] = true;
        }
    }
}
