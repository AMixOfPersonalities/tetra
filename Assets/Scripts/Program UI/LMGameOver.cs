using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LMGameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Scene4 - Game Menu");
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("Scene10 - Local Multiplayer Screen");
    }
}
