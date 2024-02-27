using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiplayerMenuUI : MonoBehaviour
{
    public void HostLobby()
    {

    }

    public void JoinLobby()
    {

    }
    public void LoadLocal()
    {
        SceneManager.LoadScene("Scene10 - Local Multiplayer Screen");
    }

    public void Back()
    {
        SceneManager.LoadScene("Scene4 - Game Menu");
    }

}
