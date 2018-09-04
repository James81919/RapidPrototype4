using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public Canvas menuCanvas;
    public Canvas controlsCanvas;

	public void Button_Menu_Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Button_Menu_Controls()
    {

    }

    public void Button_Menu_QuitGame()
    {
        Application.Quit();
    }
}
