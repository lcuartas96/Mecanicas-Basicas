using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientos_Montacarga : MonoBehaviour
{
    // Asigna el objeto raiz del mastil aqui. En tu caso, "5m_Tubo_Base".
    // Assign the root object of the mast here. In your case, "5m_Tubo_Base".
    public Transform mastRoot;

    // Asigna el objeto que contiene las horquillas para el movimiento lateral.
    // Assign the object that contains the forks for lateral movement.
    public Transform forkCarriage;

    public float liftSpeed = 5.0f;
    public float sideShiftSpeed = 5.0f;

    // Limites de movimiento (ajusta estos valores segun tu modelo)
    // Movement limits (adjust these values according to your model)
    public float maxLiftHeight = 10.0f;
    public float minLiftHeight = 0.0f;
    public float maxSideShift = 0.5f;
    public float minSideShift = -0.5f;

    // Variables internas para controlar la direccion del movimiento
    // Internal variables to control movement direction
    private float _currentLiftDirection = 0f;
    private float _currentShiftDirection = 0f;

    private void Update()
    {
        HandleLiftMovement();
        HandleSideShiftMovement();
    }

    private void HandleLiftMovement()
    {
        // El movimiento se aplica al objeto raiz del mastil.
        // The movement is applied to the root object of the mast.
        float liftMovement = _currentLiftDirection * liftSpeed * Time.deltaTime;
        Vector3 newLiftPosition = mastRoot.localPosition + new Vector3(0, liftMovement, 0);

        // Limita la posicion para que no se salga de los limites.
        // Clamp the position to stay within the limits.
        newLiftPosition.y = Mathf.Clamp(newLiftPosition.y, minLiftHeight, maxLiftHeight);

        mastRoot.localPosition = newLiftPosition;
    }

    private void HandleSideShiftMovement()
    {
        float sideShiftMovement = _currentShiftDirection * sideShiftSpeed * Time.deltaTime;
        Vector3 newSideShiftPosition = forkCarriage.localPosition + new Vector3(sideShiftMovement, 0, 0);

        // Limita la posicion para que no se salga de los limites.
        // Clamp the position to stay within the limits.
        newSideShiftPosition.x = Mathf.Clamp(newSideShiftPosition.x, minSideShift, maxSideShift);

        forkCarriage.localPosition = newSideShiftPosition;
    }

    // Metodos publicos que seran llamados por los botones.
    // Public methods to be called by the buttons.
    public void StartLiftingUp()
    {
        _currentLiftDirection = 1f;
    }

    public void StartLiftingDown()
    {
        _currentLiftDirection = -1f;
    }

    public void StopLifting()
    {
        _currentLiftDirection = 0f;
    }

    public void StartShiftingLeft()
    {
        _currentShiftDirection = -1f;
    }

    public void StartShiftingRight()
    {
        _currentShiftDirection = 1f;
    }

    public void StopShifting()
    {
        _currentShiftDirection = 0f;
    }
}
