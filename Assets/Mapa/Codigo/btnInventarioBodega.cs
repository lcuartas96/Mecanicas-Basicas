using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnInventarioBodega : MonoBehaviour
{
    public GameObject prefabInstancia;
    public Transform posicionInstancia;
    public string nombre, descripcion;
    public GameObject objetoEscena;

    [Header("Orientación")]
    public Vector3 rotacionPersonalizada = Vector3.zero;

    public void InstanciarPiezaMotor()
    {
        if (posicionInstancia == null)
        {
            Debug.LogWarning("No se asignó un punto de colocación.");
            return;
        }

        Quaternion rotacionFinal = Quaternion.Euler(rotacionPersonalizada);

        if (objetoEscena != null)
        {
            objetoEscena.transform.position = posicionInstancia.position;
            objetoEscena.transform.rotation = rotacionFinal;
            objetoEscena.SetActive(true);
        }
        else if (prefabInstancia != null)
        {
            Instantiate(prefabInstancia, posicionInstancia.position, rotacionFinal);
        }

        this.gameObject.SetActive(false);
    }
}
