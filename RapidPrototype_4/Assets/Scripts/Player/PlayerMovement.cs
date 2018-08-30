using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public int playerNum;

    public float movementSpeed;
    public float airControlSpeed;
    public float jumpHeight;

    private Rigidbody rgb;
    private bool isGrounded;

    void Start()
    {
        rgb = GetComponent<Rigidbody>();
    }

	void FixedUpdate ()
    {
        float horizontalSpeed;

        switch(playerNum)
        {
            case 1:
                {
                    horizontalSpeed = Input.GetAxis("Horizontal") * movementSpeed;
                    rgb.velocity = new Vector3(horizontalSpeed, rgb.velocity.y, rgb.velocity.z);

                    if (Input.GetKey(KeyCode.Space) && isGrounded)
                    {
                        rgb.AddForce(Vector3.up * jumpHeight);
                    }
                    break;
                }
            case 2:
                {
                    horizontalSpeed = Input.GetAxis("Horizontal2") * movementSpeed;
                    rgb.velocity = new Vector3(horizontalSpeed, rgb.velocity.y, rgb.velocity.z);
                    if (Input.GetKey(KeyCode.Keypad0) && isGrounded)
                    {
                        rgb.AddForce(Vector3.up * jumpHeight);
                    }
                    break;
                }
            default:
                Debug.LogError("There is no player " + playerNum + "! Please enter a correct player number!");
                break;
        }

        RaycastHit hit;

        if (rgb.SweepTest(rgb.velocity, out hit, rgb.velocity.magnitude * Time.deltaTime))
        {
            rgb.velocity = new Vector3(0, rgb.velocity.y, 0);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        isGrounded = true;
    }

    void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }
}
