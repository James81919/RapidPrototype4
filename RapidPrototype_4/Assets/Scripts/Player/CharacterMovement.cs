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

    private CharacterController m_controller;
    [SerializeField]
    private Vector3 m_velocity;
    private Transform m_groundChecker;
    public float GroundCheck = 2;
    public Vector2 ProjectileOffset;

    private void Awake()
    {
        m_controller = GetComponent<CharacterController>();
        m_groundChecker = transform.GetChild(0);
    }


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
        bool grounded = false;
        Vector3 currentPos = this.transform.position;

        RaycastHit2D hit = Physics2D.Raycast(currentPos, Vector2.down, GroundCheck);
        if (hit.collider != null)
        {
            grounded = true;
        }
        return grounded;
    }

    void Update ()
    {
        // Check if player is on ground


        // Process Move
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        m_controller.Move(move * Time.deltaTime * MovementSpeed);
        if (move != Vector3.zero)
            transform.forward = move;

        // Process Jump
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            m_velocity.y += Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y);

        // Process Gravity
        m_velocity.y += Physics.gravity.y * Time.deltaTime;

        // Process Drag
        m_velocity.x /= 1 + Drag.x * Time.deltaTime;
        m_velocity.y /= 1 + Drag.y * Time.deltaTime;
        m_velocity.z /= 1 + Drag.z * Time.deltaTime;

        // Process final translate
        m_controller.Move(m_velocity * Time.deltaTime);
    }
}
