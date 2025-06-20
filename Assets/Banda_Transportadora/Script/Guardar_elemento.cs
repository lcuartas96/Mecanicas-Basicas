using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardar_elemento : MonoBehaviour
{
    public string nombrePiezaBoton; // Nombre para asignarle al boton de la piza
    public string nombrePieza; // Nombre completo de la pieza para el titulo
    [TextArea(3, 10)]
    public string descripcionPieza; // Descripcion de para que sirve esa pieza

    public GameObject prefabInstancia; // El prefab que posteriormente instanciar� esa pieza
    public Sprite icono; // Imagen para mostrar en el bot�n del inventario


    /// <summary>
    /// Metodo incovado al momento de darle click sobre un objeto con collider
    /// </summary>
    void OnMouseDown()
    {
        InventarioUI inventario = FindObjectOfType<InventarioUI>();  // Encontramos y referenciamos nuestro inventario
        if (inventario != null)
        {
            //inventario.AgregarAlInventario(icono, prefabInstancia, nombrePiezaBoton, descripcionPieza, this.gameObject); // Agregamos el objeto a nuestro inventario
            inventario.AgregarAlInventario(icono, prefabInstancia, nombrePiezaBoton, descripcionPieza, this.gameObject);
        }

        // Desactivamos el objeto en lugar de destruirlo
        this.gameObject.SetActive(false);

        //InformacionUI.singleton.BorrarInformacionPieza(); // Retiramos la informacion de la pieza del canvas
        // Destroy(this.gameObject); // Destruimos el objeto

    }
}
