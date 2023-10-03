using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSpecifiqueScene : MonoBehaviour
{
    public string levelToLoad;

    public void LoadLevelScene()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
