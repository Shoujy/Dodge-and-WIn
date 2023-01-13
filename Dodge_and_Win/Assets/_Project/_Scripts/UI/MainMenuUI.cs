using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject _settingPanel;

    public void StartGame()
    {
        SceneManager.LoadScene(4);
    }

    public void Setting()
    {
        _settingPanel.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void Menu()
    {
        _settingPanel.SetActive(false);
        this.gameObject.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
