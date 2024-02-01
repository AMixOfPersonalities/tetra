using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Group : MonoBehaviour
{
    float lastFall = 0;
    private bool canHold = true;
    float fallSpeed = 1.0f;

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
            Playfield.deleteFullRows();
            FindObjectOfType<Spawner>().spawnNext();
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
            Playfield.deleteFullRows();
            FindObjectOfType<Spawner>().spawnNext();
            enabled = false;
        }

        lastFall = Time.time;
    }

    bool isValidGridPos()
    {
        foreach (Transform child in transform)
        {
            Vector2 vec = Playfield.roundVec2(child.position);

            if (!Playfield.insideBorder(vec) || (Playfield.grid[(int)vec.x, (int)vec.y] != null && Playfield.grid[(int)vec.x, (int)vec.y].parent != transform))
                return false;
        }
        return true;
    }

    void updateGrid()
    {
        for (int y = 0; y < Playfield.height; y++)
            for (int x = 0; x < Playfield.width; x++)
                if (Playfield.grid[x, y] != null && Playfield.grid[x, y].parent == transform)
                    Playfield.grid[x, y] = null;

        foreach (Transform child in transform)
        {
            Vector2 v = Playfield.roundVec2(child.position);
            Playfield.grid[(int)v.x, (int)v.y] = child;
        }
    }

    void Update()
    {
        if (!PauseMenuUI.isPaused)
        {

            if (Input.GetKeyDown(KeyCode.LeftArrow)) Move(new Vector3(-1, 0, 0));
            else if (Input.GetKeyDown(KeyCode.RightArrow)) Move(new Vector3(1, 0, 0));
            else if (Input.GetKeyDown(KeyCode.UpArrow)) Rotate();
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - lastFall >= fallSpeed) MoveDown();
            else if (Input.GetKey(KeyCode.RightShift) && Input.GetKey(KeyCode.DownArrow) || Time.time - lastFall >= fallSpeed) MoveDown();

        }
    }


    public void ResetHold()
    {
        canHold = true;
    }

    void Start()
    {
        if (!isValidGridPos())
        {
            Destroy(gameObject);
            SceneManager.LoadScene(5);
        }
    }
}
