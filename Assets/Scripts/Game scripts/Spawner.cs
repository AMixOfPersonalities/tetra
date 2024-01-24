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
        // Initial spawn for the queue display
        SpawnQueueDisplay();
        // Start the game with the first tetramino
        spawnNext();
    }

    void SpawnQueueDisplay()
    {
        // Spawn the next tetraminos at the queue display position
        for (int i = 0; i < 3; i++)
        {
            int randomIndex = Random.Range(0, tetraminos.Length);
            nextTetraminos[i] = Instantiate(tetraminos[randomIndex], queueDisplayPosition.position, Quaternion.identity);
            nextTetraminos[i].SetActive(false); // Initially set them inactive
        }
    }

    public void spawnNext()
    {
        // Move the displayed tetraminos to the spawner position
        MoveQueueDisplayToSpawner();

        // Spawn the first tetramino in the game
        GameObject currentTetramino = Instantiate(tetraminos[Random.Range(0, tetraminos.Length)], transform.position, Quaternion.identity);
    }

    void MoveQueueDisplayToSpawner()
    {
        // Move the tetraminos from the queue display position to the spawner position
        for (int i = 0; i < 3; i++)
        {
            nextTetraminos[i].transform.position = transform.position;
            nextTetraminos[i].SetActive(true);
        }
    }

    // Function to get the next tetramino in the queue
    public GameObject GetNextTetramino()
    {
        GameObject nextTetromino = nextTetraminos[0];
        // Shift the array to update the queue
        for (int i = 0; i < 2; i++)
        {
            nextTetraminos[i] = nextTetraminos[i + 1];
        }
        int randomIndex = Random.Range(0, tetraminos.Length);
        nextTetraminos[2] = Instantiate(tetraminos[randomIndex], queueDisplayPosition.position, Quaternion.identity);
        nextTetraminos[2].SetActive(false); // Initially set it inactive

        return nextTetromino;
    }
}
