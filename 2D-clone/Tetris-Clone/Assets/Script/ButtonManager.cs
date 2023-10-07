using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject optionMenu;

    static ButtonManager instance;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("there are more than one instance of buttonManager in this scene");
            return;
        }
        instance = this;
    }

    public static ButtonManager GetInstance()
    {
        return instance;
    }

    public void StartButton()
    {
        SceneManager.LoadScene("Play");
    }

    public void OpenOptionsButton()
    {
        optionMenu.SetActive(true);
    }

    public void CloseOptionButton()
    {
        optionMenu.SetActive(false);
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
