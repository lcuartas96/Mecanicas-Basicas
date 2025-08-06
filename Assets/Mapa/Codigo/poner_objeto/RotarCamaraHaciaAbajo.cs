using UnityEngine;

public class RotarCamaraHaciaAbajo : MonoBehaviour
{
    public float velocidadRotacion = 50f;
    public float anguloMinimo = -80f; // Máximo hacia abajo
    public float anguloMaximo = 80f;  // Máximo hacia arriba

    private float rotacionX = 0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rotacionX -= velocidadRotacion * Time.deltaTime;
            rotacionX = Mathf.Clamp(rotacionX, anguloMinimo, anguloMaximo);

            transform.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);
        }
    }
}
