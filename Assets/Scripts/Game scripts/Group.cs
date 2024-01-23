using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour
{
    float lastFall = 0;
    private GameObject heldTetromino;
    private bool canHold = true;
    float fallSpeed = 2.0f;

    bool isValidGridPos()
    {
        foreach (Transform child in transform)
        {
            Vector2 vec = Playfield.roundVec2(child.position);

            if (!Playfield.insideBorder(vec))
                return false;

            if (Playfield.grid[(int)vec.x, (int)vec.y] != null &&
                Playfield.grid[(int)vec.x, (int)vec.y].parent != transform)
                return false;
        }
        return true;
    }

    void updateGrid()
    {
        for (int y = 0; y < Playfield.height; y++)
            for (int x = 0; x < Playfield.width; x++)
                if (Playfield.grid[x, y] != null)
                    if (Playfield.grid[x, y].parent == transform)
                        Playfield.grid[x, y] = null;
        foreach (Transform child in transform)
        {
            Vector2 v = Playfield.roundVec2(child.position);
            Playfield.grid[(int)v.x, (int)v.y] = child;
        }
    }

    void Update()
    {
        // Move Left
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Modify position
            transform.position += new Vector3(-1, 0, 0);

            // See if valid
            if (isValidGridPos())
                // It's valid. Update grid.
                updateGrid();
            else
                // It's not valid. revert.
                transform.position += new Vector3(1, 0, 0);
        }

        // Move Right
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // Modify position
            transform.position += new Vector3(1, 0, 0);

            // See if valid
            if (isValidGridPos())
                // It's valid. Update grid.
                updateGrid();
            else
                // It's not valid. revert.
                transform.position += new Vector3(-1, 0, 0);
        }

        // Rotate
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(0, 0, -90);

            // See if valid
            if (isValidGridPos())
                // It's valid. Update grid.
                updateGrid();
            else
                // It's not valid. revert.
                transform.Rotate(0, 0, 90);
        }

        // Move Downwards and Fall
        else if (Input.GetKeyDown(KeyCode.DownArrow) ||
                 Time.time - lastFall >= fallSpeed)
        {
            // Modify position
            transform.position += new Vector3(0, -1, 0);

            // See if valid
            if (isValidGridPos())
            {
                // It's valid. Update grid.
                updateGrid();
            }
            else
            {
                // It's not valid. revert.
                transform.position += new Vector3(0, 1, 0);

                // Clear filled horizontal lines
                Playfield.deleteFullRows();

                // Spawn next Group
                FindObjectOfType<Spawner>().spawnNext();

                // Disable script
                enabled = false;
            }

            lastFall = Time.time;
            Debug.Log(fallSpeed);

        }

        else if (Input.GetKey(KeyCode.RightShift) ||
                 Time.time - lastFall >= fallSpeed)
        {
            // Modify position
            transform.position += new Vector3(0, -1, 0);

            // See if valid
            if (isValidGridPos())
            {
                // It's valid. Update grid.
                updateGrid();
            }
            else
            {
                // It's not valid. revert.
                transform.position += new Vector3(0, 1, 0);

                // Clear filled horizontal lines
                Playfield.deleteFullRows();

                // Spawn next Group
                FindObjectOfType<Spawner>().spawnNext();

                // Disable script
                enabled = false;
            }

            lastFall = Time.time;
            Debug.Log(fallSpeed);

        }

        else if (Input.GetKeyDown(KeyCode.C))  // You can use any key you prefer
        {
            if (canHold)
            {
                if (heldTetromino == null)
                {
                    heldTetromino = FindObjectOfType<Spawner>().getHoldTetromino();
                    FindObjectOfType<Spawner>().spawnNext();
                    canHold= true;
                }
                else
                {
                    FindObjectOfType<Spawner>().swapHoldTetromino(heldTetromino, transform.position);
                    heldTetromino = FindObjectOfType<Spawner>().getHoldTetromino();
                }

                canHold = false;
                enabled = false; // Disable movement until the next piece spawns
            }
        }
    }

    void Start()
    {
        // Default position not valid? Then it's game over
        if (!isValidGridPos())
        {
            Debug.Log("GAME OVER");
            Destroy(gameObject);
        }
    }
}
