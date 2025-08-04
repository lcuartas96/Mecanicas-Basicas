using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duplicar_Estanterias : MonoBehaviour
{

    public GameObject[] pisos;
    [Range(0, 4)] // un rango de 0 a 4 estanterias
    public int altura; // la altura que deseo
  

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < pisos.Length; i++)
        {
            pisos[i].SetActive(i < altura);
        }
    }
}
