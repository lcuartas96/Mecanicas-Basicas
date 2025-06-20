using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
/*
public class Inventario : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform contentPanel;
    public Transform[] puntosInstancia; // Posiciones: Posicion1, Posicion2, ...
    private int contadorInstancias = 0;

    public void AgregarAlInventario(Sprite icono, GameObject prefab, string nombreBoton, string descripcionPieza)
    {
        if (contadorInstancias < puntosInstancia.Length)
        {
            GameObject nuevoBoton = Instantiate(buttonPrefab, contentPanel);
            Image imagenIcono = nuevoBoton.GetComponentInChildren<Image>();
            imagenIcono.sprite = icono;

            TextMeshProUGUI textoBoton = nuevoBoton.GetComponentInChildren<TextMeshProUGUI>();
            textoBoton.text = nombreBoton;

            btnInventario btnInv = nuevoBoton.GetComponent<btnInventario>();
            btnInv.prebafInstancia = prefab;
            btnInv.posicionInstancia = puntosInstancia[contadorInstancias];
            btnInv.descripcion = descripcionPieza;
            btnInv.nombre = nombreBoton;

            Button btn = nuevoBoton.GetComponent<Button>();
            btn.onClick.AddListener(btnInv.InstanciarPiezaMotor);

            contadorInstancias++;
        }
    }
}
*/