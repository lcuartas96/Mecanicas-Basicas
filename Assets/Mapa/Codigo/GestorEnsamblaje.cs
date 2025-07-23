// Script 4: GestorEnsamblaje.cs - Maneja el sistema general de ensamblaje
using UnityEngine;
using System.Collections.Generic;

public class GestorEnsamblaje : MonoBehaviour
{
    [Header("Configuración Global")]
    public List<PiezaTetris> todasLasPiezas = new List<PiezaTetris>();
    public bool mostrarDebugInfo = true;

    [Header("Estadísticas")]
    public int piezasEnsambladas = 0;
    public int totalPiezas = 0;

    void Start()
    {
        // Encontrar todas las piezas en la escena
        PiezaTetris[] piezasEnEscena = FindObjectsOfType<PiezaTetris>();
        todasLasPiezas.AddRange(piezasEnEscena);
        totalPiezas = todasLasPiezas.Count;

        Debug.Log($"Sistema de ensamblaje iniciado con {totalPiezas} piezas");
    }

    void Update()
    {
        if (mostrarDebugInfo)
        {
            ActualizarEstadisticas();
        }
    }

    void ActualizarEstadisticas()
    {
        piezasEnsambladas = 0;
        foreach (PiezaTetris pieza in todasLasPiezas)
        {
            if (pieza != null && pieza.estaEnsamblada)
            {
                piezasEnsambladas++;
            }
        }
    }

    public void ReiniciarEnsamblaje()
    {
        foreach (PiezaTetris pieza in todasLasPiezas)
        {
            if (pieza != null)
            {
                pieza.estaEnsamblada = false;

                // Remover joints existentes
                FixedJoint[] joints = pieza.GetComponents<FixedJoint>();
                foreach (FixedJoint joint in joints)
                {
                    DestroyImmediate(joint);
                }

                // Resetear puntos de conexión
                foreach (PuntoConexion punto in pieza.puntosConexion)
                {
                    if (punto != null)
                    {
                        punto.estaOcupado = false;
                    }
                }
            }
        }

        Debug.Log("Ensamblaje reiniciado");
    }

    void OnGUI()
    {
        if (mostrarDebugInfo)
        {
            GUI.Label(new Rect(10, 10, 300, 20), $"Piezas Ensambladas: {piezasEnsambladas}/{totalPiezas}");

            if (GUI.Button(new Rect(10, 40, 150, 30), "Reiniciar Ensamblaje"))
            {
                ReiniciarEnsamblaje();
            }
        }
    }
}
