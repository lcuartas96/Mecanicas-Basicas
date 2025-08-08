using UnityEngine;

public class SeguirJugador : MonoBehaviour
{
    public Transform jugador; // Asigna el objeto del jugador en el Inspector
    public Vector3 offset;    // Distancia entre cámara y jugador

    public MoverCamara moverCamara; // referencia al otro script

    void Start()
    {
        // Si no defines un offset en el Inspector, toma el actual
        if (offset == Vector3.zero && jugador != null)
        {
            offset = transform.position - jugador.position;
        }
    }

    void LateUpdate()
    {
        // Ejemplo: presionando "S" vuelve al modo seguir
        if (Input.GetKeyDown(KeyCode.S))
        {
            moverCamara.enabled = false; // desactiva movimiento de cámara
            this.enabled = true;         // activa seguimiento
        }

        if (jugador != null)
        {
            transform.position = jugador.position + offset;
        }
    }
}
