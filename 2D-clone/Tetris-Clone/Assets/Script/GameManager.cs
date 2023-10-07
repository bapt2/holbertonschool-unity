using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject optionMenu;
    [SerializeField] GameObject losePanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !losePanel.activeInHierarchy)
        {
            if (optionMenu.activeInHierarchy)
            {
                Time.timeScale = 1;
                ButtonManager.GetInstance().CloseOptionButton();
            }
            else
            {
                Time.timeScale = 0;
                ButtonManager.GetInstance().OpenOptionsButton();
            }
        }
        //condition Temporaire

        if (Input.GetKeyDown(KeyCode.L))
        {
            losePanel.SetActive(true);
        }
    }

}
