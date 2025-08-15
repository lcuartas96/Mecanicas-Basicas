using UnityEngine;

public class ZonaProhibidaEmpuje : MonoBehaviour
{
    [Header("Velocidad de empuje hacia afuera")]
    public float fuerzaEmpuje = 2f;

    [Header("Altura máxima donde se aplica el empuje")]
    public float alturaMaxima = 1f; // Solo empuja si está cerca del piso

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Estanteria"))
        {
            // Verificar altura
            if (other.transform.position.y <= alturaMaxima)
            {
                // Dirección de salida solo en el plano X-Z
                Vector3 direccionSalida = (other.transform.position - transform.position).normalized;
                direccionSalida.y = 0; // No cambia altura

                // Empuje horizontal
                other.transform.position += direccionSalida * fuerzaEmpuje * Time.deltaTime;
            }
        }
    }
}
