using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    // Called by the UI Toggle
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;

        // Optional but recommended:
        Screen.fullScreenMode = isFullScreen
            ? FullScreenMode.ExclusiveFullScreen
            : FullScreenMode.Windowed;
    }
}
