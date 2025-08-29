using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MontaMorion : MonoBehaviour
{
    public Seccion[] secciones;
    [Range(0, 1)]
    public float t;
    void Update()
    {
        for (int i = 0; i < secciones.Length; i++)
        {
            secciones[i].Mover(t);
        }
    }
}


[System.Serializable]
public class Seccion
{
    public Transform grafico;
    public Vector3 posInicial;
    public Vector3 posFinal;

    public void Mover(float t)
    {
        grafico.transform.localPosition = Vector3.Lerp(posInicial, posFinal, t);
    }
}