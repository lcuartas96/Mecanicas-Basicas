using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Etiquetas_Caja : MonoBehaviour
{
    [Header("Configuración de la Caja")]
    public GameObject cajaObject;
    public Renderer cajaRenderer;

    [Header("Texturas Disponibles")]
    public Texture2D[] texturas;

    [Header("UI")]
    public Transform contenedorBotones; // Padre donde estarán los botones
    public GameObject prefabBoton; // Prefab con Image + Button

    private Material materialCaja;

    void Start()
    {
        InicializarComponentes();
        GenerarBotonesTexturas();
        CambiarTextura(0); // Inicia con la primera
    }

    void InicializarComponentes()
    {
        if (cajaRenderer == null && cajaObject != null)
        {
            cajaRenderer = cajaObject.GetComponent<Renderer>();
        }

        if (cajaRenderer != null)
        {
            materialCaja = cajaRenderer.material;
        }
    }

    void CambiarTextura(int cual)
    {
        if (texturas != null && cual < texturas.Length)
        {
            materialCaja.SetTexture("_Selos", texturas[cual]);
        }
    }

    void GenerarBotonesTexturas()
    {
        for (int i = 0; i < texturas.Length; i++)
        {
            int index = i; // Necesario para la lambda

            GameObject nuevoBoton = Instantiate(prefabBoton, contenedorBotones);
            Image imagen = nuevoBoton.GetComponentInChildren<Image>();
            Button boton = nuevoBoton.GetComponent<Button>();

            if (imagen != null)
            {
                // Crear un Sprite temporal desde la textura
                Sprite sprite = Sprite.Create(texturas[i], new Rect(0, 0, texturas[i].width, texturas[i].height), new Vector2(0.5f, 0.5f));
                imagen.sprite = sprite;
            }

            if (boton != null)
            {
                boton.onClick.AddListener(() => CambiarTextura(index));
            }
        }
    }
}
