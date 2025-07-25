using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance;

    [Header("Objeto actualmente activo")]
    public Transform objetoSeleccionado;

    void Awake()
    {
        // Singleton para que siempre haya uno
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void SeleccionarObjeto(Transform objeto)
    {
        objetoSeleccionado = objeto;
        Debug.Log("Objeto seleccionado: " + objeto.name);
    }

    public void DeseleccionarObjeto()
    {
        objetoSeleccionado = null;
    }
}
