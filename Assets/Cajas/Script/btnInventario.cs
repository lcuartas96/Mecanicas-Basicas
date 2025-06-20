
using UnityEngine;
using UnityEngine.EventSystems;

public class btnInventario : MonoBehaviour
{
    public GameObject prebafInstancia; //Prefab a instanciar
    public Transform posicionInstancia; // Punto en el que vamos a realizar la instancia
    public string nombre,descripcion;
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



        //Instantiate(prebafInstancia, posicionInstancia.position, prebafInstancia.transform.rotation); // Instanciar sin ser hijos de ningun objeto
        //Instantiate(prebafInstancia, posicionInstancia); // Instanciar dentro de un objeto como hijos

        // En vez de destruir el botón del inventario, lo desactivamos
        //this.gameObject.SetActive(false);
        // Destroy(this.gameObject);

        /* GameObject nuevaPieza = Instantiate(prebafInstancia, posicionInstancia); // Instanciamos como hijo

         // Añadir el script PiezaInstanciada para que pueda volver al inventario
         PiezaInstanciada componente = nuevaPieza.AddComponent<PiezaInstanciada>();
         componente.nombrePieza = nombre;
         componente.descripcionPieza = descripcion;

         // Obtener el ícono del botón (si existe) y asignarlo
         UnityEngine.UI.Image imagen = GetComponentInChildren<UnityEngine.UI.Image>();
         if (imagen != null)
         {
             componente.iconoPieza = imagen.sprite;
         }

         componente.prefabOriginal = prebafInstancia;

         Destroy(this.gameObject); // Eliminar el botón del inventario*/
    }
    

    }
