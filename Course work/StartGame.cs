using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void ScreenSwitching()
    {
        SceneManager.LoadScene("SpaceGame");
    }
    public void ToSettings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void Exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
