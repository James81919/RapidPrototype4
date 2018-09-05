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
    public GameObject startText;
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
    }

    private void Update()
    {
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
}
