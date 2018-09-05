using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrash : MonoBehaviour {

    public GameObject orginobject;

    void delete()
    {
        Destroy(orginobject.gameObject);
    }

    void FixedUpdate()
    {
        Invoke("delete", 1f);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Trash")
        {
            Destroy(other.gameObject);

        }
    }
}
