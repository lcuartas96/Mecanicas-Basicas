using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncajarPiezas : MonoBehaviour
{
    public float distanciaMaxima = 1.0f; // Distancia para encajar
    public string nombrePieza = "tuvo";
    public string nombreParte = "parte";

    private GameObject tuvo;
    private GameObject parte;

    void Start()
    {
        tuvo = GameObject.Find(nombrePieza);
        parte = GameObject.Find(nombreParte);

        if (tuvo == null || parte == null)
        {
            Debug.LogError("No se encontraron los objetos 'tuvo' o 'parte'.");
        }
    }

    void Update()
    {
        // Encuentra todos los objetos que tengan el mismo nombre que tuvo
        GameObject[] piezas = GameObject.FindGameObjectsWithTag("Pieza");

        foreach (GameObject pieza in piezas)
        {
            if (pieza.name == nombrePieza)
            {
                float distancia = Vector3.Distance(pieza.transform.position, tuvo.transform.position);

                if (distancia <= distanciaMaxima)
                {
                    // Posicionar sobre tuvo
                    pieza.transform.position = tuvo.transform.position;

                    // Revisar parte
                    float distanciaParte = Vector3.Distance(pieza.transform.position, parte.transform.position);

                    if (distanciaParte <= distanciaMaxima)
                    {
                        // Pegar como Tetris usando colliders de borde
                        EncajarComoTetris(pieza, parte);
                    }
                }
            }
        }
    }

    void EncajarComoTetris(GameObject pieza, GameObject otraPieza)
    {
        // Aquí puedes ajustar cómo encajan.
        // Por ejemplo, encajar borde derecho con borde izquierdo.
        Bounds boundsPieza = pieza.GetComponent<Collider>().bounds;
        Bounds boundsOtra = otraPieza.GetComponent<Collider>().bounds;

        Vector3 nuevaPos = otraPieza.transform.position;

        // Ejemplo simple: pegar borde derecho de pieza con borde izquierdo de otra pieza
        nuevaPos.x = boundsOtra.min.x - (boundsPieza.size.x / 2f);

        pieza.transform.position = new Vector3(nuevaPos.x, otraPieza.transform.position.y, otraPieza.transform.position.z);
    }
}

