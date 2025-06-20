using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BotonInventarioBanda : MonoBehaviour
{

    public GameObject prebafInstancia; //Prefab a instanciar
    public Transform posicionInstancia; // Punto en el que vamos a realizar la instancia
    public string nombre, descripcion;
    public GameObject objetoEscena; // Referencia al objeto desactivado

    /// <summary>
    /// Metodo utilizado para instanciar las piezas que vamos a armar en el punto deseado
    /// </summary>
    public void InstanciarPiezaMotor()
    {

        if (objetoEscena != null)
        {
            objetoEscena.transform.position = posicionInstancia.position;
            objetoEscena.transform.rotation = Quaternion.identity;
            objetoEscena.SetActive(true); // Reactiva la caja original
        }

        this.gameObject.SetActive(false); // Oculta el botón del inventario
        
    }
}
