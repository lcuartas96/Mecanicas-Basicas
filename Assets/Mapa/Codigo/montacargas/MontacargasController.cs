using UnityEngine;

public class MontacargasController : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject jugador; // El personaje
    public Transform asiento;  // Punto de referencia del asiento
    public MonoBehaviour scriptMovimientoMontacargas; // Script de conducción
    public MonoBehaviour scriptMovimientoJugador;     // Script de movimiento jugador
    public CamaraControl camaraControl;               // 👈 Script de cámara
    public Transform camaraJugador;                   // Punto de referencia cámara jugador
    public Camera camaraMontacargas;                  // 👈 Cámara del montacargas (asignar desde prefab)

    private bool conduciendo = false;

    void Start()
    {
        // El montacargas empieza sin control ni cámara activa
        scriptMovimientoMontacargas.enabled = false;
        if (camaraMontacargas != null)
            camaraMontacargas.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!conduciendo && Vector3.Distance(jugador.transform.position, transform.position) < 3f)
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
        scriptMovimientoJugador.enabled = false;
        jugador.SetActive(false);

        // Activar control del montacargas
        scriptMovimientoMontacargas.enabled = true;

        // Cambiar cámaras
        camaraControl.gameObject.SetActive(false); // apagar cámara principal
        if (camaraMontacargas != null)
            camaraMontacargas.gameObject.SetActive(true); // encender cámara montacargas

        conduciendo = true;
    }

    void SalirMontacargas()
    {
        // Reactivar jugador
        jugador.SetActive(true);
        jugador.transform.position = asiento.position + transform.right * 2f;
        scriptMovimientoJugador.enabled = true;

        // Desactivar control montacargas
        scriptMovimientoMontacargas.enabled = false;

        // Cambiar cámaras
        if (camaraMontacargas != null)
            camaraMontacargas.gameObject.SetActive(false); // apagar cámara montacargas
        camaraControl.gameObject.SetActive(true); // encender cámara principal

        conduciendo = false;
    }
}



/*using UnityEngine;

public class MontacargasController : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject jugador; // El personaje
    public Transform asiento;  // Punto de referencia del asiento
    public MonoBehaviour scriptMovimientoMontacargas; // Script de conducción
    public MonoBehaviour scriptMovimientoJugador;     // Script de movimiento jugador
    public CamaraControl camaraControl;               // 👈 Script de cámara
    public Transform camaraJugador;                   // Punto de referencia cámara jugador

    private bool conduciendo = false;

    void Start()
    {
        // El montacargas empieza sin control
        scriptMovimientoMontacargas.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!conduciendo && Vector3.Distance(jugador.transform.position, transform.position) < 3f)
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
        scriptMovimientoJugador.enabled = false;
        jugador.SetActive(false);

        // Activar control del montacargas
        scriptMovimientoMontacargas.enabled = true;

        // Activar cámara montacargas fija
        camaraControl.modoMontacargas = true;

        conduciendo = true;
    }

    void SalirMontacargas()
    {
        // Reactivar jugador
        jugador.SetActive(true);
        jugador.transform.position = asiento.position + transform.right * 2f;
        scriptMovimientoJugador.enabled = true;

        // Desactivar control montacargas
        scriptMovimientoMontacargas.enabled = false;

        // Volver cámara a seguir jugador
        camaraControl.modoMontacargas = false;
        camaraControl.modoSeguir = true;

        conduciendo = false;
    }
}
*/



/*using UnityEngine;

public class MontacargasController : MonoBehaviour

{
    [Header("Referencias")]
    public GameObject jugador; // Arrastra aquí el jugador
    public Transform asiento; // Punto donde se sentará el jugador
    public MonoBehaviour scriptMovimientoMontacargas; // Script que controla el montacargas
    public MonoBehaviour scriptMovimientoJugador; // Script que controla al jugador
    public Camera camaraPrincipal; // La cámara principal
    public Transform camaraJugador; // Posición de la cámara del jugador
    public Transform camaraMontacargas; // Punto frontal del montacargas

    private MoverCamara moverCamara; // referencia al script de movimiento

    private bool conduciendo = false;

    void Start()
    {
        scriptMovimientoMontacargas.enabled = false;

        moverCamara = camaraPrincipal.GetComponent<MoverCamara>();

        // iniciar cámara en el jugador
        camaraPrincipal.transform.position = camaraJugador.position;
        camaraPrincipal.transform.rotation = camaraJugador.rotation;

        if (moverCamara != null)
        {
            moverCamara.posicionObjetivo = camaraJugador; // objetivo inicial
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!conduciendo && Vector3.Distance(jugador.transform.position, transform.position) < 3f)
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
        scriptMovimientoJugador.enabled = false;
        jugador.SetActive(false);

        scriptMovimientoMontacargas.enabled = true;

        // decirle al script de cámara que el objetivo es el montacargas
        if (moverCamara != null)
        {
            moverCamara.posicionObjetivo = camaraMontacargas;
        }

        conduciendo = true;
    }

    void SalirMontacargas()
    {
        jugador.SetActive(true);
        jugador.transform.position = asiento.position + transform.right * 2f;

        scriptMovimientoJugador.enabled = true;
        scriptMovimientoMontacargas.enabled = false;

        // decirle al script de cámara que el objetivo es el jugador
        if (moverCamara != null)
        {
            moverCamara.posicionObjetivo = camaraJugador;
        }

        conduciendo = false;
    }
}*/


/*
{
[Header("Referencias")]
public GameObject jugador; // Arrastra aquí el jugador
public Transform asiento; // Punto donde se sentará el jugador
public MonoBehaviour scriptMovimientoMontacargas; // Script que controla el montacargas
public MonoBehaviour scriptMovimientoJugador; // Script que controla al jugador
public Camera camaraPrincipal; // La cámara principal
public Transform camaraJugador; // Posición de la cámara del jugador
public Transform camaraMontacargas; // Posición de la cámara del montacargas

private bool conduciendo = false;

void Start()
{
    scriptMovimientoMontacargas.enabled = false;

    // Iniciar cámara en modo jugador
    camaraPrincipal.transform.SetParent(camaraJugador);

    camaraPrincipal.transform.localPosition = Vector3.zero;
    camaraPrincipal.transform.localRotation = Quaternion.identity;
}

void Update()
{
    // Entrada para entrar/salir del montacargas
    if (Input.GetKeyDown(KeyCode.E))
    {
        if (!conduciendo && Vector3.Distance(jugador.transform.position, transform.position) < 3f)
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
    // Desactivar jugador completo (desaparece)
    jugador.SetActive(false);

    // Activar control del montacargas
    scriptMovimientoMontacargas.enabled = true;

    // Colocar cámara en vista frontal fija del montacargas
    camaraPrincipal.transform.SetParent(null); // la soltamos
    camaraPrincipal.transform.position = camaraMontacargas.position;
    camaraPrincipal.transform.rotation = camaraMontacargas.rotation;

    conduciendo = true;
    /*
    // Colocar jugador en el asiento
    jugador.transform.position = asiento.position;
    jugador.transform.rotation = asiento.rotation;
    jugador.transform.SetParent(transform);

    // Desactivar movimiento del jugador
    scriptMovimientoJugador.enabled = false;

    // Activar control del montacargas
    scriptMovimientoMontacargas.enabled = true;

    // Mover cámara al montacargas
    camaraPrincipal.transform.SetParent(camaraMontacargas);
    camaraPrincipal.transform.localPosition = Vector3.zero;
    camaraPrincipal.transform.localRotation = Quaternion.identity;

    conduciendo = true;

}*/

/*
void SalirMontacargas()
{
    // Reactivar jugador y colocarlo junto al montacargas
    jugador.SetActive(true);
    jugador.transform.position = asiento.position + transform.right * 2f; // lo deja al lado al salir

    // Activar control del jugador
    scriptMovimientoJugador.enabled = true;

    // Desactivar control del montacargas
    scriptMovimientoMontacargas.enabled = false;

    // Volver cámara al jugador
    camaraPrincipal.transform.SetParent(camaraJugador);
    camaraPrincipal.transform.localPosition = Vector3.zero;
    camaraPrincipal.transform.localRotation = Quaternion.identity;

    conduciendo = false;
    /*
    // Quitar jugador del montacargas
    jugador.transform.SetParent(null);

    // Activar control del jugador
    scriptMovimientoJugador.enabled = true;

    // Desactivar control del montacargas
    scriptMovimientoMontacargas.enabled = false;

    // Mover cámara al jugador
    camaraPrincipal.transform.SetParent(camaraJugador);
    camaraPrincipal.transform.localPosition = Vector3.zero;
    camaraPrincipal.transform.localRotation = Quaternion.identity;

    conduciendo = false;
}
}*/
