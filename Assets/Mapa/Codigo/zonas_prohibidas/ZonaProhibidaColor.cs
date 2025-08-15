using UnityEngine;

public class ZonaProhibidaColorBloqueo : MonoBehaviour
{
    [Header("Color cuando está en zona prohibida")]
    public Color colorProhibido = new Color(1f, 0f, 0f, 0.5f); // Rojo semi-transparente

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Estanteria"))
        {
            // Guardar color original
            Renderer rend = other.GetComponent<Renderer>();
            if (rend != null)
            {
                OriginalData data = other.GetComponent<OriginalData>();
                if (data == null)
                {
                    data = other.gameObject.AddComponent<OriginalData>();
                    data.originalColor = rend.material.color;
                    data.ultimaPosicionValida = other.transform.position;
                }

                // Cambiar a color prohibido
                rend.material.color = colorProhibido;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Estanteria"))
        {
            // Bloquear colocación: volver a última posición válida
            OriginalData data = other.GetComponent<OriginalData>();
            if (data != null)
            {
                other.transform.position = data.ultimaPosicionValida;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Estanteria"))
        {
            // Restaurar color original
            Renderer rend = other.GetComponent<Renderer>();
            OriginalData data = other.GetComponent<OriginalData>();
            if (rend != null && data != null)
            {
                rend.material.color = data.originalColor;
                Destroy(data); // Limpia los datos
            }
        }
    }
}

// Componente auxiliar para guardar datos originales
public class OriginalData : MonoBehaviour
{
    public Color originalColor;
    public Vector3 ultimaPosicionValida;
}
