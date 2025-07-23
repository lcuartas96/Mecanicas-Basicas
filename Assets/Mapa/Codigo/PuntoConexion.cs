// Script 2: PuntoConexion.cs - Maneja los puntos donde se pueden conectar las piezas
using UnityEngine;

public class PuntoConexion : MonoBehaviour
{
    [Header("Estado del Punto")]
    public bool estaOcupado = false;
    public string tipoConexion = "universal"; // Puede ser específico para ciertos tipos

    [Header("Detección")]
    public float radioDeteccion = 0.5f;
    public LayerMask capaPiezas = 1;

    private SphereCollider trigger;

    void Start()
    {
        // Crear trigger collider para detección
        trigger = gameObject.AddComponent<SphereCollider>();
        trigger.isTrigger = true;
        trigger.radius = radioDeteccion;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!estaOcupado)
        {
            PiezaTetris pieza = other.GetComponent<PiezaTetris>();
            if (pieza != null && !pieza.estaEnsamblada)
            {
                // Notificar que hay una pieza cerca
                Debug.Log($"Pieza {pieza.nombrePieza} detectada en punto de conexión");
            }
        }
    }

    void OnDrawGizmos()
    {
        // Visualizar el punto de conexión
        Gizmos.color = estaOcupado ? Color.red : Color.green;
        Gizmos.DrawWireSphere(transform.position, radioDeteccion);

        if (estaOcupado)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 0.1f);
        }
    }
}
