using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Montacargas_Control : MonoBehaviour
{

    [Header("Referencias")]
    public GameObject jugador;                // El personaje jugador
    public GameObject camaraMontacargas;      // Objeto donde está la cámara del montacargas
    public Transform puntoMontar;             // Punto donde se colocará el jugador al montar

    private bool montado = false;

    void Update()
    {
        // Pulsar E para montar
        if (!montado && Input.GetKeyDown(KeyCode.E))
        {
            Montar();
        }

        // Pulsar Q para desmontar
        if (montado && Input.GetKeyDown(KeyCode.Q))
        {
            Desmontar();
        }
    }

    void Montar()
    {
        montado = true;

        // Desactivar al jugador
        jugador.SetActive(false);

        // Activar la cámara del montacargas
        camaraMontacargas.SetActive(true);

        // Opcional: mover al jugador al asiento
        jugador.transform.position = puntoMontar.position;
        jugador.transform.rotation = puntoMontar.rotation;
    }

    void Desmontar()
    {
        montado = false;

        // Activar de nuevo al jugador
        jugador.SetActive(true);

        // Desactivar la cámara del montacargas
        camaraMontacargas.SetActive(false);

        // Opcional: poner al jugador al lado del montacargas al bajarse
        Vector3 salida = puntoMontar.position + transform.right * 2f; // 2m a la derecha del montacargas
        jugador.transform.position = salida;
    }
}
