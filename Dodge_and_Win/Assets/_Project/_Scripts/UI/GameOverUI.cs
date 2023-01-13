using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _topScoreText;

    private void Start()
    {
        SoundManager.Instance.StopMusic();
        _topScoreText.SetText("Best Score: " + DataManager.Instance.TopMapScores[SceneManager.GetActiveScene().buildIndex].ToString());
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
