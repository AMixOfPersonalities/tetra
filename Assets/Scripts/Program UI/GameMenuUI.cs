using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuUI : MonoBehaviour
{
    public void SinglePlayerButton()
    {
        SceneManager.LoadScene("Scene11 - SinglePlayer");
    }

    public void MultiplayerButton()
    {
        SceneManager.LoadScene("Scene9 - Multiplayer Lobby");
    }

    public void EducationModeButton ()
    {
        int whichScene = PlayerPrefs.GetInt("Basics");
        if (whichScene == 1)
        {
            SceneManager.LoadScene("Scene12 - Education Screen");
        }
        else
        {
            SceneManager.LoadScene("Scene16 - Education Full Menu");
        }
    }
    public void vsComputerButton()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
