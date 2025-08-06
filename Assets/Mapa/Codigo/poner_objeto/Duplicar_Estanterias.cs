using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Necesario para usar el Slider

public class Duplicar_Estanterias : MonoBehaviour
{
    public GameObject[] pisos; // Este array es para los objetos de la escena.
    public Slider sliderAltura;

    void Update()
    {
        int altura = (int)sliderAltura.value;
        for (int i = 0; i < pisos.Length; i++)
        {
            pisos[i].SetActive(i < altura);
        }
    }

    /*public GameObject[] pisos;
    public Slider sliderAltura; // Referencia al Slider UI

    // Update is called once per frame
    void Update()
    {
        // Obtiene el valor del slider y lo redondea a un número entero
        int altura = (int)sliderAltura.value;

        for (int i = 0; i < pisos.Length; i++)
        {
            // Activa o desactiva el objeto dependiendo del valor del slider
            pisos[i].SetActive(i < altura);
        }
    }*/

    // Array para almacenar los PREFABS, no los objetos de la escena.

    /*
    
    public GameObject[] pisosPrefabs;
    public Slider sliderAltura;

    // Lista para almacenar las instancias de los prefabs que se crean.
    private List<GameObject> pisosInstanciados = new List<GameObject>();

    void Start()
    {
        // Instancia todos los prefabs al inicio del juego y los guarda en la lista.
        for (int i = 0; i < pisosPrefabs.Length; i++)
        {
            // Creamos una instancia del prefab y lo guardamos.
            GameObject nuevoPiso = Instantiate(pisosPrefabs[i], transform);
            pisosInstanciados.Add(nuevoPiso);
        }
    }

    void Update()
    {
        int altura = (int)sliderAltura.value;

        // Itera sobre la lista de instancias para activar/desactivar.
        for (int i = 0; i < pisosInstanciados.Count; i++)
        {
            // Aseguramos que la lista no sea más grande que el array de prefabs.
            if (i < pisosPrefabs.Length)
            {
                pisosInstanciados[i].SetActive(i < altura);
            }
        }
    }
    */

    /*public GameObject[] pisos;
    [Range(0, 9)] // un rango de 0 a 4 estanterias
    public int altura; // la altura que deseo
  

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < pisos.Length; i++)
        {
            pisos[i].SetActive(i < altura);
        }
    }*/

    /*public GameObject[] pisos;
    [Range(0, 9)]
    public int altura;
  
    // Esta función se llamará cuando se haga clic en el botón.
    public void ActualizarAltura()
    {
        for (int i = 0; i < pisos.Length; i++)
        {
            pisos[i].SetActive(i < altura);
        }
    }*/

    /*public GameObject[] pisos;

    // Esta función recibe el valor del Slider y actualiza la estantería.
    public void ActualizarAltura(float nuevaAltura)
    {
        int alturaInt = Mathf.RoundToInt(nuevaAltura);

        for (int i = 0; i < pisos.Length; i++)
        {
            pisos[i].SetActive(i < alturaInt);
        }
    }*/

    /*public GameObject[] pisos;
    [Range(0, 9)]
    public int altura;

    public void AplicarAltura() // Este método debe ser público y sin parámetros
    {
        for (int i = 0; i < pisos.Length; i++)
        {
            pisos[i].SetActive(i < altura);
        }

        Debug.Log("Botón presionado, altura aplicada: " + altura); // Para depurar
    }*/

    /*public GameObject[] pisos;
    [Range(0, 9)]
    public int altura;

    /// <summary>
    /// Método para aplicar la altura actual (ideal para botón)
    /// </summary>
    public void AplicarAltura()
    {
        for (int i = 0; i < pisos.Length; i++)
        {
            pisos[i].SetActive(i < altura);
        }

        Debug.Log("Botón presionado, altura aplicada: " + altura);
    }

    /// <summary>
    /// Método para usar con Slider (se ejecuta automáticamente al moverlo)
    /// </summary>
    public void AplicarAlturaDesdeSlider(float nuevaAltura)
    {
        altura = Mathf.RoundToInt(nuevaAltura);
        AplicarAltura(); // reutiliza el método anterior

        Debug.Log("Altura aplicada desde slider: " + altura);
    }*/

    /*public GameObject[] pisos;
    [Range(0, 9)] // Un rango de 0 a 9 estanterías
    public int altura; // Altura deseada

    // Método que activa las estanterías según la altura
    public void AplicarAltura()
    {
        for (int i = 0; i < pisos.Length; i++)
        {
            pisos[i].SetActive(i < altura);
        }
    }*/


}
