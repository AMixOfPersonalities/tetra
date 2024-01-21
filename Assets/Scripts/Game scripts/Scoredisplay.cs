using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using TMPro;

public class Scoredisplay : MonoBehaviour
{
    public TMP_Text scoreText;

    void Update()
    {
        scoreText.text = "" + Manager.score;
    }
}
