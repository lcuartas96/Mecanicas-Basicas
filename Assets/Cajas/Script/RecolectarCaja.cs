using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RecolectarCaja : MonoBehaviour
{
    public GameObject caja3D;                  // La caja en el mundo 3D
    public GameObject iconoCajaUI;             // El ícono (imagen) en el Canvas
    public Transform posicionSoltar;           // Posición donde reaparece la caja

    private bool cajaRecolectada = false;

    public void RecogerCaja()
    {
        if (!cajaRecolectada)
        {
            caja3D.SetActive(false);           // Desactiva la caja del mundo
            iconoCajaUI.SetActive(true);       // Muestra el icono en el inventario
            cajaRecolectada = true;
        }
    }

    public void SoltarCaja()
    {
        if (cajaRecolectada)
        {
            caja3D.transform.position = posicionSoltar.position; // Reaparece en otra parte
            caja3D.SetActive(true);           // Activa la caja 3D
            iconoCajaUI.SetActive(false);     // Oculta el icono del inventario
            cajaRecolectada = false;
        }
    }
}
