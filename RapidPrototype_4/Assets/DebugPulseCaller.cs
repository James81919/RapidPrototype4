using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPulseCaller : MonoBehaviour
{
    public GameObject pulseActor;
    public GameObject pulseOrigin;
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown("o"))
        {
            PulseObject();
        }
	}

    public void PulseObject()
    {
        pulseActor.GetComponent<PulseReactor>().GetPulsed(
            pulseOrigin.transform.position);
    }
}
