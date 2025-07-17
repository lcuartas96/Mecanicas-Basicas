using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton_Camara_caja : MonoBehaviour
{
    public GameObject Boton;
    // Start is called before the first frame update
    void Start()
    {
        if (Boton != null)
            Boton.SetActive(false); // asegura que el boton inicie oculto

    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Algo ha entrado al trigger: " + other.name); // Verificar qué entra en el trigger
        if (other.CompareTag("Player")) // Asegurar que el objeto que entra es el jugador//if (other.gameObject.CompareTag("Material") && other.gameObject.CompareTag("Usuario")) // Asegurar que el objeto que entra es el jugador
        {
            Debug.Log("¡El jugador ha entrado en el trigger!");
            Boton.SetActive(true); // Mostrar el botón
        }

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))// if (other.gameObject.CompareTag("Material") && other.gameObject.CompareTag("Usuario"))
        {
            Boton.SetActive(false); // Ocultar el botón
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
