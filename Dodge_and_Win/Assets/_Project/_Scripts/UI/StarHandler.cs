using System.Collections.Generic;
using UnityEngine;

public class StarHandler : MonoBehaviour
{
    [SerializeField] private int _mapIndex;

    private List<int> _topMapScores = new List<int>();

    private void Start()
    {
        _topMapScores = DataManager.Instance.TopMapScores;

        CheckStarAmount();
    }

    private void CheckStarAmount()
    {
        if (_topMapScores[_mapIndex] >= 20)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }

        if (_topMapScores[_mapIndex] >= 50)
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }

        if (_topMapScores[_mapIndex] >= 100)
        {
            transform.GetChild(2).gameObject.SetActive(true);
        }

        if (_topMapScores[_mapIndex] >= 200)
        {
            transform.GetChild(3).gameObject.SetActive(true);
        }

        if (_topMapScores[_mapIndex] >= 500)
        {
            transform.GetChild(4).gameObject.SetActive(true);
        }
    }
}
