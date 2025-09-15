using UnityEngine;

public class CamaraControl : MonoBehaviour
{

    [Header("Seguir Jugador")]
    public Transform jugador;
    public Vector3 offset;

    [Header("Mover Cámara")]
    public Transform posicionObjetivo; // TECLA M punto 1
    public Transform posicionObjetivo_enc_2; // TECLA H punto 5
    public Transform posicionObjetivofrente; // NUEVO: segundo punto de destino (tecla J)
    public Transform posicionObjetivofrente_2; //  punto (tecla L) punto 3
    public Transform posicionObjetivofrente_3; // punto (tecla K) punto 4
    //public Transform posicionMontacargas; // 👈 NUEVO punto para el montacargas

    [HideInInspector] public bool modoMontacargas = false;
    public Transform posicionMontacargas; // punto de cámara del montacargas

    public float velocidad = 1.0f;
    [HideInInspector] public bool modoSeguir = true;
    //public bool modoSeguir = true;
    private bool mover = false;
    private bool volver = false;
    private bool mover2 = false; // NUEVO: flag para segundo destino
    private bool mover3 = false;
    private bool mover4 = false; //mover a punto Tecla K
    private bool mover5 = false; // mover a punto Tecla H 
    private bool moverMontacargas = false; // 👈 NUEVO flag para montacargas

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

        // Modo montacargas: sigue posición y rotación del montacargas
        if (modoMontacargas && posicionMontacargas != null)
        {
            transform.position = posicionMontacargas.position;
            transform.rotation = posicionMontacargas.rotation;
            return; // no hacer nada más
        }

        // ----------- CONTROLES TECLAS MANUALES -------------
        if (Input.GetKeyDown(KeyCode.M))
        {
            modoSeguir = false;
            mover = true;
            ResetFlagsExcept(ref mover);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            modoSeguir = false;
            volver = true;
            ResetFlagsExcept(ref volver);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            modoSeguir = false;
            mover2 = true;
            ResetFlagsExcept(ref mover2);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            modoSeguir = false;
            mover3 = true;
            ResetFlagsExcept(ref mover3);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            modoSeguir = false;
            mover4 = true;
            ResetFlagsExcept(ref mover4);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            modoSeguir = false;
            mover5 = true;
            ResetFlagsExcept(ref mover5);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            modoSeguir = true;
            mover = volver = mover2 = mover3 = mover4 = mover5 = moverMontacargas = false;
        }

        // ----------- LÓGICA DE MOVIMIENTO -------------
        if (modoSeguir && jugador != null)
        {
            transform.position = jugador.position + offset;
        }

        if (mover) MoverHacia(posicionObjetivo.position, posicionObjetivo.rotation, ref mover);
        else if (volver) MoverHacia(posicionInicio, rotacionInicio, ref volver);
        else if (mover2) MoverHacia(posicionObjetivofrente.position, posicionObjetivofrente.rotation, ref mover2);
        else if (mover3) MoverHacia(posicionObjetivofrente_2.position, posicionObjetivofrente_2.rotation, ref mover3);
        else if (mover4) MoverHacia(posicionObjetivofrente_3.position, posicionObjetivofrente_3.rotation, ref mover4);
        else if (mover5) MoverHacia(posicionObjetivo_enc_2.position, posicionObjetivo_enc_2.rotation, ref mover5);
        else if (moverMontacargas && posicionMontacargas != null)
            MoverHacia(posicionMontacargas.position, posicionMontacargas.rotation, ref moverMontacargas);
    }

    void MoverHacia(Vector3 destinoPos, Quaternion destinoRot, ref bool flag)
    {
        transform.position = Vector3.Lerp(transform.position, destinoPos, velocidad * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, destinoRot, velocidad * Time.deltaTime);

        if (Vector3.Distance(transform.position, destinoPos) < 0.01f &&
            Quaternion.Angle(transform.rotation, destinoRot) < 0.5f)
        {
            transform.position = destinoPos;
            transform.rotation = destinoRot;
            flag = false;
        }
    }

    private void ResetFlagsExcept(ref bool flagToKeep)
    {
        mover = volver = mover2 = mover3 = mover4 = mover5 = moverMontacargas = false;
        flagToKeep = true;
    }

    // 👇 Método público para que lo use MontacargasController
    public void IrAMontacargas()
    {
        modoSeguir = false;
        ResetFlagsExcept(ref moverMontacargas);
    }


    /* antes 
    // Cambiar a modo mover cámara
    if (Input.GetKeyDown(KeyCode.M))
    {
        modoSeguir = false;
        mover = true;
        volver = mover2 = mover3 = mover4 = mover5 = false;

    }

    // Volver a posición inicial
    if (Input.GetKeyDown(KeyCode.N))
    {
        modoSeguir = false;
        volver = true;
        mover = mover2 = mover3 = mover4 = mover5 = false;

    }

    // Cambiar a segundo punto
    if (Input.GetKeyDown(KeyCode.J))
    {
        modoSeguir = false;
        mover2 = true;
        mover = volver = mover3 = mover4 = mover5 = false;

    }

    // Cambiar a tercer punto
    if (Input.GetKeyDown(KeyCode.L))
    {
        modoSeguir = false;
        mover3 = true;
        mover = volver = mover2 = mover4 = mover5 = false;
    }

    // Cambiar a cuarto punto 
    if (Input.GetKeyDown(KeyCode.K))
    {
        modoSeguir = false;
        mover4 = true;
        mover = volver = mover2 = mover3 = mover5 = false;
    }

    // cambiar a quinto punto
    if (Input.GetKeyDown(KeyCode.B))
    {
        modoSeguir = false;
        mover5 = true;
        mover = volver = mover2 = mover3 = mover4 = false;
    }

    // Activar modo seguir jugador manualmente
    if (Input.GetKeyDown(KeyCode.S))
    {

        modoSeguir = true;
        mover = volver = mover2 = mover3 = mover4 = mover5 = false;

    }*/


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
    /*
     * 
     * antes
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
    else if (mover3)
    {
        MoverHacia(posicionObjetivofrente_2.position, posicionObjetivofrente_2.rotation, ref mover3);
    }
    else if (mover4)
    {
        MoverHacia(posicionObjetivofrente_3.position, posicionObjetivofrente_3.rotation, ref mover4);
    }
    else if (mover5)
    {
        MoverHacia(posicionObjetivo_enc_2.position, posicionObjetivo_enc_2.rotation, ref mover5);
    }


    */

}

/*
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


}*/

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
