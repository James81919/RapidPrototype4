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
    private GameObject player1;
    [SerializeField]
    private GameObject player2;

    private bool hasStarted;
    
    private PlayerMovement player1Movement;
    private PlayerMovement player2Movement;

    private int Player1Score;
    private int Player2Score;

    private void Start()
    {
        //DontDestroyOnLoad(this.gameObject);

        hasStarted = false;
        startText.enabled = true;

        player1Movement = player1.GetComponent<PlayerMovement>();
        player2Movement = player2.GetComponent<PlayerMovement>();
        Player1Score = 0;
        Player2Score = 0;
        Instantiate(player1, player1Spawner.position, player1Spawner.rotation);
        Instantiate(player2, player2Spawner.position, player2Spawner.rotation);
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

        if (water.transform.Find("WaterTop").position.y > player1.transform.position.y + 0.1f)
        {
            // Player 1 death
            Player2Score++;
            Restart();
        }
        if (water.transform.Find("WaterTop").position.y > player2.transform.position.y + 0.1f)
        {
            // Player 2 death
            Player1Score++;
            Restart();
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
        Destroy(GameObject.Find("Player1"));
        Destroy(GameObject.Find("Player2"));
        water.ResetWaterLevel();
        Instantiate(player1, player1Spawner.position, player1Spawner.rotation);
        Instantiate(player2, player2Spawner.position, player2Spawner.rotation);
    }
}
