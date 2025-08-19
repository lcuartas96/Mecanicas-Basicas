using UnityEngine;

public class ColocarEstanteria : MonoBehaviour
{
    [Header("Referencia a la estantería actual que estoy moviendo")]
    public GameObject estanteriaActual;

    [Header("Tecla para colocar la estantería")]
    public KeyCode teclaColocar = KeyCode.Mouse0; // Click izquierdo

    void Update()
    {
        if (estanteriaActual == null) return;

        if (Input.GetKeyDown(teclaColocar))
        {
            ColocacionBloqueo bloqueo = estanteriaActual.GetComponent<ColocacionBloqueo>();
            if (bloqueo != null && bloqueo.enZonaProhibida)
            {
                Debug.Log("? No se puede colocar aquí, está en zona prohibida.");
                return;
            }

            Colocar();
        }
    }

    void Colocar()
    {
        Debug.Log("? Estantería colocada correctamente.");
        estanteriaActual = null; // ya no se mueve
    }
}