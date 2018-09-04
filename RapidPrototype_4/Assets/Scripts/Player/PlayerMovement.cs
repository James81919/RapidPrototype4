using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public int playerNum;

    public float movementSpeed;
    public float jumpHeight;

    private Rigidbody rgb;
    private bool isGrounded;

    void Start()
    {
        rgb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontalSpeed;

        switch (playerNum)
        {
            case 1:
                {
                    // Moving
                    horizontalSpeed = Input.GetAxis("Horizontal") * movementSpeed;
                    rgb.velocity = new Vector3(horizontalSpeed, rgb.velocity.y, rgb.velocity.z);

                    // Jumping
                    if (Input.GetKey(KeyCode.Space) && isGrounded)
                    {
                        rgb.velocity = new Vector3(rgb.velocity.x, jumpHeight, rgb.velocity.z);
                        isGrounded = false;
                    }
                    break;
                }
            case 2:
                {
                    // Moving
                    horizontalSpeed = Input.GetAxis("Horizontal2") * movementSpeed;
                    rgb.velocity = new Vector3(horizontalSpeed, rgb.velocity.y, rgb.velocity.z);

                    // Jumping
                    if (Input.GetKey(KeyCode.Keypad0) && isGrounded)
                    {
                        rgb.velocity = new Vector3(rgb.velocity.x, jumpHeight, rgb.velocity.z);
                        isGrounded = false;
                    }
                    break;
                }
            default:
                Debug.LogError("There is no player " + playerNum + "! Please enter a correct player number!");
                break;
        }

        // Rotate player
        if (rgb.velocity.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (rgb.velocity.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        // Check wall collision
        RaycastHit hit;
        if (rgb.SweepTest(rgb.velocity, out hit, rgb.velocity.magnitude * Time.deltaTime))
        {
            rgb.velocity = new Vector3(0, rgb.velocity.y, 0);
        }
    }

    void OnTriggerStay(Collider other)
    {
        isGrounded = true;
    }

    void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }
}
