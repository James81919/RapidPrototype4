using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    [SerializeField]
    private KeyCode key;
    [SerializeField]
    private GameObject firepoint;

    [SerializeField]
    private GameObject objectfire;

    public float firespeed;

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(key))
        {
            GameObject trash = Instantiate(objectfire, firepoint.transform.position, Quaternion.identity) as GameObject;
            trash.GetComponent<Rigidbody>().AddForce(transform.up * firespeed);
            
        }

    }
}
