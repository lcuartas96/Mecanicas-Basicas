/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placemen2 : IBuildingState
{
    private int id;
    private Grid grid;
    private PreviewSystem previewSystem;
    private ObjectsDatabaseSO database;
    private GridData floorData, furnitureData;
    private ObjectPlacer objectPlacer;

    private float rotationY = 0f; // Rotación sobre Y (izq-der)
    private float rotationX = 0f; // Rotación sobre X (arriba-abajo)

    public Placemen2(
        int id,
        Grid grid,
        PreviewSystem preview,
        ObjectsDatabaseSO database,
        GridData floorData,
        GridData furnitureData,
        ObjectPlacer placer)
    {
        this.id = id;
        this.grid = grid;
        this.previewSystem = preview;
        this.database = database;
        this.floorData = floorData;
        this.furnitureData = furnitureData;
        this.objectPlacer = placer;

        // Instancia el objeto de preview
        ObjectData data = database.objectsData.Find(d => d.ID == id);
        previewSystem.StartShowingPlacementPreview(data.Prefab, data.Size);
    }

    public void EndState()
    {
        previewSystem.StopShowingPreview();
    }

    public void OnAction(Vector3Int gridPosition)
    {
        ObjectData data = database.objectsData.Find(d => d.ID == id);
        Vector3 placePosition = grid.CellToWorld(gridPosition);

        GameObject placedObject = objectPlacer.PlaceObject(data.Prefab, placePosition);
        placedObject.transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);

        GridData selectedData = id == 0 ? floorData : furnitureData;
        selectedData.AddObjectAt(gridPosition, data.Size, id, 0);

        previewSystem.UpdatePosition(placePosition, false);
    }

    public void UpdateState(Vector3Int gridPosition)
    {
        Vector3 placePosition = grid.CellToWorld(gridPosition);
        previewSystem.UpdatePosition(placePosition, true);
    }

    public void RotateObject(float yAmount, float xAmount)
    {
        rotationY += yAmount;
        rotationX += xAmount;
        previewSystem.UpdateRotation(rotationY, rotationX);
    }
}*/
