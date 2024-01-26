using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MPGroup : MonoBehaviour
{
    float lastFall = 0;
    private bool canHold = true;
    float fallSpeed = 2.0f;

    void Move(Vector3 direction)
    {
        transform.position += direction;

        if (isValidGridPos())
            updateGrid();
        else
            transform.position -= direction;
    }

    void Rotate()
    {
        transform.Rotate(0, 0, -90);

        if (isValidGridPos())
            updateGrid();
        else
            transform.Rotate(0, 0, 90);
    }

    void MoveDown()
    {
        transform.position += new Vector3(0, -1, 0);

        if (isValidGridPos())
        {
            updateGrid();
        }
        else
        {
            transform.position += new Vector3(0, 1, 0);
            MPPlayfield.deleteFullRows();
            FindObjectOfType<MPSpawner>().spawnNext();
            enabled = false;
        }

        lastFall = Time.time;
    }

    void MoveDownFast()
    {
        transform.position += new Vector3(0, -1, 0);

        if (isValidGridPos())
        {
            updateGrid();
        }
        else
        {
            transform.position += new Vector3(0, 1, 0);
            MPPlayfield.deleteFullRows();
            FindObjectOfType<MPSpawner>().spawnNext();
            enabled = false;
        }

        lastFall = Time.time;
    }

    bool isValidGridPos()
    {
        foreach (Transform child in transform)
        {
            Vector2 vec = MPPlayfield.roundVec2(child.position);

            if (!MPPlayfield.insideBorder(vec) || (MPPlayfield.grid[(int)vec.x, (int)vec.y] != null && MPPlayfield.grid[(int)vec.x, (int)vec.y].parent != transform))
                return false;
        }
        return true;
    }

    void updateGrid()
    {
        for (int y = 0; y < MPPlayfield.height; y++)
            for (int x = 0; x < MPPlayfield.width; x++)
                if (MPPlayfield.grid[x, y] != null && MPPlayfield.grid[x, y].parent == transform)
                    MPPlayfield.grid[x, y] = null;

        foreach (Transform child in transform)
        {
            Vector2 v = MPPlayfield.roundVec2(child.position);
            MPPlayfield.grid[(int)v.x, (int)v.y] = child;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) Move(new Vector3(-1, 0, 0));
        else if (Input.GetKeyDown(KeyCode.RightArrow)) Move(new Vector3(1, 0, 0));
        else if (Input.GetKeyDown(KeyCode.UpArrow)) Rotate();
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - lastFall >= fallSpeed) MoveDown();
        else if (Input.GetKey(KeyCode.RightShift) && Input.GetKey(KeyCode.DownArrow) || Time.time - lastFall >= fallSpeed) MoveDown();
    }

    public void ResetHold()
    {
        canHold = true;
    }

    void Start()
    {
        if (!isValidGridPos())
        {
            Debug.Log("GAME OVER");
            Destroy(gameObject);
        }
    }
}
