using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField]
    private Vector3 m_startingLocation;
    [SerializeField]
    private float m_raisingAmount;
    [SerializeField]
    private float m_loweringMultipler;
    [SerializeField]
    private bool m_shouldRaised;

    public GameObject waterFlow1;
    public GameObject waterFlow2;

    public Vector3 StartingLocation
    { 
        get { return m_startingLocation; }
        set { m_startingLocation = value; }
    }
    public float RaisingAmount
    {
        get { return m_raisingAmount; }
        set { m_raisingAmount = value; }
    }

    public float LoweringMultipler
    {
        get { return m_loweringMultipler; }
        set { m_loweringMultipler = value; }
    }

    public bool ShouldRaised
    {
        get { return m_shouldRaised; }
        set { m_shouldRaised = value; }
    }

    void Start ()
    {
        // Give the original location of the water for reset functionallity
        m_startingLocation = this.transform.position;

        // Make sure the raising ability is disabled at the begining
        m_shouldRaised = false;
    }
	
	void Update ()
    {
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    StartCoroutine("ResetWaterLevel");
        //}

        if (m_shouldRaised)
        {
            waterFlow1.SetActive(true);
            waterFlow2.SetActive(true);
        }
        else
        {
            waterFlow1.SetActive(false);
            waterFlow2.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        RaiseWaterLevel();
    }

    void RaiseWaterLevel()
    {
        // Check if the water should be raised
        if (!m_shouldRaised) { return; }

        // Raise the water at a defined rate
        Vector3 resultVec = this.transform.position;
        resultVec.y += m_raisingAmount;
        this.transform.position = resultVec;
    }

    public IEnumerator ResetWaterLevel()
    {
        // Disable the raising ability at the begining
        m_shouldRaised = false;

        Vector3 currentPosition = this.transform.position;
        while (currentPosition.y > m_startingLocation.y)
        {
            currentPosition.y -= m_raisingAmount * m_loweringMultipler;

            this.transform.position = currentPosition;

            yield return null;
        }

        if (this.transform.position.y < m_startingLocation.y)
        {
            this.transform.position = m_startingLocation;
        }
    } 
}
