using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    bool isFullScreen = false;
    bool sound = true;
    public void ToMenu()
    {
        SceneManager.LoadScene("Start");
    }

    public void FullScreen()
    {
        Debug.Log("FullScreenActive");
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }
    public void Sound()
    {
        if (sound)
        {
            AudioListener.volume = 0f;
            sound = false;
        }
        else
        {
            AudioListener.volume = 1f;
            sound = true;
        }
    }
}
