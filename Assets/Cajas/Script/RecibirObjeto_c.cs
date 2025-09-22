using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecibirObjeto_c : MonoBehaviour
{
    public Vector3 posicion;
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        print("esta tocando");
        if (other.tag == "Objeto")
        {
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.GetComponent<Rigidbody>().useGravity = false;
            print("debio quedar flotando");
        }
    }
}
