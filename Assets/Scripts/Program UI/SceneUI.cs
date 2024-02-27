using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUI : MonoBehaviour
{
    public bool TheBasicsClicked = false;
    public Canvas Arrows;
    public void BackButton()
    {
        SceneManager.LoadScene("Scene4 - Game Menu");
    }

    public void TheBasicsButton() {
        TheBasicsClicked = true;
        // Save boolean using PlayerPrefs
        PlayerPrefs.SetInt("Basics", TheBasicsClicked ? 1 : 0);
        Destroy(Arrows);
        SceneManager.LoadScene("Scene13 - The");

    }

}
