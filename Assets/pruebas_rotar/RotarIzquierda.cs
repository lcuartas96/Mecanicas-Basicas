using UnityEngine;

public class RotarIzquierda : MonoBehaviour
{
    public float velocidadRotacion = 50f;

    // Esta función la llamará el botón
    public void RotarALaIzquierda()
    {
        transform.Rotate(Vector3.up, -velocidadRotacion * Time.deltaTime);
    }
}
