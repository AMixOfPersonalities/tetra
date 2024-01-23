using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static int score = 0;
    public static int linesCleared = 0;

    public static void ResetScore()
    {
        score = 0;
    }
}
