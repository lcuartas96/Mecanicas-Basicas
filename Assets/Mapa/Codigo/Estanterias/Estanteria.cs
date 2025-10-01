using UnityEngine;

public class Estanteria : MonoBehaviour
{
    public Transform[] puntosInstancia;  // posiciones dentro de la estantería
    private int contador = 0;


void Update()
    {
        if (Input.GetMouseButtonDown(0)) // click izquierdo
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Verificamos que el raycast golpea la estantería
                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    ColocarObjeto();
                }
            }
        }
    }

    void ColocarObjeto()
    {
        if (InventarioUI.objetoSeleccionado == null)
        {
            Debug.Log("No hay objeto seleccionado en el inventario.");
            return;
        }

        if (contador < puntosInstancia.Length)
        {
            GameObject nuevo = Instantiate(InventarioUI.objetoSeleccionado, puntosInstancia[contador].position, Quaternion.identity);
            Debug.Log("Objeto colocado: " + nuevo.name);
            contador++;
        }
        else
        {
            Debug.Log("No quedan puntos disponibles en la estantería.");
        }
    }

}
