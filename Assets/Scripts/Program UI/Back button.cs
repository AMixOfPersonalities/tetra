using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Backbutton : MonoBehaviour
{
    [SerializeField] public string previousScene;

    public void backButton()
    {
        SceneManager.LoadScene(previousScene);
    }

}
