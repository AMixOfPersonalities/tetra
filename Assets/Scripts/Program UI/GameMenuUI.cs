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
        SceneManager.LoadScene(0);
    }
    public void vsComputerButton()
    {
        SceneManager.LoadScene(0);
    }
}
