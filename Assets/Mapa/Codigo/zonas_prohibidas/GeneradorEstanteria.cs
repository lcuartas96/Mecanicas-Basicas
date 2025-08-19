using UnityEngine;

public class GeneradorEstanteria : MonoBehaviour
{
    // Asigna el prefab de la estantería desde el Inspector
    public GameObject prefabEstanteria;

    // Referencia al GestorColocacion en la escena
    public ColocarEstanteria gestorColocacion;

    public void CrearEstanteria()
    {
        // Instancia (crea) el prefab de la estantería
        GameObject nuevaEstanteria = Instantiate(prefabEstanteria);

        // Asigna la estantería recién creada al GestorColocacion
        if (gestorColocacion != null)
        {
            gestorColocacion.estanteriaActual = nuevaEstanteria;
        }
    }
}