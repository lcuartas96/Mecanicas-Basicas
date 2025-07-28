using UnityEngine;

public class ConstructionManager : MonoBehaviour
{
    [Header("Prefab actualmente seleccionado")]
    public GameObject prefabSeleccionado;

    [Header("Objeto fantasma que se está colocando")]
    public GameObject objetoEnConstruccion;

    [Header("Velocidad de rotación")]
    public float velocidadRotacion = 90f;

    void Update()
    {
        if (objetoEnConstruccion != null)
        {
            MoverObjetoSegunMouse();

            if (Input.GetKeyDown(KeyCode.R))
            {
                RotarObjeto();
            }

            if (Input.GetMouseButtonDown(0))
            {
                ColocarObjeto();
            }
        }
    }

    public void SeleccionarPrefab(GameObject nuevoPrefab)
    {
        prefabSeleccionado = nuevoPrefab;
        CrearNuevoObjeto();
    }

    void CrearNuevoObjeto()
    {
        if (prefabSeleccionado != null)
        {
            objetoEnConstruccion = Instantiate(prefabSeleccionado);
        }
    }

    public void RotarObjeto()
    {
        if (objetoEnConstruccion != null)
        {
            objetoEnConstruccion.transform.Rotate(Vector3.up, velocidadRotacion);
        }
    }

    void MoverObjetoSegunMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            objetoEnConstruccion.transform.position = hit.point;
        }
    }

    void ColocarObjeto()
    {
        objetoEnConstruccion = null;
    }
}
