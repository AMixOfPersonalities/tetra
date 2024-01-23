using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameObject nextTetromino;
    private GameObject holdTetromino;
    public GameObject[] tetraminos;

    public void spawnNext()
    {
        int i = Random.Range(0, tetraminos.Length);

        Instantiate(tetraminos[i],
            transform.position,
            Quaternion.identity);
    }

    public GameObject getHoldTetromino()
    {
        return holdTetromino;
    }

    public void swapHoldTetromino(GameObject tetromino, Vector3 position)
    {
        Destroy(holdTetromino);
        holdTetromino = Instantiate(tetromino, position, Quaternion.identity);
        holdTetromino.GetComponent<Group>().enabled = false; // Disable movement until the next piece spawns
    }

    private void spawnHoldTetromino()
    {
        holdTetromino = Instantiate(tetraminos[Random.Range(0, tetraminos.Length)], transform.position, Quaternion.identity);
        holdTetromino.GetComponent<Group>().enabled = false; // Disable movement until the next piece spawns
    }

    void Start() { spawnNext(); }
}
