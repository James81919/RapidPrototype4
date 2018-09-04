using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private CharacterMovement character;


    private void Awake()
    {
        character = GetComponentInParent<CharacterMovement>();
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("mufker");
        character.IsGround = true;
    }

    private void OnTriggerExit(Collider other)
    {
        character.IsGround = false;
    }
}
