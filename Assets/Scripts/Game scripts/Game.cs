using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static int gridWidth = 11;
    public static int gridHeight = 20;

    public static Transform[,] grid = new Transform[gridWidth, gridHeight]; 

    void Start()
    {
        SpawnNewTetramino ();
        DeleteMinoRow ();
    }

    public bool IsRowFull (int y)
    {
        for (int x = 0; x < gridWidth; ++x)
        {
            if (grid[x, y] == null)
            {
                return false;
            }
        }

        return true;
    }

    public void DeleteLine (int y)
    {
        for (int x = 0; x < gridWidth; ++x)
        {
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }

    public void MoveMinoRowDown (int y)
    {
        for (int x = 0; x < gridWidth; ++x)
        {
            if (grid[x, y] != null)
            {
                grid[x, y-1] = grid[x, y];
                grid[x, y] = null;
                grid[x, y-1].position += new Vector3(0, -1, 0);
            }
        }
    }

    public void MoveAllMinoRowsDown (int y)
    {
        for(int j = y;j < gridHeight; ++j)
        {
            MoveMinoRowDown(j);
        }
    }

    public void DeleteMinoRow ()
    {
        for (int i = 0; i < gridHeight; ++i)
        {
            if (IsRowFull(i))
            {
                DeleteLine(i);
                MoveAllMinoRowsDown(i+1);
                --i;
            }
            
        }
    }

    public void UpdateGrid (Tetramino tetramino)
    {
        for (int j = 0; j < gridHeight; j++) {

            for (int i = 0; i < gridWidth; i++)
            {
                if (grid[i, j] != null)
                {
                    if (grid[i, j].parent == tetramino.transform)
                    {
                        grid[i, j] = null;
                    }
                }
            }
        
        }

        foreach (Transform mino in tetramino.transform)
        {
            Vector2 pos = Rounding (mino.position);

            if (pos.y < gridHeight)
            {
                grid[(int)pos.x, (int)pos.y] = mino;
            }
        }

    }


    public void SpawnNewTetramino ()
    {
        GameObject newTetramino = (GameObject)Instantiate(Resources.Load(GetNextTetramino(), typeof(GameObject)), new Vector2(5.0f, 20.0f), Quaternion.identity);
    }

    public bool CheckIsInTheGrid (Vector2 pos)
    {
        return ((int)pos.x <= gridWidth  && (int)pos.y > 0 && (int)pos.x > 0);
    }

    public Vector2 Rounding (Vector2 pos)
    {
        return new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));
    }

    public Transform GetTransformedAtGridPosition (Vector2 pos)
    {
        if (pos.y > gridHeight - 1)
        {
            return null;
        }
        else
        {
            return grid[(int)pos.x, (int)pos.y];
        }
    }


    string GetNextTetramino ()
    {
        int nextTetramino = Random.Range(0, 8);
        string nextTetraminoName = "J Tetramino";

        switch (nextTetramino)
        {
            case 0:
                nextTetraminoName = "I Tetramino";
                break;
            case 1:
                nextTetraminoName = "J Tetramino";
                break;
            case 2:
                nextTetraminoName = "L Tetramino";
                break;
            case 3:
                nextTetraminoName = "O Tetramino";
                break;
            case 4:
                nextTetraminoName = "S Tetramino";
                break;
            case 5:
                nextTetraminoName = "T Tetramino";
                break;
            case 6:
                nextTetraminoName = "Z Tetramino";
                break;
        }

        return nextTetraminoName;
    }
}
