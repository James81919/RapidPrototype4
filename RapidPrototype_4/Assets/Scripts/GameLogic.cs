using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;
    public Water water;

    public Text startText;

    private bool hasStarted;
    
    private PlayerMovement player1Movement;
    private PlayerMovement player2Movement;

    private void Start()
    {
        hasStarted = false;
        startText.enabled = true;

        player1Movement = player1.GetComponent<PlayerMovement>();
        player2Movement = player2.GetComponent<PlayerMovement>();
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
            player1Movement.isAlive = false;
        }
        if (water.transform.Find("WaterTop").position.y > player2.transform.position.y + 0.1f)
        {
            player2Movement.isAlive = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
