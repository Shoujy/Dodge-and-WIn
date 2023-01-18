using UnityEngine;

public class HelpTutorialHider : MonoBehaviour
{
    [SerializeField] private GameObject _helpPanel;
    private void Awake()
    {
        if (DataManager.Instance.TopMapScores[1] > 15)
        {
            _helpPanel.SetActive(false);
        }
    }
}
