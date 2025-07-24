using System.Collections;
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
    public int indicePuntoInstancia;

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
                indicePuntoInstancia,
                rotacionPersonalizada // 👉 Pasa la rotación elegida
            );
        }
        else
        {
            Debug.LogError("No se encontró InventarioIU_Bodega en escena.");
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
