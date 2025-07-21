using UnityEngine;

public class CloseCanvas : MonoBehaviour
{
    [SerializeField] private GameObject canvasToClose;

    // Esta función se puede asignar al evento OnClick del botón
    public void CloseThisCanvas()
    {
        if (canvasToClose != null)
        {
            canvasToClose.SetActive(false);
        }
        else
        {
            Debug.LogWarning("No se asignó el Canvas a cerrar.");
        }
    }
}

