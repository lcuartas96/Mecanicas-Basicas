using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientos_Montacarga : MonoBehaviour
{
    // Asigna estos objetos en el Inspector de Unity.
    // Assign these objects in the Unity Inspector.
    // Puedes asignar cada tubo individualmente aquí.
    // You can assign each tube individually here.
    public List<Transform> mastTubes;

    // Asigna el objeto que contiene las horquillas para el movimiento lateral.
    // Assign the object that contains the forks for lateral movement.
    public Transform forkCarriage;      // "H_Mover_Izq-Der" de tu jerarquía

    public float liftSpeed = 5.0f;
    public float sideShiftSpeed = 5.0f;

    // Límites de movimiento (ajusta estos valores según tu modelo)
    // Movement limits (adjust these values according to your model)
    public float maxLiftHeight = 10.0f;
    public float minLiftHeight = 0.0f;
    public float maxSideShift = 0.5f;
    public float minSideShift = -0.5f;

    // Variables internas para controlar la dirección del movimiento
    // Internal variables to control movement direction
    private Dictionary<Transform, float> _currentTubeDirections = new Dictionary<Transform, float>();
    private float _currentShiftDirection = 0f;

    private void Start()
    {
        // Inicializa el diccionario para cada tubo.
        // Initialize the dictionary for each tube.
        foreach (var tube in mastTubes)
        {
            _currentTubeDirections.Add(tube, 0f);
        }
    }

    private void Update()
    {
        // Mueve cada tubo individualmente según su dirección.
        // Move each tube individually according to its direction.
        foreach (var tube in mastTubes)
        {
            HandleIndividualLiftMovement(tube);
        }
        HandleSideShiftMovement();
    }

    private void HandleIndividualLiftMovement(Transform tube)
    {
        if (_currentTubeDirections.ContainsKey(tube))
        {
            float liftMovement = _currentTubeDirections[tube] * liftSpeed * Time.deltaTime;
            Vector3 newLiftPosition = tube.localPosition + new Vector3(0, liftMovement, 0);

            // Limita la posición para que no se salga de los límites.
            // Clamp the position to stay within the limits.
            newLiftPosition.y = Mathf.Clamp(newLiftPosition.y, minLiftHeight, maxLiftHeight);

            tube.localPosition = newLiftPosition;
        }
    }

    private void HandleSideShiftMovement()
    {
        float sideShiftMovement = _currentShiftDirection * sideShiftSpeed * Time.deltaTime;
        Vector3 newSideShiftPosition = forkCarriage.localPosition + new Vector3(sideShiftMovement, 0, 0);

        // Limita la posición para que no se salga de los límites.
        // Clamp the position to stay within the limits.
        newSideShiftPosition.x = Mathf.Clamp(newSideShiftPosition.x, minSideShift, maxSideShift);

        forkCarriage.localPosition = newSideShiftPosition;
    }

    // Métodos públicos para controlar el movimiento de cada tubo individualmente.
    // Public methods to control the movement of each tube individually.
    public void StartLiftingUp(int tubeIndex)
    {
        if (tubeIndex >= 0 && tubeIndex < mastTubes.Count)
        {
            _currentTubeDirections[mastTubes[tubeIndex]] = 1f;
        }
    }

    public void StartLiftingDown(int tubeIndex)
    {
        if (tubeIndex >= 0 && tubeIndex < mastTubes.Count)
        {
            _currentTubeDirections[mastTubes[tubeIndex]] = -1f;
        }
    }

    public void StopLifting(int tubeIndex)
    {
        if (tubeIndex >= 0 && tubeIndex < mastTubes.Count)
        {
            _currentTubeDirections[mastTubes[tubeIndex]] = 0f;
        }
    }

    // Métodos para el movimiento lateral de las horquillas.
    // Methods for the lateral movement of the forks.
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
