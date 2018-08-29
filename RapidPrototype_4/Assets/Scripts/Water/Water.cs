using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField]
    private Vector3 m_startingLocation;
    [SerializeField]
    private float m_raisingAmount;

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

    void Start ()
    {
        // Give the original location of the water for reset functionallity
        m_startingLocation = this.transform.position;

    }
	
	void Update ()
    {
        RaiseWaterLevel();

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine("ResetWaterLevel");
        }
    }

    void RaiseWaterLevel()
    {
        Vector3 resultVec = this.transform.position;
        resultVec.y += m_raisingAmount;

        this.transform.position = resultVec;
    }

    IEnumerator ResetWaterLevel()
    {
        Vector3 currentPosition = this.transform.position;
        while (currentPosition.y > m_startingLocation.y)
        {
            currentPosition = this.transform.position;

            yield return null;
        }
    }
}
