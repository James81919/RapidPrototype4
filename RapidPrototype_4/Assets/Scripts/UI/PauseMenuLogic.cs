using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuLogic : MonoBehaviour {

    public GameObject pauseMenu;
    public GameObject settingsMenu;

    private Canvas thisCanvas;

    [Header("Keybindings")]
    public Text P1UpText;
    public Text P1DownText, P1LeftText, P1RightText, P1JumpText, P1FireText, P1AltFireText;
    public Text P2UpText, P2DownText, P2LeftText, P2RightText, P2JumpText, P2FireText, P2AltFireText;

    private GameObject currentKey;

    private KeyBinding keybinder;

    private Color32 normalButtonColor = new Color32(255, 255, 255, 255);
    private Color32 selectedButtonColor = new Color32(239, 116, 36, 255);

    private void Start()
    {
        keybinder = GameObject.FindGameObjectWithTag("GameController").GetComponent<KeyBinding>();
    }

    void Awake()
    {
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);
        thisCanvas = GetComponent<Canvas>();
        thisCanvas.enabled = false;
    }

    void Update()
    {
        if (P1UpText.text == "Button")
        {
            P1UpText.text = keybinder.keys["Up1"].ToString();
            P1DownText.text = keybinder.keys["Down1"].ToString();
            P1LeftText.text = keybinder.keys["Left1"].ToString();
            P1RightText.text = keybinder.keys["Right1"].ToString();
            P1JumpText.text = keybinder.keys["Jump1"].ToString();
            P1FireText.text = keybinder.keys["Fire1"].ToString();
            P1AltFireText.text = keybinder.keys["AltFire1"].ToString();

            P2UpText.text = keybinder.keys["Up2"].ToString();
            P2DownText.text = keybinder.keys["Down2"].ToString();
            P2LeftText.text = keybinder.keys["Left2"].ToString();
            P2RightText.text = keybinder.keys["Right2"].ToString();
            P2JumpText.text = keybinder.keys["Jump2"].ToString();
            P2FireText.text = keybinder.keys["Fire2"].ToString();
            P2AltFireText.text = keybinder.keys["AltFire2"].ToString();
        }

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
                if (settingsMenu.activeSelf)
                {
                    settingsMenu.SetActive(false);
                    pauseMenu.SetActive(true);
                }
                else
                {
                    thisCanvas.enabled = false;
                    Time.timeScale = 1;
                }
            }
        }
    }

    private void OnGUI()
    {
        if (currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                keybinder.keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                currentKey.GetComponent<Image>().color = normalButtonColor;
                currentKey = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        if (currentKey != null)
        {
            currentKey.GetComponent<Image>().color = normalButtonColor;
        }

        currentKey = clicked;
        currentKey.GetComponent<Image>().color = selectedButtonColor;
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
        SceneManager.LoadScene(0);
    }

    public void Button_Pause_QuitToDesktop()
    {
        Application.Quit();
    }
}
