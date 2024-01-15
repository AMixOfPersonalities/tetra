using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] tetraminos;

    public void spawnNext()
    {
        int i = Random.Range(0, tetraminos.Length);

        Instantiate(tetraminos[i],
            transform.position,
            Quaternion.identity);
    }

    void Start() { spawnNext(); }
}
