using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private GameLogic gameManager;

    private Color32 normalButtonColor = new Color32(255, 255, 255, 255);
    private Color32 selectedButtonColor = new Color32(239, 116, 36, 255);

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameLogic>();
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
            P1UpText.text = gameManager.keyBindings["Up1"].ToString();
            P1DownText.text = gameManager.keyBindings["Down1"].ToString();
            P1LeftText.text = gameManager.keyBindings["Left1"].ToString();
            P1RightText.text = gameManager.keyBindings["Right1"].ToString();
            P1JumpText.text = gameManager.keyBindings["Jump1"].ToString();
            P1FireText.text = gameManager.keyBindings["Fire1"].ToString();
            P1AltFireText.text = gameManager.keyBindings["AltFire1"].ToString();

            P2UpText.text = gameManager.keyBindings["Up2"].ToString();
            P2DownText.text = gameManager.keyBindings["Down2"].ToString();
            P2LeftText.text = gameManager.keyBindings["Left2"].ToString();
            P2RightText.text = gameManager.keyBindings["Right2"].ToString();
            P2JumpText.text = gameManager.keyBindings["Jump2"].ToString();
            P2FireText.text = gameManager.keyBindings["Fire2"].ToString();
            P2AltFireText.text = gameManager.keyBindings["AltFire2"].ToString();
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
                gameManager.keyBindings[currentKey.name] = e.keyCode;
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

    }

    public void Button_Pause_QuitToDesktop()
    {
        Application.Quit();
    }
}
