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

    private int playerNum;

    private void Start()
    {
        playerNum = GetComponent<PlayerMovement>().playerNum;
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(key))
        {
            if (playerNum == 1 && Input.GetKeyDown(KeyCode.S)
                || playerNum == 2 && Input.GetKeyDown(KeyCode.DownArrow))
            {
                GameObject trash = Instantiate(objectfire, new Vector3(0,0,0) , Quaternion.identity) as GameObject;
                trash.GetComponent<Rigidbody>().AddForce(-transform.up * firespeed);
            }
            else
            {
                GameObject trash = Instantiate(objectfire, firepoint.transform.position, Quaternion.identity) as GameObject;
                trash.GetComponent<Rigidbody>().AddForce(transform.right * firespeed);
            }

        }

    }
}
