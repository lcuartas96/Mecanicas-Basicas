using UnityEngine;

public class MontacargasController : MonoBehaviour
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
        camaraPrincipal.transform.position = camaraJugador.position;
        camaraPrincipal.transform.rotation = camaraJugador.rotation;
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
    }

    void SalirMontacargas()
    {
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
}
