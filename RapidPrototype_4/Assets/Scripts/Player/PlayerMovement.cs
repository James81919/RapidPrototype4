using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public int playerNum;
    public PhysicMaterial nonstick;
    public PhysicMaterial stick;
    public float movementSpeed;
    public float jumpHeight;
    public bool ground;
    private Rigidbody rgb;
    public float GroundCheck = 1;
    public Vector2 ProjectileOffset;

    private KeyBinding keyBinder;

    Vector3 GetProjectilePosition()
    {
        Vector3 currentPos = this.transform.position;
        Vector3 scale = this.transform.localScale;
        Vector3 offset = new Vector3(ProjectileOffset.x * scale.x, ProjectileOffset.y, 0);
        Vector3 projOffset = currentPos + offset;
        return projOffset;
    }

    void OnDrawGizmos()
    {
        Vector3 currentPos = this.transform.position;
        Vector3 groundCheckPos = currentPos + Vector3.down * GroundCheck;
        Gizmos.DrawLine(currentPos, groundCheckPos);

        Vector3 projOffset = GetProjectilePosition();
        Gizmos.DrawWireSphere(projOffset, 0.1f);
    }
    bool IsGrounded()
    {
        this.GetComponent<CapsuleCollider>().material = nonstick;
        bool grounded = false;
        Vector3 currentPos = this.transform.position;
        RaycastHit[] hit = Physics.RaycastAll(currentPos, Vector3.down);
        int otherplayer;
        if (playerNum == 1) {
            otherplayer = 2;
        }
        else
        {
            otherplayer = 1;
        }
        
        foreach (var h in hit)
        {
            if (h.collider.tag == "Ground" && h.distance <= 1 || h.collider.tag == "Trash" && h.distance <= 1 || h.collider.tag == "Player"+(otherplayer) && h.distance <= 1)
            {
                this.GetComponent<CapsuleCollider>().material = stick;
                grounded = true;
            }
        }
        return grounded;
    }


    void Start()
    {
        rgb = GetComponent<Rigidbody>();
        keyBinder = GameObject.FindGameObjectWithTag("GameController").GetComponent<KeyBinding>();
    }

	void FixedUpdate ()
    {
        float horizontalInput = 0;
        ground = IsGrounded();
        switch (playerNum)
        {
            case 1:
                // Moving
                horizontalInput = Input.GetAxis("Horizontal") * movementSpeed;

                // Jumping
                if (Input.GetKeyDown(keyBinder.keys["Jump1"]) && IsGrounded())
                {
                    rgb.AddForce(0.0f, jumpHeight * 1.0f, 0.0f, ForceMode.Impulse);
                    //rgb.velocity = new Vector3(rgb.velocity.x, jumpHeight, rgb.velocity.z);
                    //isGrounded = false;
                }

                break;

            case 2:
                // Moving
                horizontalInput = Input.GetAxis("Horizontal2") * movementSpeed;

                // Jumping
                if (Input.GetKeyDown(keyBinder.keys["Jump2"]) && IsGrounded())
                {
                    rgb.AddForce(0.0f, jumpHeight * 1.0f, 0.0f, ForceMode.Impulse);
                    //rgb.velocity = new Vector3(rgb.velocity.x, jumpHeight, rgb.velocity.z);
                    //isGrounded = false;
                }

                break;

            default:
                Debug.LogError("There is no player " + playerNum + "! Please enter a correct player number!");
                break;
        }

        if (horizontalInput != 0 &&
            (rgb.velocity.x < movementSpeed || rgb.velocity.x > -movementSpeed))
        {
            //rgb.AddForce(horizontalSpeed, rgb.velocity.y, rgb.velocity.z, ForceMode.Force);
            rgb.velocity = new Vector3(horizontalInput, rgb.velocity.y, rgb.velocity.z);
        }

        // Aplly extra gravity on falling to create realistic effect
        if (!IsGrounded() && rgb.velocity.y < 0)
        {
            rgb.AddForce(Physics.gravity, ForceMode.Acceleration);
        }

        // Rotate player
        if (horizontalInput >= 0)
        {
            transform.eulerAngles = new Vector3(0, -90, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
        }

        //Check wall collision
        //RaycastHit hit;
        //if (rgb.SweepTest(rgb.velocity, out hit, rgb.velocity.magnitude * Time.deltaTime))
        //{
        //    rgb.velocity = new Vector3(0, rgb.velocity.y, 0);
        //}
    }


}
