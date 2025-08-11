using UnityEngine;

public class ControlMontacargas : MonoBehaviour
{
    public float velocidadMovimiento = 5f; // Velocidad al avanzar/retroceder
    public float velocidadGiro = 100f;     // Velocidad al girar

    void Update()
    {
        // Movimiento adelante y atrás (flechas arriba/abajo)
        float mover = Input.GetAxis("Vertical") * velocidadMovimiento * Time.deltaTime;

        // Giro izquierda/derecha (flechas izquierda/derecha)
        float girar = Input.GetAxis("Horizontal") * velocidadGiro * Time.deltaTime;

        // Aplicar movimiento y rotación
        transform.Translate(Vector3.forward * mover);
        transform.Rotate(Vector3.up * girar);
    }
}
