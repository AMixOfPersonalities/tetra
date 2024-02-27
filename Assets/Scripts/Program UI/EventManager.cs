using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    [SerializeField] public string[] options;

    public void Button(int index)
    {
        if (index >= 0 && index < options.Length)
        {
            SceneManager.LoadScene(options[index]);
        }
        else
        {
            Debug.LogError("Index out of range!");
        }
    }
}