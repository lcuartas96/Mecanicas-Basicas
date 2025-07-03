using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cosa : MonoBehaviour
{
    [Header("Configuración de la Caja")]
    public GameObject cajaObject; // El objeto de la caja
    public Renderer cajaRenderer; // El renderer de la caja

    [Header("Texturas Disponibles")]
    public Texture2D[] texturas; // Array de texturas disponibles
    private int texturaActualIndex = 0;
    private Material materialCaja;
    // Start is called before the first frame update
    void Start()
    {
        // Inicializar referencias
        InicializarComponentes();

        // Establecer la primera textura
        CambiarTextura(0);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            texturaActualIndex = (texturaActualIndex + 1) % texturas.Length;
            CambiarTextura(texturaActualIndex);
        }
    }
    void InicializarComponentes()
    {
        // Si no se asignó el renderer, intentar obtenerlo del objeto
        if (cajaRenderer == null && cajaObject != null)
        {
            cajaRenderer = cajaObject.GetComponent<Renderer>();
        }

        // Obtener o crear el material
        if (cajaRenderer != null)
        {
            materialCaja = cajaRenderer.material;
        }
    }


    // Establecer la primera textura
    void CambiarTextura(int cual)
    {
        materialCaja.SetTexture("_Selos", texturas[cual]);
    }
}
