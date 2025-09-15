using UnityEngine;

public class MontacargasCamara : MonoBehaviour
{
    public Camera camaraMontacargas;

    public void ActivarCamaraMontacargas()
    {
        if (camaraMontacargas != null)
        {
            // Apagar la cámara principal
            CameraManager.Instance.DesactivarCamaraPrincipal();

            // Encender la cámara del montacargas
            camaraMontacargas.gameObject.SetActive(true);
        }
    }

    public void DesactivarCamaraMontacargas()
    {
        if (camaraMontacargas != null)
        {
            // Apagar la cámara del montacargas
            camaraMontacargas.gameObject.SetActive(false);

            // Encender la cámara principal
            CameraManager.Instance.ActivarCamaraPrincipal();
        }
    }
}
