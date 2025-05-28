
using UnityEngine;

public class GuardarPieza : MonoBehaviour
{
    public string nombrePiezaBoton; // Nombre para asignarle al boton de la piza
    public string nombrePieza; // Nombre completo de la pieza para el titulo
    [TextArea(3, 10)]
    public string descripcionPieza; // Descripcion de para que sirve esa pieza

    public GameObject prefabInstancia; // El prefab que posteriormente instanciará esa pieza
    public Sprite icono; // Imagen para mostrar en el botón del inventario


    /// <summary>
    /// Metodo incovado al momento de darle click sobre un objeto con collider
    /// </summary>
    void OnMouseDown()
    {
        InventarioUI inventario = FindObjectOfType<InventarioUI>();  // Encontramos y referenciamos nuestro inventario
        if (inventario != null)
        {
            inventario.AgregarAlInventario(icono, prefabInstancia, nombrePiezaBoton, descripcionPieza); // Agregamos el objeto a nuestro inventario
        }

        //InformacionUI.singleton.BorrarInformacionPieza(); // Retiramos la informacion de la pieza del canvas
        Destroy(this.gameObject); // Destruimos el objeto
    }
}
