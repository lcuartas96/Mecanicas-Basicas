using UnityEngine;
using UnityEngine.UI;

public class AplicarEtiquetaEnGrid : MonoBehaviour
{
    public GameObject prefabEtiquetaUI; // Prefab con una Image ya configurada
    public Sprite spriteEtiqueta;       // El sprite de esta etiqueta

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ColocarEtiqueta);
    }

    void ColocarEtiqueta()
    {
        GameObject caja = SeleccionCaja.cajaSeleccionada;

        if (caja == null)
        {
            Debug.LogWarning("No hay caja seleccionada.");
            return;
        }

        // Buscar el Grid
        Transform grid = caja.transform.Find("GridEtiqueta/ZonaEtiquetas");
        if (grid == null)
        {
            Debug.LogWarning("No se encontró el Grid en la caja.");
            return;
        }

        // Instanciar la etiqueta como hijo del grid
        GameObject nuevaEtiqueta = Instantiate(prefabEtiquetaUI, grid);
        nuevaEtiqueta.GetComponent<Image>().sprite = spriteEtiqueta;
    }
}

