using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] tetraminos;
    public GameObject[] nextTetraminos = new GameObject[3]; // Array to store the next three tetraminos
    public Transform queueDisplayPosition; // Position for displaying the next tetraminos

    void Start()
    {
        // Start the game with the first tetramino
        spawnNext();
    }

    public void spawnNext()
    {

        // Spawn the first tetramino in the game
        GameObject currentTetramino = Instantiate(tetraminos[Random.Range(0, tetraminos.Length)], transform.position, Quaternion.identity);
    }

    
}
