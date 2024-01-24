using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameObject nextHoldTetromino;
    private GameObject nextTetromino;
    private GameObject holdTetromino;
    public GameObject[] tetraminos;

    public void spawnNext()
    {
        int i = Random.Range(0, tetraminos.Length);
        GameObject currentTetramino = Instantiate(tetraminos[i], transform.position, Quaternion.identity);

    }
    void Start() { spawnNext(); }
}
