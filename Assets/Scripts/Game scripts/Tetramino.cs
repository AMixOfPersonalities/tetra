using UnityEngine;
using System.Collections;

public class Tetramino : MonoBehaviour
{
    float fall = 0;
    public float fallSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        CheckUserInput();//checks for user input every frame
    }


    void CheckUserInput()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) //user presses the right arrow key
        {
            transform.position += new Vector3(1, 0, 0); //tetramino moves right by 1 unit

            if (!CheckIfPositionValid())
            {
                transform.position += new Vector3(-1, 0, 0);
            }
            else
            {
                FindObjectOfType<Game>().UpdateGrid(this);
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) //user presses the left arrow key
        {
            transform.position += new Vector3(-1, 0, 0); //tetramino moves left by 1 unit

            if (!CheckIfPositionValid())
            {
                transform.position += new Vector3(1, 0, 0);
            }
            else
            {
                FindObjectOfType<Game>().UpdateGrid(this);
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)) 
        {

            transform.Rotate(0, 0, 90);//tetramino rotates 90 degress clockwise

            if (!CheckIfPositionValid())
            {
                transform.Rotate(0, 0, -90);
            }
            else
            {
                FindObjectOfType<Game>().UpdateGrid(this);
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - fall >= fallSpeed)
        {
            transform.position += new Vector3(0, -1, 0);


            if (!CheckIfPositionValid())
            {
                transform.position += new Vector3(0, 1, 0);

                FindObjectOfType<Game>().DeleteMinoRow();

                enabled = false;

                FindObjectOfType<Game>().SpawnNewTetramino();
            }
            else
            {
                FindObjectOfType<Game>().UpdateGrid(this);
            }

            fall = Time.time;

        }

    }


    bool CheckIfPositionValid ()
    {
        foreach (Transform mino in transform)
        {
            Vector2 pos = FindObjectOfType<Game>().Rounding (mino.position);

            if (FindObjectOfType<Game>().CheckIsInTheGrid (pos) == false)
            {
                return false;
            }
            
            if (FindObjectOfType<Game>().GetTransformedAtGridPosition(pos) != null && FindObjectOfType<Game>().GetTransformedAtGridPosition(pos).parent != transform)
            {
                return false;
            }
        }

        return true;

    }
}

