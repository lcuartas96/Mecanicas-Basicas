using UnityEngine;

public class BotonSalir : MonoBehaviour
{
    public void SalirAplicacion()
    {
        // Cierra la aplicación si está compilada (PC, móvil, etc.)
        Application.Quit();

        // Si estás en el editor de Unity, esto detiene el modo Play
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

