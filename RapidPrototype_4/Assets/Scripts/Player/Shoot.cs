using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    [SerializeField]
    private KeyCode key;
    [SerializeField]
    private GameObject firepoint;
    [SerializeField]
    private KeyCode effectfire;

    [SerializeField]
    private GameObject[] objectfire;

    [SerializeField]
    private GameObject lightning;
       
    public float firespeed;
    public float firerate;
    public float firedownrate;
    public float firelightingrate;
    float lastshot;
    float lastshotdown;
    float lastlightingshot;
    private int playerNum;
    private Vector3 firePointPos;

    private KeyBinding keyBinder;

    private void Start()
    {
        playerNum = GetComponent<PlayerMovement>().playerNum;
        firePointPos = firepoint.transform.localPosition;
        keyBinder = GameObject.FindGameObjectWithTag("GameController").GetComponent<KeyBinding>();
    }

    void Fire() {
        if(Time.time > firerate + lastshot)
        {
            int i = Random.Range(0, objectfire.Length);
            GameObject trash = Instantiate(objectfire[i], firepoint.transform.position, Quaternion.identity) as GameObject;
            trash.GetComponent<Rigidbody>().AddForce(transform.right * firespeed);
            lastshot = Time.time;
        }

    }

    void FireUp()
    {
        if (Time.time > firerate + lastshot)
        {
            int i = Random.Range(0, objectfire.Length);
            GameObject trash = Instantiate(objectfire[i], firepoint.transform.position, Quaternion.identity) as GameObject;
            trash.GetComponent<Rigidbody>().AddForce((transform.up + transform.right) * firespeed);
            lastshot = Time.time;
        }

    }

    // Update is called once per frame
    void Update ()
    {

        

        if (Input.GetKey(key))
        {
            if (playerNum == 1 && Input.GetKeyDown(keyBinder.keys["Down1"])
                || playerNum == 2 && Input.GetKey(keyBinder.keys["Down2"]))
            {
                firepoint.transform.localPosition = new Vector3(0, -1, 0);
                if (Time.time > firedownrate + lastshotdown) {
                    int i = Random.Range(0, objectfire.Length);
                    GameObject trash = Instantiate(objectfire[i], firepoint.transform.position, Quaternion.identity) as GameObject;
                    trash.GetComponent<Rigidbody>().AddForce(-transform.up * firespeed);
                    lastshotdown = Time.time;
                }
            }
            else if (playerNum == 1 && Input.GetKey(keyBinder.keys["Up1"])
                || playerNum == 2 && Input.GetKey(keyBinder.keys["Up2"]))
            {
                firepoint.transform.localPosition = new Vector3(1, 1, 0);
                FireUp();
            }
            else
            {
                firepoint.transform.localPosition = firePointPos;
                Fire();
            }

        }

        if (Input.GetKey(effectfire))
        {
            if (playerNum == 1 && Input.GetKey(keyBinder.keys["Down1"])
                || playerNum == 2 && Input.GetKey(keyBinder.keys["Down2"]))
            {
                firepoint.transform.localPosition = new Vector3(0, -1, 0);
                if (Time.time > firelightingrate + lastlightingshot) {
                    GameObject effect = Instantiate(lightning, firepoint.transform.position, Quaternion.identity) as GameObject;
                    effect.GetComponent<Rigidbody>().AddForce(-transform.up * firespeed);
                    lastlightingshot = Time.time;
                }
            }
            else if (playerNum == 1 && Input.GetKey(keyBinder.keys["Up1"])
                || playerNum == 2 && Input.GetKey(keyBinder.keys["Up2"]))
            {
                firepoint.transform.localPosition = new Vector3(1, 1, 0);
                if (Time.time > firelightingrate + lastlightingshot)
                {
                    GameObject effect = Instantiate(lightning, firepoint.transform.position, Quaternion.identity) as GameObject;
                    effect.GetComponent<Rigidbody>().AddForce((transform.up + transform.right) * firespeed);
                    lastlightingshot = Time.time;
                }
            }
            else
            {
                firepoint.transform.localPosition = firePointPos;
                if (Time.time > firelightingrate + lastlightingshot)
                {
                    GameObject effect = Instantiate(lightning, firepoint.transform.position, Quaternion.identity) as GameObject;
                    effect.GetComponent<Rigidbody>().AddForce(transform.right * firespeed);
                    lastlightingshot = Time.time;
                }
            }
        }

    }
}
