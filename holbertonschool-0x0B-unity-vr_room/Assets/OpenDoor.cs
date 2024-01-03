using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Animator animator;
    public bool characterNearby;
    int count = 0;

    private void Start()
    {
        characterNearby = false;
    }

    public void OpenAndCloseDoor()
    {
        if (characterNearby == false) 
        { 
            characterNearby = true; 
        }
        else 
        { 
            characterNearby = false;
        }
        animator.SetBool("character_nearby", characterNearby);
    }
}
