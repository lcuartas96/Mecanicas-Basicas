using UnityEngine;
using UnityEngine.EventSystems;

public class RotarUnoIzquierdaOnHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Header("Lista de objetos para rotar")]
    public Transform[] objetosARotar;

    [Header("Índice del objeto a rotar (0 = primero)")]
    public int indiceObjetoActivo = 0;

    [Header("Velocidad de rotación (grados por segundo)")]
    public float velocidadRotacion = 90f;

    private bool rotando = false;

    void Update()
    {
        if (rotando && objetosARotar != null && objetosARotar.Length > 0)
        {
            if (indiceObjetoActivo >= 0 && indiceObjetoActivo < objetosARotar.Length && objetosARotar[indiceObjetoActivo] != null)
            {
                objetosARotar[indiceObjetoActivo].Rotate(Vector3.up, -velocidadRotacion * Time.deltaTime, Space.World);
            }
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
