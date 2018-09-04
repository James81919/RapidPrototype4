using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveTrash : MonoBehaviour {

    bool isgrounded = false;

    public GameObject effect;

    void boom() {
        GameObject wave = Instantiate(effect, this.transform.position, Quaternion.identity) as GameObject;
        Destroy(this.gameObject);
    }

    void FixedUpdate()
    {
        if (isgrounded) {
            Invoke("boom", 2f);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        isgrounded = true;
    }

}
