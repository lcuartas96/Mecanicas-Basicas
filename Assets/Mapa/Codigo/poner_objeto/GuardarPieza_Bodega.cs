/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarPieza_Bodega : MonoBehaviour
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
        InventarioIU_Bodega inventario = FindObjectOfType<InventarioIU_Bodega>();  // Encontramos y referenciamos nuestro inventario
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
}*/

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarPieza_Bodega : MonoBehaviour
{
    [Header("Datos de la pieza")]
    public string nombrePiezaBoton;
    public string nombrePieza;
    [TextArea(3, 10)]
    public string descripcionPieza;

    [Header("Instancia")]
    public GameObject prefabInstancia;
    public Sprite icono;
    //public int indicePuntoInstancia;

    // 🔑 CAMBIO: ahora lista de índices
    public List<int> indicesPuntosInstancia = new List<int>();

    [Header("Rotación personalizada")]
    public Vector3 rotacionPersonalizada = Vector3.zero; // 👉 La que tú decidas

    // Ya correcto
    void OnMouseDown()
    {
        InventarioIU_Bodega inventario = FindObjectOfType<InventarioIU_Bodega>();
        if (inventario != null)
        {
            inventario.AgregarAlInventario(
                icono,
                prefabInstancia,
                nombrePiezaBoton,
                descripcionPieza,
                this.gameObject,
                indicesPuntosInstancia,   // ✅ Lista completa
                rotacionPersonalizada
            );
        }
        else
        {
            Debug.LogError("No se encontró InventarioIU_Bodega en escena.");
        }

        this.gameObject.SetActive(false);
    }

}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarPieza_Bodega : MonoBehaviour
{
    public string nombrePiezaBoton; // Nombre para asignarle al boton de la pieza
    public string nombrePieza; // Nombre completo de la pieza para el titulo
    [TextArea(3, 10)]
    public string descripcionPieza; // Descripción de para qué sirve esa pieza

    public GameObject prefabInstancia; // El prefab que posteriormente instanciará esa pieza
    public Sprite icono; // Imagen para mostrar en el botón del inventario

    void OnMouseDown()
    {
        InventarioIU_Bodega inventario = FindObjectOfType<InventarioIU_Bodega>(); // Encontramos y referenciamos nuestro inventario
        if (inventario != null)
        {
            inventario.AgregarAlInventario(icono, prefabInstancia, nombrePiezaBoton, descripcionPieza, this.gameObject);
        }

        this.gameObject.SetActive(false);
    }
}





/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarPieza_Bodega : MonoBehaviour
{
    [Header("Datos de la pieza")]
    public string nombrePiezaBoton;
    public string nombrePieza;
    [TextArea(3, 10)]
    public string descripcionPieza;

    [Header("Instancia")]
    public GameObject prefabInstancia;
    public Sprite icono;
    //public int indicePuntoInstancia;

    // 🔑 CAMBIO: ahora lista de índices
    public List<int> indicesPuntosInstancia = new List<int>();

    [Header("Rotación personalizada")]
    public Vector3 rotacionPersonalizada = Vector3.zero; // 👉 La que tú decidas

    void OnMouseDown()
    {
        InventarioIU_Bodega inventario = FindObjectOfType<InventarioIU_Bodega>();
        if (inventario != null)
        {
            inventario.AgregarAlInventario(
                icono,
                prefabInstancia,
                nombrePiezaBoton,
                descripcionPieza,
                this.gameObject,
                //indicePuntoInstancia,
                indicesPuntosInstancia, // 👉 Pasa lista de índices
                rotacionPersonalizada // 👉 Pasa la rotación elegida
            );
        }
        else
        {
            Debug.LogError("No se encontró InventarioIU_Bodega en escena.");
        }

        this.gameObject.SetActive(false);
    }
}*/




/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarPieza_Bodega : MonoBehaviour
{
    [Header("Datos de la pieza")]
    public string nombrePiezaBoton;
    public string nombrePieza;
    [TextArea(3, 10)]
    public string descripcionPieza;

    [Header("Instancia")]
    public GameObject prefabInstancia;
    public Sprite icono;

    // 🔑 CAMBIO: ahora lista de índices
    public List<int> indicesPuntosInstancia = new List<int>();

    [Header("Rotación personalizada")]
    public Vector3 rotacionPersonalizada = Vector3.zero;

    void OnMouseDown()
    {
        InventarioIU_Bodega inventario = FindObjectOfType<InventarioIU_Bodega>();
        if (inventario != null)
        {
            inventario.AgregarAlInventarioMultiple(
                icono,
                prefabInstancia,
                nombrePiezaBoton,
                descripcionPieza,
                this.gameObject,
                indicesPuntosInstancia, // 👉 Pasa lista de índices
                rotacionPersonalizada
            );
        }
        else
        {
            Debug.LogError("No se encontró InventarioIU_Bodega en escena.");
        }

        this.gameObject.SetActive(false);
    }
}*/
