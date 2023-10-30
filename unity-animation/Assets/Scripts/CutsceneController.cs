using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] GameObject cutsceneCamera;
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject timerCanvas;

    [SerializeField] PlayerController playerController;
    //[SerializeField] Timer timer;

    public void StartGame()
    {
        mainCamera.SetActive(true);
        playerController.enabled = true;
        timerCanvas.SetActive(true);
        //timer.enabled = true;
        cutsceneCamera.SetActive(false);
    }
}
