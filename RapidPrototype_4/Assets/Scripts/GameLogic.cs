using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public GameObject startText;
    public Text player1ScoreText;
    public Text player2ScoreText;
    public Image player1WinsText;
    public Image player2WinsText;

    [Header("Prefabs")]
    [SerializeField]
    private GameObject player1Prefab;
    [SerializeField]
    private GameObject player2Prefab;

    [Header("GameOver UI")]
    public Canvas gameOverCanvas;
    public Image player1WinsGameOver;
    public Image player2WinsGameOver;

    private bool hasStarted;

    private int Player1Score;
    private int Player2Score;

    private bool restarting;

    private GameObject player1_GO;
    private GameObject player2_GO;

    private void Start()
    {
        //DontDestroyOnLoad(this.gameObject);

        hasStarted = false;
        restarting = false;
        startText.SetActive(true);

        Player1Score = 0;
        Player2Score = 0;
        player1_GO = Instantiate(player1Prefab, player1Spawner.position, player1Spawner.rotation);
        player2_GO = Instantiate(player2Prefab, player2Spawner.position, player2Spawner.rotation);

        player1WinsText.enabled = false;
        player2WinsText.enabled = false;

        gameOverCanvas.enabled = false;
    }

    private void Update()
    {
        if (Player1Score >= maxScore || Player2Score >= maxScore)
        {
            Time.timeScale = 0;
            gameOverCanvas.enabled = true;
            if (Player1Score > Player2Score)
            {
                player1WinsGameOver.enabled = true;
                player2WinsGameOver.enabled = false;
            }
            else
            {
                player1WinsGameOver.enabled = false;
                player2WinsGameOver.enabled = true;
            }

            return;
        }

        if (!hasStarted)
        {
            Time.timeScale = 0;

            if (Input.GetKeyDown(KeyCode.Return))
            {
                hasStarted = true;
                startText.SetActive(false);
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
                player1WinsText.enabled = false;
                player2WinsText.enabled = false;
            }
        }
        else
        {
            if (water.transform.Find("WaterTop").position.y > player1_GO.transform.position.y + 1.4f)
            {
                // Player 1 death
                if (player1_GO.transform.position.y != player2_GO.transform.position.y)
                {
                    Player2Score++;
                    player2WinsText.enabled = true;
                    player1WinsText.enabled = false;
                }
                Restart();
            }
            if (water.transform.Find("WaterTop").position.y > player2_GO.transform.position.y + 1.4f)
            {
                // Player 2 death
                if (player1_GO.transform.position.y != player2_GO.transform.position.y)
                {
                    Player1Score++;
                    player1WinsText.enabled = true;
                    player2WinsText.enabled = false;
                }
                Restart();
            }
        }

        player1ScoreText.text = Player1Score.ToString();
        player2ScoreText.text = Player2Score.ToString();
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

    public void Button_GameOver_Back()
    {
        SceneManager.LoadScene(0);
    }
}
