using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Importante para el Slider

public class Montacargas_Pisos : MonoBehaviour
{

    public Seccion[] secciones;   // Cada tramo (Bone_primer, segundo, etc.)
    public Slider sliderT;        // Controlador UI

    void Update()
    {
        if (secciones.Length == 0) return;

        // El slider va de 0 hasta número de secciones
        float tTotal = sliderT.value * (secciones.Length - 1);

        // Sección activa
        int indice = Mathf.FloorToInt(tTotal);
        float tLocal = tTotal - indice; // Progreso solo dentro de la sección

        // Clamp por seguridad
        indice = Mathf.Clamp(indice, 0, secciones.Length - 1);

        // Mover solo la sección activa
        secciones[indice].Mover(tLocal);
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
        grafico.localPosition = Vector3.Lerp(posInicial, posFinal, t);
    }


}
