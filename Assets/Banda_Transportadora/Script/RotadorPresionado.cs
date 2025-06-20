using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RotadorPresionado : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject objetoARotar;
    public float velocidadRotacion = 90f;
    private bool rotando = false;

    void Update()
    {
        if (rotando && objetoARotar != null)
        {
            objetoARotar.transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);
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