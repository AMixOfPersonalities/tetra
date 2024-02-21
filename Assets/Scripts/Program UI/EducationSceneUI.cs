using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EducationSceneUI : MonoBehaviour
{
    public bool TheBasicsClicked = false;
    public Canvas Arrows;
    public void BackButton()
    {
        SceneManager.LoadScene("Scene4 - Game Menu");
    }

    public void TheBasicsButton() {
        TheBasicsClicked = true;
        Destroy(Arrows);
        // Save boolean using PlayerPrefs
        PlayerPrefs.SetInt("Basics", TheBasicsClicked ? 1 : 0);
        SceneManager.LoadScene("Scene13 - The Basics");

    }

}
