using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MontacargasController_dos : MonoBehaviour
{

    // Referencia al asiento del montacargas.
    public Transform asiento;

    // Referencias que serán asignadas automáticamente en tiempo de ejecución.
    private GameObject jugador;
    private MonoBehaviour scriptMovimientoMontacargas;
    private MonoBehaviour scriptMovimientoJugador;
    private CamaraControl camaraControl;

    // NUEVO: La referencia para la posición de la cámara del montacargas
    public Transform posicionCamaraMontacargas;

    private bool conduciendo = false;
    private const float distanciaMinima = 3f; // Distancia para entrar al montacargas

    void Start()
    {
        // Busca y asigna las referencias dinámicamente
        jugador = GameObject.FindGameObjectWithTag("Player");
        camaraControl = FindObjectOfType<CamaraControl>();

        // Busca la posición de la cámara dentro del propio GameObject del montacargas
        // El nombre debe coincidir con el GameObject que creaste
        posicionCamaraMontacargas = transform.Find("CamaraMontacargasPos");

        if (jugador != null)
        {
            scriptMovimientoJugador = jugador.GetComponent<MonoBehaviour>();
        }

        // Asigna el script de control del montacargas
        scriptMovimientoMontacargas = GetComponent<MonoBehaviour>();

        if (scriptMovimientoMontacargas != null)
        {
            scriptMovimientoMontacargas.enabled = false;
        }
    }

    void Update()
    {
        // Verifica si el jugador y el montacargas están cerca
        if (Input.GetKeyDown(KeyCode.E) && jugador != null)
        {
            if (!conduciendo && Vector3.Distance(jugador.transform.position, transform.position) < distanciaMinima)
            {
                EntrarMontacargas();
            }
            else if (conduciendo)
            {
                SalirMontacargas();
            }
        }
    }

    void EntrarMontacargas()
    {
        // Desactivar jugador
        if (scriptMovimientoJugador != null)
        {
            scriptMovimientoJugador.enabled = false;
            jugador.SetActive(false);
        }

        // Activar control del montacargas
        if (scriptMovimientoMontacargas != null)
        {
            scriptMovimientoMontacargas.enabled = true;
        }

        // Asigna la posición de la cámara y la activa
        if (camaraControl != null && posicionCamaraMontacargas != null)
        {
            camaraControl.posicionMontacargas = posicionCamaraMontacargas;
            camaraControl.modoMontacargas = true;
        }

        conduciendo = true;
    }

    void SalirMontacargas()
    {
        // Reactivar jugador
        if (jugador != null)
        {
            jugador.SetActive(true);
            jugador.transform.position = asiento.position + transform.right * 2f;
        }
        if (scriptMovimientoJugador != null)
        {
            scriptMovimientoJugador.enabled = true;
        }

        // Desactivar control montacargas
        if (scriptMovimientoMontacargas != null)
        {
            scriptMovimientoMontacargas.enabled = false;
        }

        // Volver cámara a seguir jugador
        if (camaraControl != null)
        {
            camaraControl.modoMontacargas = false;
            camaraControl.modoSeguir = true;
        }

        conduciendo = false;
    }
}
