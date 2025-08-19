using UnityEngine;

public class ZonaProhibidaColor : MonoBehaviour
{
    [Header("Color cuando está en zona prohibida")]
    public Color colorProhibido = new Color(1f, 0f, 0f, 0.5f); // Rojo semi-transparente

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Estanteria"))
        {
            Renderer rend = other.GetComponent<Renderer>();
            if (rend != null)
            {
                OriginalColor almacen = other.gameObject.GetComponent<OriginalColor>();
                if (almacen == null)
                {
                    almacen = other.gameObject.AddComponent<OriginalColor>();
                    almacen.originalColor = rend.material.color;
                }

                rend.material.color = colorProhibido;
            }

            ColocacionBloqueo bloqueo = other.GetComponent<ColocacionBloqueo>();
            if (bloqueo == null)
            {
                bloqueo = other.gameObject.AddComponent<ColocacionBloqueo>();
            }
            bloqueo.enZonaProhibida = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Estanteria"))
        {
            Renderer rend = other.GetComponent<Renderer>();
            if (rend != null)
            {
                OriginalColor almacen = other.gameObject.GetComponent<OriginalColor>();
                if (almacen != null)
                {
                    rend.material.color = almacen.originalColor;
                    Destroy(almacen);
                }
            }

            ColocacionBloqueo bloqueo = other.GetComponent<ColocacionBloqueo>();
            if (bloqueo != null)
            {
                bloqueo.enZonaProhibida = false;
            }
        }
    }
}

public class OriginalColor : MonoBehaviour
{
    public Color originalColor;
}

public class ColocacionBloqueo : MonoBehaviour
{
    public bool enZonaProhibida = false;
}