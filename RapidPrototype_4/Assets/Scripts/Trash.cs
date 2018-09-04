using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    [SerializeField]
    private bool m_hasPower;

    public bool HasPower
    {
        get { return m_hasPower; }
        set { m_hasPower = value; }
    }

    private void Start()
    {
        m_hasPower = true;
    }

    private void OnCollisionEnter(Collision _otherCollider)
    {
        m_hasPower = false;
    }
}
