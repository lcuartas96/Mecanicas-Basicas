using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cajarecojida : MonoBehaviour
{
    public string nombreCaja;
    public CajaManager cajaManager;

    private void OnMouseDown()
    {
        if (cajaManager != null)
        {
            cajaManager.RecogerCaja(nombreCaja);
        }
    }
}
