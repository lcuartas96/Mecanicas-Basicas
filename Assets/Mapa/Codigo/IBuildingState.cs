using UnityEngine;

public interface IBuildingState
{
    void EndState();
    void OnAction(Vector3Int gridPosition);
    void UpdateState(Vector3Int gridPosition);
    void RotatePreview(); // 👈 ahora sí existe en la interfaz
}