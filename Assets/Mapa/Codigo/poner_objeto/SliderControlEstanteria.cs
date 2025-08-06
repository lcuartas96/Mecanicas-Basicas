using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControlEstanteria : MonoBehaviour
{
    [Header("Estantería que contiene los pisos")]
    public GameObject estanteriaPadre;

    public GameObject[] pisos;
    public Slider slider;
    public int altura = 9;

    void Start()
    {
        slider = GetComponent<Slider>();

        if (estanteriaPadre != null)
        {
            // Obtener los hijos (pisos) del objeto padre
            int totalPisos = estanteriaPadre.transform.childCount;
            pisos = new GameObject[totalPisos];

            for (int i = 0; i < totalPisos; i++)
            {
                pisos[i] = estanteriaPadre.transform.GetChild(i).gameObject;
            }

            // Configura el slider si no lo has hecho manualmente
            slider.minValue = 0;
            slider.maxValue = totalPisos;
            slider.wholeNumbers = true;

            // Escuchar el cambio de valor del slider
            slider.onValueChanged.AddListener(ActualizarAltura);
        }
        else
        {
            Debug.LogWarning("No se asignó el objeto padre de estantería.");
        }
    }

    void ActualizarAltura(float nuevaAltura)
    {
        altura = Mathf.RoundToInt(nuevaAltura);

        for (int i = 0; i < pisos.Length; i++)
        {
            pisos[i].SetActive(i < altura);
        }

        Debug.Log("Altura actualizada desde Slider: " + altura);
    }
}
