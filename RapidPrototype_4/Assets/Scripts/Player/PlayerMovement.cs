using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	void FixedUpdate ()
    {
        float horizontalSpeed;

        if (rgb.velocity.y != 0)
        {
            isGrounded = false;
        }
        else
        {
            isGrounded = true;
        }

        switch(playerNum)
        {
            case 1:
                horizontalSpeed = Input.GetAxis("Horizontal") * movementSpeed;
                rgb.velocity = new Vector3(horizontalSpeed, rgb.velocity.y, rgb.velocity.z);
                if (Input.GetKey(KeyCode.Space) && isGrounded)
                {
                    rgb.AddForce(Vector3.up * jumpHeight);
                }
                break;
            case 2:
                horizontalSpeed = Input.GetAxis("Horizontal2") * movementSpeed;
                rgb.velocity = new Vector3(horizontalSpeed, rgb.velocity.y, rgb.velocity.z);
                if (Input.GetKey(KeyCode.Keypad0) && isGrounded)
                {
                    rgb.AddForce(Vector3.up * jumpHeight);
                }
                break;
            default:
                Debug.LogError("There is no player " + playerNum + "! Please enter a correct player number!");
                break;
        }
	}
}
