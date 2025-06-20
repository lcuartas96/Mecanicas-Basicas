using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApiladorDeCajas : MonoBehaviour
{
    public List<GameObject> cajas;           // Lista de cajas existentes
    public int columnas = 4;
    public int filas = 4;
    public int niveles = 4;
    public Vector3 separacion = new Vector3(1.05f, 1.05f, 1.05f);  // Espaciado entre cajas
    public Vector3 origen = Vector3.zero;    // Posición base para acomodarlas

    void Start()
    {
        Organizar();
    }

    void Organizar()
    {
        int totalCajas = columnas * filas * niveles;

        if (cajas.Count < totalCajas)
        {
            Debug.LogWarning("No hay suficientes cajas para llenar la matriz 4x4x4.");
        }

        for (int i = 0; i < Mathf.Min(cajas.Count, totalCajas); i++)
        {
            int x = i % columnas;
            int z = (i / columnas) % filas;
            int y = i / (columnas * filas);

            Vector3 nuevaPos = origen + new Vector3(x * separacion.x, y * separacion.y, z * separacion.z);
            cajas[i].transform.position = nuevaPos;
        }
    }
}
