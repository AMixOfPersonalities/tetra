using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI FinalScore;

    void Start()
    {
        // Retrieve the score from PlayerPrefs
        int lastScore = PlayerPrefs.GetInt("LastScore", 0);

        // Display the score in a UI text element
        Debug.Log("Score:" + lastScore);
        FinalScore.text = "" + lastScore;
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Scene4 - Game Menu");
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("Scene11 - SinglePlayer");
    }
}
