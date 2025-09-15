/*using System.Collections;
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
*/
/*
using UnityEngine;

public class MontacargasController_dos : MonoBehaviour
{
    public Transform asiento; // Punto de referencia para salir
    private GameObject jugador;
    private MonoBehaviour scriptMovimientoMontacargas;
    private MonoBehaviour scriptMovimientoJugador;
    private CamaraControl camaraControl;

    // Punto de cámara dentro del prefab
    private Transform posicionCamaraMontacargas;

    private bool conduciendo = false;
    private const float distanciaMinima = 3f;

    void Start()
    {
        // Referencias dinámicas
        jugador = GameObject.FindGameObjectWithTag("Player");
        camaraControl = FindObjectOfType<CamaraControl>();

        // Busca el hijo llamado "CamaraMontacargasPos" en el prefab
        posicionCamaraMontacargas = transform.Find("CamaraMontacargasPos");

        if (jugador != null)
            scriptMovimientoJugador = jugador.GetComponent<MonoBehaviour>();

        scriptMovimientoMontacargas = GetComponent<MonoBehaviour>();

        if (scriptMovimientoMontacargas != null)
            scriptMovimientoMontacargas.enabled = false;
    }

    void Update()
    {
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
            scriptMovimientoMontacargas.enabled = true;

        // Pasar referencia de cámara al CamaraControl
        if (camaraControl != null && posicionCamaraMontacargas != null)
        {
            camaraControl.posicionMontacargas = posicionCamaraMontacargas;
            camaraControl.modoMontacargas = true;
            camaraControl.modoSeguir = false;
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
            scriptMovimientoJugador.enabled = true;

        // Desactivar control del montacargas
        if (scriptMovimientoMontacargas != null)
            scriptMovimientoMontacargas.enabled = false;

        // Volver cámara al jugador
        if (camaraControl != null)
        {
            camaraControl.modoMontacargas = false;
            camaraControl.modoSeguir = true;
        }

        conduciendo = false;
    }
}
*/
using UnityEngine;

public class MontacargasController_dos : MonoBehaviour
{
    [Header("Referencias")]
    public Transform asiento; // Punto de referencia para salir
    private GameObject jugador;
    private MonoBehaviour scriptMovimientoMontacargas;
    private MonoBehaviour scriptMovimientoJugador;
    private CamaraControl camaraControl;

    [Header("Cámara Montacargas")]
    public Camera camaraMontacargas; // ?? Cámara dentro del prefab

    private bool conduciendo = false;
    private const float distanciaMinima = 3f;

    void Start()
    {
        // Referencias dinámicas
        jugador = GameObject.FindGameObjectWithTag("Player");
        camaraControl = FindObjectOfType<CamaraControl>();

        if (jugador != null)
            scriptMovimientoJugador = jugador.GetComponent<MonoBehaviour>();

        scriptMovimientoMontacargas = GetComponent<MonoBehaviour>();

        if (scriptMovimientoMontacargas != null)
            scriptMovimientoMontacargas.enabled = false;

        // Asegurar que la cámara del montacargas esté apagada al inicio
        if (camaraMontacargas != null)
            camaraMontacargas.gameObject.SetActive(false);
    }

    void Update()
    {
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
            scriptMovimientoMontacargas.enabled = true;

        // Cambiar cámaras
        if (camaraControl != null)
            camaraControl.gameObject.SetActive(false); // apagar cámara principal
        if (camaraMontacargas != null)
            camaraMontacargas.gameObject.SetActive(true); // encender cámara del montacargas

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
            scriptMovimientoJugador.enabled = true;

        // Desactivar control montacargas
        if (scriptMovimientoMontacargas != null)
            scriptMovimientoMontacargas.enabled = false;

        // Cambiar cámaras
        if (camaraMontacargas != null)
            camaraMontacargas.gameObject.SetActive(false); // apagar cámara montacargas
        if (camaraControl != null)
            camaraControl.gameObject.SetActive(true); // encender cámara principal

        conduciendo = false;
    }
}
