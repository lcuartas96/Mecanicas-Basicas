using UnityEngine;

public class CamaraControl : MonoBehaviour
{
    [Header("Seguir Jugador")]
    public Transform jugador;
    public Vector3 offset;

    [Header("Mover Cámara")]
    public Transform posicionObjetivo;
    public Transform posicionObjetivofrente; // NUEVO: segundo punto de destino
    public float velocidad = 1.0f;

    private bool modoSeguir = true;
    private bool mover = false;
    private bool volver = false;
    private bool mover2 = false; // NUEVO: flag para segundo destino

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
            mover2 = false;
        }

        // Volver a posición inicial
        if (Input.GetKeyDown(KeyCode.N))
        {
            modoSeguir = false;
            volver = true;
            mover = false;
            mover2 = false;
        }

        // Cambiar a segundo punto
        if (Input.GetKeyDown(KeyCode.J))
        {
            modoSeguir = false;
            mover2 = true;
            mover = false;
            volver = false;
        }

        // Activar modo seguir jugador manualmente
        if (Input.GetKeyDown(KeyCode.S))
        {
            modoSeguir = true;
            mover = false;
            volver = false;
            mover2 = false;
        }

        /*
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
        */
        if (modoSeguir && jugador != null)
        {
            transform.position = jugador.position + offset;
        }

        if (mover)
        {
            MoverHacia(posicionObjetivo.position, posicionObjetivo.rotation, ref mover);
        }
        else if (volver)
        {
            MoverHacia(posicionInicio, rotacionInicio, ref volver);
        }
        else if (mover2)
        {
            MoverHacia(posicionObjetivofrente.position, posicionObjetivofrente.rotation, ref mover2);
        }

    }

    void MoverHacia(Vector3 destinoPos, Quaternion destinoRot, ref bool flag)
    {
        transform.position = Vector3.Lerp(transform.position, destinoPos, velocidad * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, destinoRot, velocidad * Time.deltaTime);

        // Si ya llegamos al destino
        if (Vector3.Distance(transform.position, destinoPos) < 0.01f &&
            Quaternion.Angle(transform.rotation, destinoRot) < 0.5f)
        {
            transform.position = destinoPos;
            transform.rotation = destinoRot;
            flag = false;
            //mover = false;
            //volver = false;
            // No vuelve a seguir automáticamente, solo con tecla S

        }
    }
}

/*using UnityEngine;

public class CamaraControl : MonoBehaviour
{
    [Header("Seguir Jugador")]
    public Transform jugador;
    public Vector3 offset = new Vector3(0, 2, -5); // Altura y distancia detrás del jugador

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

        // Modo seguir siempre detrás del jugador
        if (modoSeguir && jugador != null)
        {
            Vector3 posicionDeseada = jugador.position
                                     + jugador.rotation * offset;
            transform.position = Vector3.Lerp(transform.position, posicionDeseada, velocidad * Time.deltaTime);

            // Mira hacia el jugador
            transform.LookAt(jugador.position + Vector3.up * 1.5f);
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
*/
