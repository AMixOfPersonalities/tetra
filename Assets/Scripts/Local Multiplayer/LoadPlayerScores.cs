using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LoadPlayerScores : MonoBehaviour
{
    public TextMeshProUGUI Score1; 
    public TextMeshProUGUI Score2;
    public TextMeshProUGUI Tagline;

    void Start()
    {
        string Player1 = PlayerPrefs.GetString("Player1Score"); // Retrieve the saved value
        int Player1Value = int.Parse(Player1);
        Debug.Log("Player 1 Score:" + Player1);
        Score1.text = Player1; // Assign the loaded value to the input field
        string Player2 = PlayerPrefs.GetString("Player2Score");
        int Player2Value = int.Parse(Player2);
        Debug.Log("Player 2 Score:" + Player2);
        Score2.text = Player2;
        if (Player1Value > Player2Value)
        {
            Tagline.text = "PLAYER 2 IS THE WINNER!";
        }
        else if (Player1Value == Player2Value)
        {
            Tagline.text = "ITS A TIE";
        }
        else
        {
            Tagline.text = "PLAYER 1 IS THE WINNER!";
        }
    }
}
