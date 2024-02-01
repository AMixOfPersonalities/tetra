using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Scene4 - Game Menu");
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("Scene11 - SinglePlayer");
    }
}
