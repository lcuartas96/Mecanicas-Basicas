using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventarioIU_Bodega : MonoBehaviour
{
    [Header("Referencias UI")]
    public GameObject buttonPrefab;
    public Transform contentPanel;

    [Header("Puntos de colocación")]
    public List<Transform> puntosInstancia;

    public void AgregarAlInventario(
        Sprite icono,
        GameObject prefab,
        string nombreBoton,
        string descripcionPieza,
        GameObject objetoEscena,
        int indicePunto,
        Vector3 rotacionPersonalizada // 👉 Nueva rotación personalizada
    )
    {
        if (indicePunto < 0 || indicePunto >= puntosInstancia.Count)
        {
            Debug.LogError($"Índice de punto inválido: {indicePunto}");
            return;
        }

        GameObject nuevoBoton = Instantiate(buttonPrefab, contentPanel);

        Image imagenIcono = nuevoBoton.GetComponentInChildren<Image>();
        if (imagenIcono != null)
            imagenIcono.sprite = icono;

        TextMeshProUGUI textoBoton = nuevoBoton.GetComponentInChildren<TextMeshProUGUI>();
        if (textoBoton != null)
            textoBoton.text = nombreBoton;

        BtnInventarioBodega btn = nuevoBoton.GetComponent<BtnInventarioBodega>();
        if (btn != null)
        {
            btn.prefabInstancia = prefab;
            btn.objetoEscena = objetoEscena;
            btn.posicionInstancia = puntosInstancia[indicePunto];
            btn.descripcion = descripcionPieza;
            btn.nombre = nombreBoton;

            btn.rotacionPersonalizada = rotacionPersonalizada; // 👉 Guarda ángulo personalizado

            Button botonUI = nuevoBoton.GetComponent<Button>();
            botonUI.onClick.AddListener(btn.InstanciarPiezaMotor);
        }
        else
        {
            Debug.LogError("El prefab del botón no tiene BtnInventarioBodega.");
        }
    }
}
