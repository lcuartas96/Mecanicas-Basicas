using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto_mover : MonoBehaviour
{
    private Mover_Banda currentBelt;
    private Vector3 currentDirection;

    private void Start()
    {
        currentDirection = Vector3.forward; // dirección por defecto
    }

    public void SetActiveBelt(Mover_Banda belt)
    {
        currentBelt = belt;
        currentDirection = belt.moveDirection;
    }

    public void UpdateDirection(Vector3 newDir)
    {
        currentDirection = newDir;
    }

    private void FixedUpdate()
    {
        if (currentBelt != null && currentBelt.IsActive())
        {
            transform.position += currentDirection.normalized * currentBelt.beltSpeed * Time.fixedDeltaTime;
        }
    }
}
