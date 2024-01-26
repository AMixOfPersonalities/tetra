using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MPScoreDisplay : MonoBehaviour
{
    public TMP_Text scoreText;

    void Update() { scoreText.text = "" + Manager.score; }
}
