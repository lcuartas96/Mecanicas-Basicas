using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover_Banda : MonoBehaviour
{
    [Header("Físicas")]
    public float beltSpeed = 60f;
    public Vector3 moveDirection = Vector3.forward;

    [Header("Textura")]
    public Renderer beltRenderer;
    public float textureScrollSpeed = 0.5f;

    private bool isActive = false;
    private Vector2 textureOffset = Vector2.zero;

    private void Update()
    {
        if (isActive && beltRenderer != null)
        {
            // Calcula la dirección del scroll basada en la dirección de movimiento
            Vector2 scrollDirection = new Vector2(moveDirection.x, moveDirection.z).normalized;
            textureOffset += scrollDirection * textureScrollSpeed * Time.deltaTime;

            // Aplica la nueva offset
            beltRenderer.material.mainTextureOffset = textureOffset;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!isActive) return;

        Rigidbody rb = collision.rigidbody;
        if (rb != null)
        {
            rb.MovePosition(rb.position + moveDirection.normalized * beltSpeed * Time.fixedDeltaTime);
        }
    }

    public void ActivateBelt()
    {
        isActive = true;
    }

    public void DeactivateBelt()
    {
        isActive = false;
    }

    public bool IsActive()
    {
        return isActive;
    }

}