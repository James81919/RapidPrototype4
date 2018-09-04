using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseReactor : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody m_rigidBody;

    [Range(0.1f, 1.0f)]
    public float timeBeforePulse;

    public float reactionForceHor;
    public float reactionForceVer;

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
        yield return new WaitForSeconds(timeBeforePulse);

        // Get the direction of the other object thats hitting this object
        Vector3 pulseDirection = (this.transform.position - _otherPos).normalized;

        // Apply some up force as well
        m_rigidBody.AddForce(Vector3.up * reactionForceVer, ForceMode.Impulse);

        // Apply the pulse force to the object
        m_rigidBody.AddForce(pulseDirection * reactionForceHor, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision _otherCollider)
    {
        if (_otherCollider.gameObject.tag == "Trash")
        {
            GetPulsed(_otherCollider.transform.position);
        }
    }
}
