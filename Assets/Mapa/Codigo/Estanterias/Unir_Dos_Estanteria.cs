using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unir_Dos_Estanteria : MonoBehaviour
{

   
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entré al trigger con: " + other.name);
        if (other.CompareTag("Unir"))
        {
            UnirEstanteria_Game b = other.GetComponent<UnirEstanteria_Game>();
            b.Asociar(transform);
        }
    }
}


/*using UnityEngine;

public class Unir_Dos_Estanteria : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Unir"))
        {
            UnirEstanteria_Game snap = other.GetComponent<UnirEstanteria_Game>();
            if (snap != null)
            {
                snap.Asociar(transform.parent);
                // usamos transform.parent porque el detector es hijo de la estantería
            }
        }
    }
}*/
