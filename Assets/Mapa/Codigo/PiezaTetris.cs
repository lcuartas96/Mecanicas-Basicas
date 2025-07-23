// Script 1: PiezaTetris.cs - Componente principal para las piezas
using UnityEngine;
using System.Collections.Generic;

public class PiezaTetris : MonoBehaviour
{
    [Header("Configuración de la Pieza")]
    public string nombrePieza; // "tuvo" o "parte"
    public bool estaEnsamblada = false;

    [Header("Puntos de Conexión")]
    public List<PuntoConexion> puntosConexion = new List<PuntoConexion>();

    [Header("Configuración de Movimiento")]
    public float distanciaDeteccion = 2f;
    public float velocidadMovimiento = 5f;
    public LayerMask capaPiezas = 1;

    private bool estaMoviendo = false;
    private Vector3 posicionObjetivo;
    private PiezaTetris piezaObjetivo;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }

        // Crear puntos de conexión si no existen
        if (puntosConexion.Count == 0)
        {
            CrearPuntosConexionAutomaticos();
        }
    }

    void Update()
    {
        if (!estaEnsamblada)
        {
            BuscarPiezasCercanas();
        }

        if (estaMoviendo)
        {
            MoverHaciaPosicionObjetivo();
        }
    }

    void BuscarPiezasCercanas()
    {
        Collider[] piezasCercanas = Physics.OverlapSphere(transform.position, distanciaDeteccion, capaPiezas);

        foreach (Collider col in piezasCercanas)
        {
            PiezaTetris otraPieza = col.GetComponent<PiezaTetris>();

            if (otraPieza != null && otraPieza != this && !otraPieza.estaEnsamblada)
            {
                // Verificar si es una pieza compatible
                if (PuedeConectarCon(otraPieza))
                {
                    IniciarEnsamblaje(otraPieza);
                    break;
                }
            }
        }
    }

    bool PuedeConectarCon(PiezaTetris otraPieza)
    {
        // Lógica para determinar si las piezas pueden conectarse
        if (nombrePieza == "tuvo" && otraPieza.nombrePieza == "tuvo")
            return true;
        if (nombrePieza == "parte" && otraPieza.nombrePieza == "parte")
            return true;
        if ((nombrePieza == "tuvo" && otraPieza.nombrePieza == "parte") ||
            (nombrePieza == "parte" && otraPieza.nombrePieza == "tuvo"))
            return true;

        return false;
    }

    void IniciarEnsamblaje(PiezaTetris otraPieza)
    {
        piezaObjetivo = otraPieza;

        // Encontrar el mejor punto de conexión
        PuntoConexion mejorPunto = EncontrarMejorPuntoConexion(otraPieza);

        if (mejorPunto != null)
        {
            posicionObjetivo = mejorPunto.transform.position;
            estaMoviendo = true;

            // Desactivar física durante el movimiento
            if (rb != null)
            {
                rb.isKinematic = true;
            }
        }
    }

    PuntoConexion EncontrarMejorPuntoConexion(PiezaTetris otraPieza)
    {
        float menorDistancia = float.MaxValue;
        PuntoConexion mejorPunto = null;

        foreach (PuntoConexion punto in otraPieza.puntosConexion)
        {
            if (!punto.estaOcupado)
            {
                float distancia = Vector3.Distance(transform.position, punto.transform.position);
                if (distancia < menorDistancia)
                {
                    menorDistancia = distancia;
                    mejorPunto = punto;
                }
            }
        }

        return mejorPunto;
    }

    void MoverHaciaPosicionObjetivo()
    {
        transform.position = Vector3.MoveTowards(transform.position, posicionObjetivo, velocidadMovimiento * Time.deltaTime);

        if (Vector3.Distance(transform.position, posicionObjetivo) < 0.1f)
        {
            // Llegó al destino
            CompletarEnsamblaje();
        }
    }

    void CompletarEnsamblaje()
    {
        estaMoviendo = false;
        estaEnsamblada = true;

        if (piezaObjetivo != null)
        {
            piezaObjetivo.estaEnsamblada = true;

            // Crear conexión fija
            FixedJoint joint = gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = piezaObjetivo.GetComponent<Rigidbody>();

            // Marcar puntos de conexión como ocupados
            PuntoConexion puntoUsado = EncontrarMejorPuntoConexion(piezaObjetivo);
            if (puntoUsado != null)
            {
                puntoUsado.estaOcupado = true;
            }
        }

        // Reactivar física
        if (rb != null)
        {
            rb.isKinematic = false;
        }

        Debug.Log($"{nombrePieza} se ensambló correctamente!");
    }

    void CrearPuntosConexionAutomaticos()
    {
        // Crear puntos de conexión en los extremos del collider
        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            Bounds bounds = col.bounds;

            // Crear puntos en los extremos principales
            Vector3[] posiciones = {
                new Vector3(bounds.min.x, bounds.center.y, bounds.center.z), // Izquierda
                new Vector3(bounds.max.x, bounds.center.y, bounds.center.z), // Derecha
                new Vector3(bounds.center.x, bounds.min.y, bounds.center.z), // Abajo
                new Vector3(bounds.center.x, bounds.max.y, bounds.center.z), // Arriba
                new Vector3(bounds.center.x, bounds.center.y, bounds.min.z), // Atrás
                new Vector3(bounds.center.x, bounds.center.y, bounds.max.z)  // Adelante
            };

            for (int i = 0; i < posiciones.Length; i++)
            {
                GameObject puntoObj = new GameObject($"PuntoConexion_{i}");
                puntoObj.transform.SetParent(transform);
                puntoObj.transform.position = posiciones[i];

                PuntoConexion punto = puntoObj.AddComponent<PuntoConexion>();
                puntosConexion.Add(punto);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Dibujar área de detección
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanciaDeteccion);

        // Dibujar puntos de conexión
        Gizmos.color = Color.red;
        foreach (PuntoConexion punto in puntosConexion)
        {
            if (punto != null)
            {
                Gizmos.DrawWireSphere(punto.transform.position, 0.2f);
            }
        }
    }
}