using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPause = false;
    public GameObject pauseMenuUI;
    private float pauseVolume;

    private void Start()
    {
        pauseVolume = AudioListener.volume;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {     
        AudioListener.volume = pauseVolume;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPause = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.volume = 0f;
        gameIsPause = true;
    }
    public void LoadMenu()
    {
        AudioListener.volume = pauseVolume;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start");
    }
    public void Exit()
    {
        AudioListener.volume = pauseVolume;
        Debug.Log("Quit");
        Application.Quit();
    }
}
