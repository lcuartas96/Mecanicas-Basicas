using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transferenciadebandas : MonoBehaviour
{
    public Mover_Banda nextBelt;           // La siguiente banda
    public Vector3 newDirection = Vector3.right; // Dirección hacia donde se moverá el objeto

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;

        if (rb != null)
        {
            Objeto_mover redirect = rb.GetComponent<Objeto_mover>();
            if (redirect != null)
            {
                redirect.UpdateDirection(newDirection);
                redirect.SetActiveBelt(nextBelt);
            }
        }
    }
}
