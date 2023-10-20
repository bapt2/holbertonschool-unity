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
    public int lineCount = 0;

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

    }

    public void ClearLines()
    {
        for (int y = 0; y < height; y++)
        {
            if (IsLineComplete(y))
            {
                DestroyLine(y);
                lineCount += 1;
                MoveLines(y);
                
                gameLines += 1;
                if (gameLines % 9 == 0)
                {

                    gameLevel += 1;
                    drop = LevelSpeed.levels[gameLevel];
                    uIManager.level.text = string.Format("{0}", gameLevel);
                }

                if (IsLineComplete(y))
                {
                    ClearLines();
                }
                else
                {
                    if (lineCount == 1)
                    {
                        gameScore += 40 * (gameLevel + 1);
                    }
                    if (lineCount == 2)
                    {
                        gameScore += 100 * (gameLevel + 1);
                    }
                    if (lineCount == 3)
                    {
                        gameScore += 300 * (gameLevel + 1);
                    }
                    if (lineCount == 4)
                    {
                        gameScore += 1200 * (gameLevel + 1);
                    }
                    lineCount = 0;
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
                    grid[Mathf.Abs(x), Mathf.Abs(i)] = grid[Mathf.Abs(x), Mathf.Abs(i) + 1];
                    grid[Mathf.Abs(x), Mathf.Abs(i + 1)] = null;
                    // sert à voir ce qui a bouger
                    // Debug.Log(grid[Mathf.Abs(x), Mathf.Abs(i)]);
                    grid[Mathf.Abs(x), Mathf.Abs(i)].gameObject.transform.position -= new Vector3(0, 1f, 0);
                }
            }
        }
    }

    void DestroyLine(int y)
    {
        for (int x = 0; x < width; x++)
        {
            Destroy(grid[Mathf.Abs(x), Mathf.Abs(y)].gameObject);
            // sert à voir ce qui vient d'être detruit
            // Debug.Log(grid[Mathf.Abs(x), Mathf.Abs(y)]);
            grid[x, y] = null;
        }
    }

    public bool IsLineComplete(int y)
    {
        for (int x = 0; x < width; x++)
        {       
            if (grid[x, y] == null)
            {
                return false;
            }
            //sert à check la grid
            Debug.Log(grid[Mathf.Abs(x), Mathf.Abs(y)]);

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
