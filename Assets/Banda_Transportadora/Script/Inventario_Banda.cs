using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Inventario_Banda : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform contentPanel;
    public Transform[] puntosInstancia;
    private int contadorInstancias;

    public void AgregarAlInventario(Sprite icono, GameObject prefab, string nombreBoton, string descripcionPieza, GameObject objetoEscena)
    {
        if (contadorInstancias < 13)
        {
            GameObject nuevoBoton = Instantiate(buttonPrefab, contentPanel);

            Image imagenIcono = nuevoBoton.GetComponentInChildren<Image>();
            if (imagenIcono != null)
                imagenIcono.sprite = icono;

            TextMeshProUGUI textoBoton = nuevoBoton.GetComponentInChildren<TextMeshProUGUI>();
            if (textoBoton != null)
                textoBoton.text = nombreBoton;

            btnInventario btn = nuevoBoton.GetComponent<btnInventario>();
            btn.prebafInstancia = prefab; // Solo como respaldo
            btn.objetoEscena = objetoEscena; // El objeto real desactivado
            btn.posicionInstancia = puntosInstancia[contadorInstancias % puntosInstancia.Length];
            btn.descripcion = descripcionPieza;
            btn.nombre = nombreBoton;

            Button botonUI = nuevoBoton.GetComponent<Button>();
            botonUI.onClick.AddListener(btn.InstanciarPiezaMotor);

            contadorInstancias += 1;
        }
    }
}
