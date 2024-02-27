using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuUI : MonoBehaviour
{

    public void LoginButton()
    {
        SceneManager.LoadScene("Scene2 - Login Screen");
    }
    public void RegisterButton()
    {
        SceneManager.LoadScene("Scene3 - Register Scene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
