using UnityEngine;

public class CamaraSeguirCaja : MonoBehaviour
{
    public float distancia = 1.5f;           // Qué tan cerca se pone
    public float altura = 0.8f;              // Altura de vista
    public float velocidadMovimiento = 5f;   // Suavidad
    public float velocidadRotacion = 5f;

    private Transform objetivo;              // Caja a seguir

    void Update()
    {
        // Si hay caja seleccionada
        if (SeleccionCaja.cajaSeleccionada != null)
        {
            objetivo = SeleccionCaja.cajaSeleccionada.transform;
        }

        if (objetivo != null)
        {
            // Posición delante de la caja
            Vector3 frenteCaja = objetivo.position - objetivo.forward * distancia + Vector3.up * altura;

            // Mover cámara suavemente
            transform.position = Vector3.Lerp(transform.position, frenteCaja, Time.deltaTime * velocidadMovimiento);

            // Rotar cámara para mirar a la caja
            Quaternion rotDeseada = Quaternion.LookRotation(objetivo.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotDeseada, Time.deltaTime * velocidadRotacion);
        }
    }
}
