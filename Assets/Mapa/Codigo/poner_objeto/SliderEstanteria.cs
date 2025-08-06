/*using UnityEngine;
using UnityEngine.UI;

public class SliderEstanteria : MonoBehaviour
{
    public Slider slider;
    public GameObject prefabInstanciado; // arrastras el objeto instanciado en escena

    private Duplicar_Estanterias duplicador;

    void Update()
    {
        if (duplicador == null && prefabInstanciado != null)
        {
            duplicador = prefabInstanciado.GetComponent<Duplicar_Estanterias>();
        }
    }


    void Start()
    {
        if (prefabInstanciado != null)
        {
            duplicador = prefabInstanciado.GetComponent<Duplicar_Estanterias>();
        }

        slider.onValueChanged.AddListener(OnSliderChanged);
    }

    void OnSliderChanged(float valor)
    {
        if (duplicador != null)
        {
            duplicador.CambiarAltura(valor);
        }
    }
}*/
