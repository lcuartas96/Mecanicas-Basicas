using UnityEngine;

public class SeleccionCaja : MonoBehaviour
{
    public static GameObject cajaSeleccionada; // Caja activa globalmente

    /*private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(rayo, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Caja"))
                {
                    // Deseleccionar anterior
                    if (cajaSeleccionada != null)
                    {
                        ResetVisual(cajaSeleccionada);
                    }

                    // Nueva selección
                    cajaSeleccionada = hit.collider.gameObject;
                    SeleccionVisual(cajaSeleccionada);
                }
            }
        }
    }*/

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(rayo, out RaycastHit hit))
            {
                Debug.Log("Raycast golpeó: " + hit.collider.name); // Verifica si algo se está tocando

                if (hit.collider.CompareTag("Caja"))
                {
                    Debug.Log("Caja seleccionada: " + hit.collider.name);
                    if (cajaSeleccionada != null)
                    {
                        ResetVisual(cajaSeleccionada);
                    }

                    cajaSeleccionada = hit.collider.gameObject;
                    SeleccionVisual(cajaSeleccionada);
                }
            }
            else
            {
                Debug.Log("No golpeó nada");
            }
        }
    }


    void SeleccionVisual(GameObject caja)
    {
        Renderer rend = caja.GetComponent<Renderer>();
        if (rend != null) rend.material.color = Color.yellow; // Marca seleccionada
    }

    void ResetVisual(GameObject caja)
    {
        Renderer rend = caja.GetComponent<Renderer>();
        if (rend != null) rend.material.color = Color.white; // Restaura color
    }
}
