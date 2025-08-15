using UnityEngine;

public class ColocarConValidacion : MonoBehaviour
{
    public LayerMask capaZonaProhibida;          // Asigna la layer del cubo
    public Collider volumenEstanteria;           // Deja vacío para autodetectar

    private Vector3 ultimaPosValida;

    void Start()
    {
        if (volumenEstanteria == null)
            volumenEstanteria = GetComponent<Collider>();

        ultimaPosValida = transform.position;
    }

    public void MoverA(Vector3 destino)
    {
        Vector3 original = transform.position;
        transform.position = destino;

        // Comprobamos solape usando el volumen real de la estantería
        Bounds b = volumenEstanteria.bounds;
        Collider[] toques = Physics.OverlapBox(
            b.center, b.extents * 0.98f, Quaternion.identity,
            capaZonaProhibida, QueryTriggerInteraction.Ignore);

        if (toques.Length > 0)
        {
            // No se permite: volvemos atrás
            transform.position = ultimaPosValida;
            // (Opcional) Debug.Log("Zona prohibida: no se puede colocar");
        }
        else
        {
            ultimaPosValida = transform.position;
        }
    }

    // Gizmo útil para ver el volumen de chequeo
    void OnDrawGizmosSelected()
    {
        if (volumenEstanteria == null) return;
        Bounds b = volumenEstanteria.bounds;
        Gizmos.matrix = Matrix4x4.identity;
        Gizmos.DrawWireCube(b.center, b.size * 0.98f);
    }
}
