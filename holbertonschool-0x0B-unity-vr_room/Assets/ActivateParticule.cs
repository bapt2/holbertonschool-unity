using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateParticule : MonoBehaviour
{
    public GameObject particule;
    bool isActive;

    public void ActivateAndDeactivate()
    {
        if (!particule.activeInHierarchy && !isActive)
        {
            particule.SetActive(true);
        }
        else
        {
            particule.SetActive(false);
        }
    }
}
