using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapsUI : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> Scores = new List<TextMeshProUGUI>();

    [SerializeField] private List<AccessToMapUI> _accessToMapUI;

    private void Start()
    {
        for (int i = 0; i < Scores.Count; i++)
        {
            Scores[i].SetText(DataManager.Instance.TopMapScores[i+1].ToString()); 
        }
    }

    public void LoadMap_1()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMap_2()
    {
        if (_accessToMapUI[0].IsUnlock)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void LoadMap_3()
    {
        if (_accessToMapUI[1].IsUnlock)
        {
            SceneManager.LoadScene(3);
        }
    }

    public void LoadMap_4()
    {
        if (_accessToMapUI[2].IsUnlock)
        {
            SceneManager.LoadScene(4);
        }
    }

    public void LoadMap_5()
    {
        if (_accessToMapUI[3].IsUnlock)
        {
            SceneManager.LoadScene(5);
        }
    }
}
