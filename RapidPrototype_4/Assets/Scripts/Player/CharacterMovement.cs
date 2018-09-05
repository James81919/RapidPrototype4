using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float MovementSpeed = 5f;
    public float JumpHeight = 2f;
    public float DistanceToGround = 0.5f;
    public Vector3 Drag;
    public bool IsGround;
    public Transform thisTrans;

    private CharacterController m_controller;
    [SerializeField]
    private Vector3 m_velocity;
    private Transform m_groundChecker;


    private void Awake()
    {
        m_controller = GetComponent<CharacterController>();
        m_groundChecker = transform.GetChild(0);
    }

	void Update ()
    {
        // Check if player is on ground
        //Debug.Log(thisTrans.position);
        Ray ray = new Ray(transform.position, Vector3.down);
        Debug.DrawRay(transform.position, Vector3.down * DistanceToGround, Color.green, 0.0f, false);

        IsGround = Physics.Raycast(ray, DistanceToGround);
        if (IsGround && m_velocity.y < 0)
        {
            m_velocity.y = 0f;
        }

        // Process Move
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        m_controller.Move(move * Time.deltaTime * MovementSpeed);
        if (move != Vector3.zero)
            transform.forward = move;

        // Process Jump
        if (Input.GetKeyDown(KeyCode.Space) && IsGround)
            m_velocity.y += Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y);

        // Process Gravity
        m_velocity.y += Physics.gravity.y * Time.deltaTime;

        // Process Drag
        m_velocity.x /= 1 + Drag.x * Time.deltaTime;
        m_velocity.y /= 1 + Drag.y * Time.deltaTime;
        //m_velocity.z /= 1 + Drag.z * Time.deltaTime;

        // Process final translate
        m_controller.Move(m_velocity * Time.deltaTime);
    }

}
