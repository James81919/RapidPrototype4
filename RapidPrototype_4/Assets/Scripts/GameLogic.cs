using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {

    [Header("Values")]
    public int maxScore;

    [Header("Spawners")]
    public Transform player1Spawner;
    public Transform player2Spawner;

    [Header("GameObjects")]
    public Water water;

    [Header("UI")]
    public Text startText;
    public Text player1ScoreText;
    public Text player2ScoreText;

    [Header("Prefabs")]
    [SerializeField]
    private GameObject player1Prefab;
    [SerializeField]
    private GameObject player2Prefab;

    private bool hasStarted;

    private int Player1Score;
    private int Player2Score;

    private bool restarting;

    private GameObject player1_GO;
    private GameObject player2_GO;

    [System.NonSerialized]
    public Dictionary<string, KeyCode> keyBindings = new Dictionary<string, KeyCode>();

    private void Start()
    {
        //DontDestroyOnLoad(this.gameObject);

        InitKeyBinding();

        hasStarted = false;
        restarting = false;
        startText.enabled = true;

        Player1Score = 0;
        Player2Score = 0;
        player1_GO = Instantiate(player1Prefab, player1Spawner.position, player1Spawner.rotation);
        player2_GO = Instantiate(player2Prefab, player2Spawner.position, player2Spawner.rotation);
    }

    private void Update()
    {
        if (!hasStarted)
        {
            Time.timeScale = 0;

            if (Input.GetKeyDown(KeyCode.Return))
            {
                hasStarted = true;
                startText.enabled = false;
                Time.timeScale = 1;
                water.ShouldRaised = true;
            }
        }

        if (restarting)
        {
            if (water.transform.position == water.StartingLocation)
            {
                player1_GO = Instantiate(player1Prefab, player1Spawner.position, player1Spawner.rotation);
                player2_GO = Instantiate(player2Prefab, player2Spawner.position, player2Spawner.rotation);
                water.ShouldRaised = true;
                restarting = false;
            }
        }
        else
        {
            if (water.transform.Find("WaterTop").position.y > player1_GO.transform.position.y + 0.1f)
            {
                // Player 1 death
                if (player1_GO.transform.position.y != player2_GO.transform.position.y)
                {
                    Player2Score++;
                }
                Restart();
            }
            if (water.transform.Find("WaterTop").position.y > player2_GO.transform.position.y + 0.1f)
            {
                // Player 2 death
                if (player1_GO.transform.position.y != player2_GO.transform.position.y)
                {
                    Player1Score++;
                }
                Restart();
            }
        }

        player1ScoreText.text = Player1Score.ToString();
        player2ScoreText.text = Player2Score.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void Restart()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player1"));
        Destroy(GameObject.FindGameObjectWithTag("Player2"));

        foreach (GameObject trash in GameObject.FindGameObjectsWithTag("Trash"))
        {
            Destroy(trash);
        }

        StartCoroutine(water.ResetWaterLevel());

        restarting = true;
    }

    private void InitKeyBinding()
    {
        keyBindings.Add("Up1", KeyCode.W);
        keyBindings.Add("Down1", KeyCode.S);
        keyBindings.Add("Left1", KeyCode.A);
        keyBindings.Add("Right1", KeyCode.D);
        keyBindings.Add("Jump1", KeyCode.Space);
        keyBindings.Add("Fire1", KeyCode.F);
        keyBindings.Add("AltFire1", KeyCode.G);

        keyBindings.Add("Up2", KeyCode.UpArrow);
        keyBindings.Add("Down2", KeyCode.DownArrow);
        keyBindings.Add("Left2", KeyCode.LeftArrow);
        keyBindings.Add("Right2", KeyCode.RightArrow);
        keyBindings.Add("Jump2", KeyCode.Keypad0);
        keyBindings.Add("Fire2", KeyCode.KeypadPeriod);
        keyBindings.Add("AltFire2", KeyCode.Keypad1);
    }
}
