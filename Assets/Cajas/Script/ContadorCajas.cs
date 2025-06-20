/*using UnityEngine;
using TMPro;

public class ContadorCajas : MonoBehaviour
{
    public Transform[] posiciones; // Asigna aquí Posicion1, Posicion2, etc.
    public TextMeshProUGUI[] textosConteo; // Asigna textos en el mismo orden que las posiciones

    void Update()
    {
        for (int i = 0; i < posiciones.Length; i++)
        {
            int conteo = 0;

            foreach (Transform hijo in posiciones[i])
            {
                if (hijo.CompareTag("Caja"))
                {
                    conteo++;
                }
            }

            textosConteo[i].text = $"Cajas: {conteo}";
        }
    }
}
*/

using UnityEngine;
using TMPro;

public class ContadorCajas : MonoBehaviour
{
    public Transform[] posiciones; // Posiciones donde contar las cajas
    public TextMeshProUGUI[] textosConteo; // Textos correspondientes
    public float radioDeteccion = 1.0f; // Radio para detectar cajas
    public LayerMask capaCajas; // Capa donde están las cajas (opcional pero recomendado)

    void Update()
    {
        for (int i = 0; i < posiciones.Length; i++)
        {
            Collider[] colisiones = Physics.OverlapSphere(posiciones[i].position, radioDeteccion, capaCajas);
            int conteo = 0;

            foreach (var col in colisiones)
            {
                if (col.CompareTag("Caja"))
                {
                    conteo++;
                }
            }

            textosConteo[i].text = $"Cajas: {conteo}";
        }
    }

    void OnDrawGizmosSelected()
    {
        // Para ver el radio en el editor
        if (posiciones != null)
        {
            Gizmos.color = Color.yellow;
            foreach (var pos in posiciones)
            {
                if (pos != null)
                    Gizmos.DrawWireSphere(pos.position, radioDeteccion);
            }
        }
    }
}
