using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    float timer = 0;
    bool movable;

    //public GameObject rig;
    GameLogic gameLogic;

    private void Start()
    {
        gameLogic = FindObjectOfType<GameLogic>();
        movable = true;
    }


    void RegisterBlock()
    {
        foreach (Transform subBlock in gameObject.transform)
        {
            if (subBlock.position.y >= GameLogic.height)
            {
                GameLogic.testSpawn.SetActive(false);
                GameLogic.testOver.SetActive(true);
            }
            else
            {
                gameLogic.grid[(int)subBlock.position.x, (int)subBlock.position.y] = subBlock;
            }
        }
    }

    bool CheckValide()
    {
        foreach (Transform subBlock in gameObject.transform)
        {

            //check for border
            if ((int)subBlock.position.x >= GameLogic.width ||
                (int)subBlock.position.x < 0 ||
                (int)subBlock.position.y < 0)
            {
                return false;
            }
            //check for block
            if (subBlock.position.y < GameLogic.height &&
               gameLogic.grid[(int)subBlock.position.x,
               (int)subBlock.position.y] != null)
            {
                //Debug.Log(gameLogic.grid[(int)subBlock.position.x, (int)subBlock.position.y]);
                return false;
            }
        }
        return true;
    }

    public void ClearEmptyBlock()
    {
        if (gameObject.transform.childCount == 0)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (movable)
        {
            timer += 1 * Time.deltaTime;

            //drop
            if (Input.GetKey(KeyCode.DownArrow) && timer > GameLogic.quickDrop)
            {
                gameObject.transform.position -= new Vector3(0, 1, 0);
                timer = 0f;

                if (!CheckValide())
                {
                    movable = false;
                    //problème ici
                    gameObject.transform.position += new Vector3(0, 1, 0);
                    RegisterBlock();
                    gameLogic.ClearLines();
                    gameLogic.SpawnBlock();

                }
            }
            else if (timer > GameLogic.drop)
            {
                gameObject.transform.position -= new Vector3(0, 1, 0);
                timer = 0f;
                if (!CheckValide())
                {
                    movable = false;
                    gameObject.transform.position += new Vector3(0, 1, 0);
                    // et la
                    RegisterBlock();
                    gameLogic.ClearLines();
                    gameLogic.SpawnBlock();
                }
            }
        }
        //horizontal input
        if (Input.GetKeyDown(KeyCode.LeftArrow) && movable)
        {
            gameObject.transform.position -= new Vector3(1, 0, 0);

            if (!CheckValide())
            {
                gameObject.transform.position += new Vector3(1, 0, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && movable)
        {
            gameObject.transform.position += new Vector3(1, 0, 0);

            if (!CheckValide())
            {
                gameObject.transform.position -= new Vector3(1, 0, 0);
            }
        }

        //Rotate
        if (Input.GetKeyDown(KeyCode.UpArrow) && movable)
        {
            gameObject.transform.eulerAngles -= new Vector3(0, 0, 90);
            //gameObject.transform.Rotate(0, 0, -90);

            if (!CheckValide())
            {
                //gameObject.transform.Rotate(0, 0, 90);

                gameObject.transform.eulerAngles += new Vector3(0, 0, 90);
            }
        }
        else
        {
            ClearEmptyBlock();
        }
    }
}
