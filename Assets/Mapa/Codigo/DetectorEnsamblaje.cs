// Script 3: DetectorEnsamblaje.cs - Detecta cuando las piezas están cerca para ensamblar
using UnityEngine;

public class DetectorEnsamblaje : MonoBehaviour
{
    [Header("Configuración")]
    public float fuerzaAtraccion = 10f;
    public float distanciaMaximaAtraccion = 3f;

    void OnTriggerStay(Collider other)
    {
        PiezaTetris otraPieza = other.GetComponent<PiezaTetris>();
        PiezaTetris miPieza = GetComponentInParent<PiezaTetris>();

        if (otraPieza != null && miPieza != null && otraPieza != miPieza)
        {
            if (!otraPieza.estaEnsamblada && !miPieza.estaEnsamblada)
            {
                // Aplicar fuerza de atracción sutil
                Vector3 direccion = (transform.position - other.transform.position).normalized;
                float distancia = Vector3.Distance(transform.position, other.transform.position);

                if (distancia < distanciaMaximaAtraccion)
                {
                    Rigidbody otroRb = other.GetComponent<Rigidbody>();
                    if (otroRb != null)
                    {
                        float fuerza = fuerzaAtraccion * (1f - (distancia / distanciaMaximaAtraccion));
                        otroRb.AddForce(direccion * fuerza);
                    }
                }
            }
        }
    }
}