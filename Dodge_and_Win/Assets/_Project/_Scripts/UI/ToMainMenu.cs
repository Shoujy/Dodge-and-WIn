using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainMenu : MonoBehaviour
{
    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
