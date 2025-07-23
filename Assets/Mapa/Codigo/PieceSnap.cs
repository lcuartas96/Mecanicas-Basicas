using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSnap : MonoBehaviour
{
    public Transform[] snapPoints; // Puntos de anclaje de esta pieza
    public float snapDistance = 0.5f; // Distancia máxima para enganchar

    private bool isSnapped = false;

    void Update()
    {
        if (isSnapped) return;

        // Buscar puntos de anclaje cercanos
        PieceSnap[] allPieces = FindObjectsOfType<PieceSnap>();

        foreach (PieceSnap otherPiece in allPieces)
        {
            if (otherPiece == this) continue;

            foreach (Transform myPoint in snapPoints)
            {
                foreach (Transform otherPoint in otherPiece.snapPoints)
                {
                    float distance = Vector3.Distance(myPoint.position, otherPoint.position);

                    if (distance < snapDistance)
                    {
                        // Alinear la pieza
                        Vector3 offset = otherPoint.position - myPoint.position;
                        transform.position += offset;

                        // Opcional: Alinear rotación si lo necesitas
                        // transform.rotation = otherPiece.transform.rotation;

                        isSnapped = true;
                        return;
                    }
                }
            }
        }
    }
}
