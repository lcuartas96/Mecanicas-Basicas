using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara_Control_dos : MonoBehaviour
{
    [Header("Seguir Jugador")]
    public Transform jugador;
    public Vector3 offset = new Vector3(0, 2, 5); // Por defecto: 2 arriba, 5 detrás

    [Header("Mover Cámara")]
    public Transform posicionObjetivo;        // Tecla M
    public Transform posicionObjetivo_enc_2;  // Tecla B
    public Transform posicionObjetivofrente; // Tecla J
    public Transform posicionObjetivofrente_2;// Tecla L
    public Transform posicionObjetivofrente_3;// Tecla K

    public float velocidad = 5.0f;

    private bool modoSeguir = true;
    private bool mover = false, mover2 = false, mover3 = false, mover4 = false, mover5 = false, volver = false;
    private Vector3 posicionInicio;
    private Quaternion rotacionInicio;

    void Start()
    {
        posicionInicio = transform.position;
        rotacionInicio = transform.rotation;
    }

    void LateUpdate()
    {
        // --- Teclas para cambiar modo ---
        if (Input.GetKeyDown(KeyCode.M)) ActivarMover(ref mover);
        if (Input.GetKeyDown(KeyCode.J)) ActivarMover(ref mover2);
        if (Input.GetKeyDown(KeyCode.L)) ActivarMover(ref mover3);
        if (Input.GetKeyDown(KeyCode.K)) ActivarMover(ref mover4);
        if (Input.GetKeyDown(KeyCode.B)) ActivarMover(ref mover5);
        if (Input.GetKeyDown(KeyCode.N)) ActivarMover(ref volver);
        if (Input.GetKeyDown(KeyCode.S)) modoSeguir = true; // Volver a seguimiento

        // --- Modo seguir jugador ---
        if (modoSeguir && jugador != null)
        {
            Vector3 posicionDetras = jugador.position - jugador.forward * offset.z + Vector3.up * offset.y;
            transform.position = Vector3.Lerp(transform.position, posicionDetras, velocidad * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(jugador.position - transform.position), velocidad * Time.deltaTime);
        }
        else
        {
            // --- Mover a destino ---
            if (mover) MoverHacia(posicionObjetivo.position, posicionObjetivo.rotation, ref mover);
            else if (mover2) MoverHacia(posicionObjetivofrente.position, posicionObjetivofrente.rotation, ref mover2);
            else if (mover3) MoverHacia(posicionObjetivofrente_2.position, posicionObjetivofrente_2.rotation, ref mover3);
            else if (mover4) MoverHacia(posicionObjetivofrente_3.position, posicionObjetivofrente_3.rotation, ref mover4);
            else if (mover5) MoverHacia(posicionObjetivo_enc_2.position, posicionObjetivo_enc_2.rotation, ref mover5);
            else if (volver) MoverHacia(posicionInicio, rotacionInicio, ref volver);
        }
    }

    void ActivarMover(ref bool flag)
    {
        modoSeguir = false;
        mover = mover2 = mover3 = mover4 = mover5 = volver = false;
        flag = true;
    }

    void MoverHacia(Vector3 destinoPos, Quaternion destinoRot, ref bool flag)
    {
        transform.position = Vector3.Lerp(transform.position, destinoPos, velocidad * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, destinoRot, velocidad * Time.deltaTime);

        if (Vector3.Distance(transform.position, destinoPos) < 0.01f &&
            Quaternion.Angle(transform.rotation, destinoRot) < 0.5f)
        {
            transform.position = destinoPos;
            transform.rotation = destinoRot;
            flag = false;
        }
    }
}
