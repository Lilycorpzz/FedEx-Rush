using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ControlsMenu()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
