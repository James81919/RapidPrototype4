using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuLogic : MonoBehaviour {

    public GameObject pauseMenu;
    public GameObject settingsMenu;

    private Canvas thisCanvas;

    void Awake()
    {
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);
        thisCanvas = GetComponent<Canvas>();
        thisCanvas.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (thisCanvas.enabled == false)
            {
                thisCanvas.enabled = true;
                pauseMenu.SetActive(true);
                settingsMenu.SetActive(false);
                Time.timeScale = 0;
            }
            else
            {
                thisCanvas.enabled = false;
                Time.timeScale = 1;
            }
        }
    }

    public void Button_Pause_Resume()
    {
        thisCanvas.enabled = false;
        Time.timeScale = 1;
    }

    public void Button_Pause_Settings()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void Button_Pause_Quit()
    {

    }

    public void Button_Pause_QuitToDesktop()
    {
        Application.Quit();
    }
}
