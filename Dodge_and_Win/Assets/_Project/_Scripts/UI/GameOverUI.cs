using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _topScoreText;
    // [SerializeField] private Interstitial _interstitial;

    private void Start()
    {
        SoundManager.Instance.StopMusic();
        _topScoreText.SetText("Best Score: " + DataManager.Instance.TopMapScores[SceneManager.GetActiveScene().buildIndex].ToString());

        // ToDO: Check for each 3rd game in this session and if (session % 3 == 0)  => Invoke("ShowInterstitial", 1.0f);
        if(SessionData.Instance.GameCount % 3 == 0)
        {
            // Invoke("ShowInterstitial", 0.75f);
        }
    }

    //private void ShowInterstitial()
    //{
    //    _interstitial.ShowInterstitialAd();
    //}

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayMusic()
    {
        SoundManager.Instance.PlayMusic();
    }
}
