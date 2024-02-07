using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LoadPlayerScores : MonoBehaviour
{
    public TextMeshProUGUI Score1; 
    public TextMeshProUGUI Score2;

    void Start()
    {
        string Player1 = PlayerPrefs.GetString("Player1Score"); // Retrieve the saved value
        Debug.Log("Player 1 Score:" + Player1);
        Score1.text = Player1; // Assign the loaded value to the input field
        string Player2 = PlayerPrefs.GetString("Player2Score");
        Debug.Log("Player 2 Score:" + Player2);
        Score2.text = Player2;
    }
}
