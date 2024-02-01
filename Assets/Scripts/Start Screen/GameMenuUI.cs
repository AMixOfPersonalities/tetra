using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuUI : MonoBehaviour
{
    public void SinglePlayerButton()
    {
        SceneManager.LoadScene(5);
    }

    public void MultiplayerButton()
    {
        SceneManager.LoadScene(7);
    }

    public void EducationModeButton ()
    {
        SceneManager.LoadScene(0);
    }
    public void vsComputerButton()
    {
        SceneManager.LoadScene(0);
    }
}
