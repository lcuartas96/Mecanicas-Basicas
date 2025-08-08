using UnityEngine;

public class MoverCamara : MonoBehaviour
{
    public Transform posicionObjetivo; // Asigna aquí la posición final
    public float velocidad = 1.0f;      // Velocidad del movimiento
    private bool mover = false;        // Controla si debe empezar a moverse

    private bool volver = false; // declaro para volver a la posicion inicial

    Vector3 posicionInicio; //  Guardamos la posicion de inicio
    Quaternion rotacionInicio; //  Guardamos la rotacion de inicio 

    public SeguirJugador seguirJugador; // referencia al otro script

    private void Start()
    {
        posicionInicio = this.transform.position; //  Guardamos la posicion de inicio
        rotacionInicio = this.transform.rotation; //  Guardamos la rotacion de inicio 
    }
    void Update()
    {
        

        // Inicia el movimiento cuando presionas una tecla, por ejemplo 'M'
        if (Input.GetKeyDown(KeyCode.M))
        {
            mover = true;
            volver = false;

            // desactivar seguir jugador
            seguirJugador.enabled = false;
        }

        // Volver a la posición inicial 
        if (Input.GetKeyDown(KeyCode.N))
        {
            volver = true;
            mover = false;

            // desactivar seguir jugador
            seguirJugador.enabled = false;
        }


        if (mover) 
        {
            MoverHacia(posicionObjetivo.position, posicionObjetivo.rotation);
        }
        else if (volver)
        {
            MoverHacia(posicionInicio, rotacionInicio);
        }
    }

    void MoverHacia(Vector3 destinoPos, Quaternion destinoRot)
    {
        transform.position = Vector3.Lerp(transform.position, destinoPos, velocidad * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, destinoRot, velocidad * Time.deltaTime);

        if (Vector3.Distance(transform.position, destinoPos) < 0.01f &&
            Quaternion.Angle(transform.rotation, destinoRot) < 0.5f)
        {
            transform.position = destinoPos;
            transform.rotation = destinoRot;
            mover = false;
            volver = false;
        }
    }

}
