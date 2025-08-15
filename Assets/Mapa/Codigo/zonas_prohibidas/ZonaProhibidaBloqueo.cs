using UnityEngine;

public class ZonaProhibidaBloqueo : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Estanteria"))
        {
            // Desactiva la estantería
            other.gameObject.SetActive(false);

            // Mensaje en consola (opcional)
            Debug.Log("❌ Estantería eliminada o no colocada: zona prohibida.");
        }
    }
}
