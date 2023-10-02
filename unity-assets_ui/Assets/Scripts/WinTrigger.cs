using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public bool win = false;
    private static WinTrigger instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("there is more thn  one instance of Wintrigger in the scene");
            return;
        }
        instance = this;
    }

    public static WinTrigger GetInstance()
    {
        return instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            win = true;
        }
    }
}
