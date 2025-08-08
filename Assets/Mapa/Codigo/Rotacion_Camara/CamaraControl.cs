using UnityEngine;

public class CamaraControl : MonoBehaviour
{
    [Header("Seguir Jugador")]
    public Transform jugador;
    public Vector3 offset;

    [Header("Mover Cámara")]
    public Transform posicionObjetivo;
    public float velocidad = 1.0f;

    private bool modoSeguir = true;
    private bool mover = false;
    private bool volver = false;

    private Vector3 posicionInicio;
    private Quaternion rotacionInicio;

    void Start()
    {
        // Guardar posición inicial de la cámara
        posicionInicio = transform.position;
        rotacionInicio = transform.rotation;

        // Si no defines offset, lo calcula automáticamente
        if (offset == Vector3.zero && jugador != null)
        {
            offset = transform.position - jugador.position;
        }
    }

    void LateUpdate()
    {
        // Cambiar a modo mover cámara
        if (Input.GetKeyDown(KeyCode.M))
        {
            modoSeguir = false;
            mover = true;
            volver = false;
        }

        // Volver a posición inicial
        if (Input.GetKeyDown(KeyCode.N))
        {
            modoSeguir = false;
            volver = true;
            mover = false;
        }

        // Activar modo seguir jugador manualmente
        if (Input.GetKeyDown(KeyCode.S))
        {
            modoSeguir = true;
            mover = false;
            volver = false;
        }

        // Si estamos en modo seguir
        if (modoSeguir && jugador != null)
        {
            transform.position = jugador.position + offset;
        }

        // Si estamos moviendo la cámara
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

        // Si ya llegamos al destino
        if (Vector3.Distance(transform.position, destinoPos) < 0.01f &&
            Quaternion.Angle(transform.rotation, destinoRot) < 0.5f)
        {
            transform.position = destinoPos;
            transform.rotation = destinoRot;
            mover = false;
            volver = false;
            // No vuelve a seguir automáticamente, solo con tecla S

        }
    }
}
