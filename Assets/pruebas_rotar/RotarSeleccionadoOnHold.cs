using UnityEngine;
using UnityEngine.EventSystems;

public class RotarSeleccionadoOnHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Header("Velocidad de rotación")]
    public float velocidadRotacion = 90f;

    private bool rotando = false;

    void Update()
    {
        if (rotando && SelectionManager.Instance.objetoSeleccionado != null)
        {
            SelectionManager.Instance.objetoSeleccionado.Rotate(Vector3.up, -velocidadRotacion * Time.deltaTime, Space.World);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        rotando = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        rotando = false;
    }
}
