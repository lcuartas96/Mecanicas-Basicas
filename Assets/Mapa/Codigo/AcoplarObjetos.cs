using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcoplarObjetos : MonoBehaviour
{
    public string nombreEsperado = "Tuvo"; // Nombre que debe tener el objeto para encajar
    public string nombreParte = "Parte";   // Nombre del segundo objeto

    public Transform puntoAcopleParte;     // Punto de unión para la parte extra

    private bool tuvoColocado = false;

    void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto entrante tiene el nombre correcto y no está ya acoplado
        if (!tuvoColocado && other.gameObject.name == nombreEsperado)
        {
            // Posiciona el objeto exactamente en este GameObject
            other.transform.position = transform.position;
            other.transform.rotation = transform.rotation;

            // Lo hace hijo para que se mueva junto con el tuvo (si se mueve)
            other.transform.SetParent(transform);

            tuvoColocado = true;

            Debug.Log("Tuvo acoplado correctamente.");
        }

        // Si ya está el tuvo, permite acoplar la parte extra
        if (tuvoColocado && other.gameObject.name == nombreParte)
        {
            // Posiciona la parte en el punto de acople definido
            if (puntoAcopleParte != null)
            {
                other.transform.position = puntoAcopleParte.position;
                other.transform.rotation = puntoAcopleParte.rotation;

                other.transform.SetParent(transform);

                Debug.Log("Parte acoplada como Tetris.");
            }
            else
            {
                Debug.LogWarning("No se ha asignado el punto de acople para la parte extra.");
            }
        }
    }

    void OnDrawGizmos()
    {
        // Dibuja una esfera para visualizar el punto de acople de la parte
        if (puntoAcopleParte != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(puntoAcopleParte.position, 0.05f);
        }
    }
}

