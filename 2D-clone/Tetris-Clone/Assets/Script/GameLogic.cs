using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameLogic : MonoBehaviour
{
    public static float drop = 1;
    public static float quickDrop = 0.05f;
    public static float lateralMov = 0.05f;

    public static int width = 15, height = 30;

    public int gameScore = 0, gameLines = 0, gameLevel = 0;

    public UIManager uIManager;

    public Sprite nextBlockSprite;

    public GameObject winMenu;
    public static GameObject testOver;
    public GameObject gameOverMenu;

    public GameObject[] blocks;
    public static GameObject testSpawn;
    public GameObject spawnBlock;
    public Transform[,] grid = new Transform[width, height];

    private void Start()
    {
        drop = LevelSpeed.levels[0];
        testOver = gameOverMenu;
        testSpawn = spawnBlock;
        SpawnBlock();
    }

    private void Update()
    {
        uIManager.score.text = string.Format("{0}", gameScore);
        uIManager.scoreAtEnd.text = string.Format("{0}", gameScore);

        uIManager.lines.text = string.Format("{0}", gameLines);
        uIManager.linesAtEnd.text = string.Format("{0}", gameLines);

        if (gameLines >= 200)
        {
            spawnBlock.SetActive(false);
            winMenu.SetActive(true);
        }


        //hold
        if (Input.GetKeyDown(KeyCode.H))
        {
            
        }
    }

    public void ClearLines()
    {
        for (int y = 0; y < height; y++)
        {
            if (IsLineComplete(y))
            {
                DestroyLine(y);
                MoveLines(y);
                gameScore += 50;
                gameLines += 1;
                if (gameLines % 9 == 0)
                {
                    gameLevel += 1;
                    Debug.Log(drop);
                    drop = LevelSpeed.levels[gameLevel];
                    Debug.Log(drop);
                    uIManager.level.text = string.Format("{0}", gameLevel);
                }
            }
        }
    }

    void MoveLines(int y)
    {
        for (int i = y; i < height-1; i++)
        {
            for (int x = 0; x < width; x++)
            {
                if(grid[x, i +1] != null)
                {
                    grid[x, i] = grid[x, i + 1];
                    grid[x, i + 1] = null;
                    grid[x, i].gameObject.transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }

    void DestroyLine(int y)
    {
        for (int x = 0; x < width; x++)
        {
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }

    bool IsLineComplete(int y)
    {
        for (int x = 0; x < width; x++)
        {
            if (grid[x, y] == null)
            {
                return false;
            }
        }
        return true;
    }

    public void SpawnBlock()
    {
        float guess = Random.Range(0, 1f);
        guess *= blocks.Length;
        Instantiate(blocks[(int)guess], spawnBlock.transform);
    }
}
