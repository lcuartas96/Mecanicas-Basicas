using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Singleton
    public static CameraManager Instance { get; private set; }

    [Header("Cámaras del juego")]
    public Camera camaraPrincipal;

    private void Awake()
    {
        // Patrón Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    /// <summary>
    /// Activa la cámara principal y desactiva la cámara actual
    /// </summary>
    public void ActivarCamaraPrincipal()
    {
        if (camaraPrincipal != null)
            camaraPrincipal.gameObject.SetActive(true);
    }

    /// <summary>
    /// Desactiva la cámara principal
    /// </summary>
    public void DesactivarCamaraPrincipal()
    {
        if (camaraPrincipal != null)
            camaraPrincipal.gameObject.SetActive(false);
    }
}

