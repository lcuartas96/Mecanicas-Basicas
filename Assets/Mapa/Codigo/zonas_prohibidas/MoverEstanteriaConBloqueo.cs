using UnityEngine;

public class MoverEstanteriaConBloqueo : MonoBehaviour
{
    public Color colorProhibido = Color.red;
    private Color colorOriginal;
    private Renderer renderEstanteria;
    private Vector3 ultimaPosicionValida;
    private bool moviendo = false;

    void Start()
    {
        // Buscar el Renderer en el objeto o sus hijos
        renderEstanteria = GetComponentInChildren<Renderer>();

        if (renderEstanteria != null)
        {
            colorOriginal = renderEstanteria.material.color;
        }
        else
        {
            Debug.LogWarning($"No se encontró Renderer en {gameObject.name}. El color no cambiará.");
        }

        ultimaPosicionValida = transform.position;
    }

    void OnMouseDown()
    {
        moviendo = true;
    }

    void OnMouseUp()
    {
        moviendo = false;
        transform.position = ultimaPosicionValida;

        if (renderEstanteria != null)
            renderEstanteria.material.color = colorOriginal;
    }

    void Update()
    {
        if (moviendo)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;
            Vector3 mundo = Camera.main.ScreenToWorldPoint(mousePos);

            transform.position = new Vector3(mundo.x, ultimaPosicionValida.y, mundo.z);
        }
    }

    void OnTriggerStay(Collider other)
    {
        // Si el collider es un trigger y NO es la propia estantería
        if (other.isTrigger && other.gameObject != gameObject)
        {
            if (renderEstanteria != null)
                renderEstanteria.material.color = colorProhibido;

            transform.position = ultimaPosicionValida;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.isTrigger && other.gameObject != gameObject)
        {
            if (renderEstanteria != null)
                renderEstanteria.material.color = colorOriginal;

            ultimaPosicionValida = transform.position;
        }
    }
}
