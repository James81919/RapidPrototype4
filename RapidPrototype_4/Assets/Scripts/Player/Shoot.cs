using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    [SerializeField]
    private KeyCode key;
    [SerializeField]
    private GameObject firepoint;

    [SerializeField]
    private GameObject[] objectfire;

    public float firespeed;

    private int playerNum;
    private Vector3 firePointPos;

    private void Start()
    {
        playerNum = GetComponent<PlayerMovement>().playerNum;
        firePointPos = firepoint.transform.localPosition;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(key))
        {
            if (playerNum == 1 && Input.GetKey(KeyCode.S)
                || playerNum == 2 && Input.GetKey(KeyCode.DownArrow))
            {
                firepoint.transform.localPosition = new Vector3(0, -1, 0);
                int i = Random.Range(0, objectfire.Length);
                GameObject trash = Instantiate(objectfire[i], firepoint.transform.position, Quaternion.identity) as GameObject;
                trash.GetComponent<Rigidbody>().AddForce(-transform.up * firespeed);
            }
            else if (playerNum == 1 && Input.GetKey(KeyCode.W)
                || playerNum == 2 && Input.GetKey(KeyCode.UpArrow))
            {
                firepoint.transform.localPosition = new Vector3(1, 1, 0);
                int i = Random.Range(0, objectfire.Length);
                GameObject trash = Instantiate(objectfire[i], firepoint.transform.position, Quaternion.identity) as GameObject;
                trash.GetComponent<Rigidbody>().AddForce((transform.up + transform.right) * firespeed);
            }
            else
            {
                firepoint.transform.localPosition = firePointPos;
                int i = Random.Range(0, objectfire.Length);
                GameObject trash = Instantiate(objectfire[i], firepoint.transform.position, Quaternion.identity) as GameObject;
                trash.GetComponent<Rigidbody>().AddForce(transform.right * firespeed);
            }

        }

    }
}
