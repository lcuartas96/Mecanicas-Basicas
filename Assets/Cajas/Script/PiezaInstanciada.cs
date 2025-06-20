using UnityEngine;

public class PiezaInstanciada : MonoBehaviour
{
    public string nombrePieza;
    public string descripcionPieza;
    public Sprite iconoPieza;
    public GameObject prefabOriginal;

    void OnMouseDown()
    {
        InventarioUI inventario = FindObjectOfType<InventarioUI>();
        if (inventario != null)
        {
           // inventario.AgregarAlInventario(iconoPieza, prefabOriginal, nombrePieza, descripcionPieza);
        }

        Destroy(this.gameObject); // Eliminar la pieza de la escena
    }
}
