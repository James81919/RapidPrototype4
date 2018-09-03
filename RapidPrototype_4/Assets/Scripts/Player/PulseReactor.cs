using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseReactor : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody m_rigidBody;

    public float reactionForce;
    public float reactionForceUp;

    private bool isWaiting;

    private void Awake()
    {
        m_rigidBody = GetComponent<Rigidbody>();
    }

    public void GetPulsed(Vector3 _otherPos)
    {
        StartCoroutine("PulseCoroutine", _otherPos);
    }

    IEnumerator PulseCoroutine(Vector3 _otherPos)
    {
        // Wait a little bit b4 pulse the object
        yield return new WaitForSeconds(1);

        // Get the direction of the other object thats hitting this object
        Vector3 pulseDirection = (this.transform.position - _otherPos);

        // Combine the direction force with a little bit of up force
        Vector3 resultForce = 
            (pulseDirection + Vector3.up * reactionForceUp).normalized * reactionForce;

        // Apply the pulse force to the object
        m_rigidBody.AddForce(resultForce, ForceMode.Impulse);
    }

}
