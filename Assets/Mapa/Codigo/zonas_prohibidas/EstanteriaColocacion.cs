using UnityEngine;

public class EstanteriaColocacion : MonoBehaviour
{
    [Header("Materiales")]
    public Material materialNormal; // Material cuando se puede colocar
    public Material materialProhibido; // Material cuando no se puede colocar

    private Renderer rend;
    private bool dentroZonaProhibida = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        if (rend != null && materialNormal != null)
        {
            rend.material = materialNormal; // Inicialmente normal
        }
    }

    void Update()
    {
        // Cambiar color según si está en zona prohibida
        if (rend != null)
        {
            rend.material = dentroZonaProhibida ? materialProhibido : materialNormal;
        }
    }

    // Detecta si la estantería entra en el trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ZonaProhibida"))
        {
            dentroZonaProhibida = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ZonaProhibida"))
        {
            dentroZonaProhibida = false;
        }
    }

    // Método opcional para controlar si se puede colocar
    public bool SePuedeColocar()
    {
        return !dentroZonaProhibida;
    }
}
