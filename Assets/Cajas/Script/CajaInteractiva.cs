using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaInteractiva : MonoBehaviour
{
    public GameObject botonInventario;

    void OnMouseDown()
    {
        if (botonInventario != null)
        {
            botonInventario.SetActive(true); // Vuelve a activar el botón
        }

        Destroy(this.gameObject); // Destruye la caja de la escena
    }
}
