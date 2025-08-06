using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton_duplicar_estanteria : MonoBehaviour
{
    public GameObject[] pisos;
    [Range(0, 9)] // Un rango de 0 a 9 estanterías
    public int altura; // Altura deseada

    // Método que activa las estanterías según la altura
    public void AplicarAltura()
    {
        for (int i = 0; i < pisos.Length; i++)
        {
            pisos[i].SetActive(i < altura);
        }
    }
}
