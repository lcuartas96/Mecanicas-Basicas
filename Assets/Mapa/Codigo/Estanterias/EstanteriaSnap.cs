using UnityEngine;

public class EstanteriaSnap : MonoBehaviour
{
    [Header("Punto de anclaje (activo)")]
    public Transform puntoAnclaje; // borde que se pegará

    private void OnTriggerEnter(Collider other)
    {
        EstanteriaSnap otraEstanteria = other.GetComponent<EstanteriaSnap>();

        if (otraEstanteria != null && otraEstanteria != this)
        {
            // Calcula el offset desde este objeto hasta su punto de anclaje
            Vector3 offset = transform.position - puntoAnclaje.position;

            // Mueve esta estantería para que su punto de anclaje
            // quede exactamente en la posición de la otra estantería
            transform.position = otraEstanteria.transform.position + offset;

            Debug.Log($"{name} pegada a {other.name}");
        }
    }
}

