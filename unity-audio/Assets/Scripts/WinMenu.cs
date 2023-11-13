using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public void Next()
    {
        if (SceneManager.GetActiveScene().buildIndex != 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
        Time.timeScale = 1;
    }
}
