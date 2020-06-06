using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public void ScreenSwitching()
    {
        SceneManager.LoadScene("SpaceGame");
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("Start");
    }
    public void Exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
