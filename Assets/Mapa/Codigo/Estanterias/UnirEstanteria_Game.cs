using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnirEstanteria_Game : MonoBehaviour
{
    public GameObject snapEstanteria;

    public void Asociar(Transform Estanteria_2)
    {
        Estanteria_2.parent = snapEstanteria.transform;
        Estanteria_2.localPosition = Vector3.zero;
    }
}

/*using UnityEngine;

public class UnirEstanteria_Game : MonoBehaviour
{
    public GameObject snapEstanteria; // referencia al mismo objeto SnapPoint

    public void Asociar(Transform estanteria)
    {
        estanteria.position = snapEstanteria.transform.position;
        estanteria.rotation = snapEstanteria.transform.rotation;
    }
}*/

