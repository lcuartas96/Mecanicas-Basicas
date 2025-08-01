using System.Collections.Generic;
using UnityEngine;

public class TutorialMenu : MonoBehaviour
{
    public List<GameObject> paginas;
    public GameObject panel;  // 👉 Asegúrate de tener esto

    private int indicePaginaActual = 0;

    void Start()
    {
        MostrarPagina(indicePaginaActual);
    }

    public void Siguiente()
    {
        if (indicePaginaActual < paginas.Count - 1)
        {
            indicePaginaActual++;
            MostrarPagina(indicePaginaActual);
        }
    }

    public void Atras()
    {
        if (indicePaginaActual > 0)
        {
            indicePaginaActual--;
            MostrarPagina(indicePaginaActual);
        }
    }

    public void Finalizar()
    {
        Debug.Log("Tutorial terminado");
        panel.SetActive(false);  // 👉 OJO: apaga el panel, no solo este GameObject
    }

    void MostrarPagina(int index)
    {
        for (int i = 0; i < paginas.Count; i++)
        {
            paginas[i].SetActive(i == index);
        }
    }
}
