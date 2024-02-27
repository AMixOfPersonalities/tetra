using UnityEngine;
using UnityEngine.SceneManagement;

public class EducationSceneUI : MonoBehaviour
{
    public Canvas Arrows;
    public void BackButton()
    {
        SceneManager.LoadScene("Scene4 - Game Menu");
    }

    public void Openers()
    {
        SceneManager.LoadScene("Scene15 - Openers");
    }

    public void Methods()
    {
        SceneManager.LoadScene("Scene17 - Methods");
    }

    public void Mid_Game()
    {
        SceneManager.LoadScene("Scene18 - Mid Game");
    }

    public void Perf_Clear()
    {
        SceneManager.LoadScene("Scene19 - Perfect Clears");
    }

    public void SRS()
    {
        SceneManager.LoadScene("Scene20 - SRS");
    }

    public void Stacking()
    {
        SceneManager.LoadScene("Scene21 - Stacking");
    }


    public void Vocab()
    {
        SceneManager.LoadScene("Scene22 - Vocabulary");
    }
    public void TheBasicsButton()
    {
        bool TheBasicsClicked = true;
        Destroy(Arrows);
        // Save boolean using PlayerPrefs
        PlayerPrefs.SetInt("Basics", TheBasicsClicked ? 1 : 0);
        SceneManager.LoadScene("Scene13 - The Basics");
        PlayerPrefs.Save();


    }

}
