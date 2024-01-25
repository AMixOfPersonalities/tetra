using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginButtonUI : MonoBehaviour
{
    [SerializeField] private string LoginScreen = "Scene 2 - Login Screen";

    public void LoginButton()
    {
        SceneManager.LoadScene(1);
    }


}
