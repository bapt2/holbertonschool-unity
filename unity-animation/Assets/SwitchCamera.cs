using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField] GameObject cutsceneCamera;
    [SerializeField] GameObject mainCamera;

    public void SwitchingCamera()
    {
        cutsceneCamera.SetActive(false);
        mainCamera.SetActive(true);
    }
}
