using UnityEngine;

public class MontacargasSpawner : MonoBehaviour
{
    public GameObject prefabMontacargas; // Prefab del montacargas
    public Transform spawnPoint;         // Punto donde aparecerá el montacargas
    public GameObject jugador;           // Referencia al jugador
    public MonoBehaviour scriptJugador;  // Script de movimiento del jugador
    public CamaraControl camaraControl;  // Script de cámara
    public Transform camaraJugador;      // Punto de referencia cámara jugador

    private GameObject montacargasActual;

    public void CrearMontacargas()
    {
        if (montacargasActual == null) // Para evitar duplicados
        {
            montacargasActual = Instantiate(prefabMontacargas, spawnPoint.position, spawnPoint.rotation);

            // Asignar referencias al script MontacargasController del prefab
            MontacargasController controller = montacargasActual.GetComponent<MontacargasController>();
            controller.jugador = jugador;
            controller.scriptMovimientoJugador = scriptJugador;
            controller.camaraControl = camaraControl;
            controller.camaraJugador = camaraJugador;

            // El asiento puedes encontrarlo dentro del prefab:
            controller.asiento = montacargasActual.transform.Find("Asiento"); // ?? asegúrate que en el prefab haya un objeto hijo llamado "Asiento"

            // El script de movimiento propio del montacargas también está dentro del prefab:
            controller.scriptMovimientoMontacargas = montacargasActual.GetComponent<Movimientos_Montacarga>();

        }
    }
}
