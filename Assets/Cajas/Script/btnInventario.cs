
using UnityEngine;
using UnityEngine.EventSystems;

public class btnInventario : MonoBehaviour
{
    public GameObject prebafInstancia; //Prefab a instanciar
    public Transform posicionInstancia; // Punto en el que vamos a realizar la instancia
    public string nombre,descripcion;
    /// <summary>
    /// Metodo utilizado para instanciar las piezas que vamos a armar en el punto deseado
    /// </summary>
    public void InstanciarPiezaMotor()
    {
        //Instantiate(prebafInstancia, posicionInstancia.position, prebafInstancia.transform.rotation); // Instanciar sin ser hijos de ningun objeto
        Instantiate(prebafInstancia, posicionInstancia); // Instanciar dentro de un objeto como hijos
        Destroy(this.gameObject);
    }


}
