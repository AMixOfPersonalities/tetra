using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SavePlayerScores : MonoBehaviour
{
    public TextMeshProUGUI Score1;
    public TextMeshProUGUI Score2;

    public void Save()
    {
        string Player1 = Score1.text; // Get the value from the input field
        string Player2 = Score2.text;
        PlayerPrefs.SetString("Player1Score", Player1); // Save the value using PlayerPrefs
        PlayerPrefs.SetString("Player2Score", Player2);
        PlayerPrefs.Save(); // Save PlayerPrefs
    }
}
