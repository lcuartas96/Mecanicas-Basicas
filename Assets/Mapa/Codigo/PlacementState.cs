/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementState : IBuildingState
{


    private int selectedObjectIndex = -1;
    int ID;
    Grid grid;
    PreviewSystem previewSystem;
    ObjectsDatabaseSO database;
    GridData floorData;
    GridData furnitureData;
    ObjectPlacer objectPlacer;

    private float currentRotation = 0f; // 👉 NUEVO

    public PlacementState(int iD,
                          Grid grid,
                          PreviewSystem previewSystem,
                          ObjectsDatabaseSO database,
                          GridData floorData,
                          GridData furnitureData,
                          ObjectPlacer objectPlacer)
    {
        ID = iD;
        this.grid = grid;
        this.previewSystem = previewSystem;
        this.database = database;
        this.floorData = floorData;
        this.furnitureData = furnitureData;
        this.objectPlacer = objectPlacer;

        selectedObjectIndex = database.objectsData.FindIndex(data => data.ID == ID);
        if (selectedObjectIndex > -1)
        {
            //gridVisualization.SetActive(true);
            previewSystem.StartShowingPlacementPreview(
                database.objectsData[selectedObjectIndex].Prefab,
                database.objectsData[selectedObjectIndex].Size);

        }
        else
            throw new System.Exception($"No object with ID {iD}");


    }

    public void EndState()
    {
        previewSystem.StopShowingPreview();

    }
    public void OnAction(Vector3Int gridPosition)
    {

        bool placementValidity = CheckPlacementValidity(gridPosition, selectedObjectIndex);
        if (placementValidity == false)
        {

            return;
        }


        int index = objectPlacer.PlaceObject(database.objectsData[selectedObjectIndex].Prefab, grid.CellToWorld(gridPosition));


        GridData selectedData = database.objectsData[selectedObjectIndex].ID == 0 ?
           floorData :
           furnitureData;
        selectedData.AddObjectAt(gridPosition,
            database.objectsData[selectedObjectIndex].Size,
            database.objectsData[selectedObjectIndex].ID,
            index);
        previewSystem.UpdatePosition(grid.CellToWorld(gridPosition), false);
    }

    private bool CheckPlacementValidity(Vector3Int gridPosition, int selectedObjectIndex)
    {
        GridData selectedData = database.objectsData[selectedObjectIndex].ID == 0 ?
            floorData :
            furnitureData;

        return selectedData.CanPlaceObejcAt(gridPosition, database.objectsData[selectedObjectIndex].Size);
    }

    public void UpdateState(Vector3Int gridPosition)
    {
        bool placementValidity = CheckPlacementValidity(gridPosition, selectedObjectIndex);

        previewSystem.UpdatePosition(grid.CellToWorld(gridPosition), placementValidity);

    }
  

}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementState : IBuildingState
{
    private int selectedObjectIndex = -1;
    int ID;
    Grid grid;
    PreviewSystem previewSystem;
    ObjectsDatabaseSO database;
    GridData floorData;
    GridData furnitureData;
    ObjectPlacer objectPlacer;
    // Añade la referencia
    //private ZonaProhibida zonaProhibida; NO VA

    private float currentRotation = 0f; // 👉 NUEVO para la rotacion

    public PlacementState(int iD,
                          Grid grid,
                          PreviewSystem previewSystem,
                          ObjectsDatabaseSO database,
                          GridData floorData,
                          GridData furnitureData,
                          ObjectPlacer objectPlacer)
                         //ZonaProhibida zonaProhibida)
    {
        ID = iD;
        this.grid = grid;
        this.previewSystem = previewSystem;
        this.database = database;
        this.floorData = floorData;
        this.furnitureData = furnitureData;
        this.objectPlacer = objectPlacer;
        //this.zonaProhibida = zonaProhibida;

        selectedObjectIndex = database.objectsData.FindIndex(data => data.ID == ID);
        if (selectedObjectIndex > -1)
        {
            previewSystem.StartShowingPlacementPreview(
                database.objectsData[selectedObjectIndex].Prefab,
                database.objectsData[selectedObjectIndex].Size);
        }
        else
            throw new System.Exception($"No object with ID {iD}");
    }

    public void EndState()
    {
        previewSystem.StopShowingPreview();
    }

    public void OnAction(Vector3Int gridPosition)
    {
        /* bool placementValidity = CheckPlacementValidity(gridPosition, selectedObjectIndex);
         if (!placementValidity) return;*/

        bool placementValidity = CheckPlacementValidity(gridPosition, selectedObjectIndex);
        bool isProhibited = IsOverlappingProhibitedZone(gridPosition);

        bool finalValidity = placementValidity && !isProhibited;

        if (!finalValidity)
        {
            return;
        }

        int index = objectPlacer.PlaceObject(
            database.objectsData[selectedObjectIndex].Prefab,
            grid.CellToWorld(gridPosition),
            currentRotation
        );

        GridData selectedData = database.objectsData[selectedObjectIndex].ID == 0 ?
           floorData : furnitureData;

        selectedData.AddObjectAt(
            gridPosition,
            database.objectsData[selectedObjectIndex].Size,
            database.objectsData[selectedObjectIndex].ID,
            index
        );

        previewSystem.UpdatePosition(grid.CellToWorld(gridPosition), false);
    }

    /*public void OnAction(Vector3Int gridPosition)
    {
        bool placementValidity = CheckPlacementValidity(gridPosition, selectedObjectIndex);

        // Agrega esta nueva condición:
        bool isProhibited = (zonaProhibida != null && !zonaProhibida.PuedeColocar());

        if (placementValidity == false || isProhibited)
        {
            // Opcional: Agregar un sonido o mensaje de error visual.
            return; // Detiene el método si la colocación no es válida.
        }

        // Si el código llega a este punto, significa que la colocación es válida.
        int index = objectPlacer.PlaceObject(
            database.objectsData[selectedObjectIndex].Prefab,
            grid.CellToWorld(gridPosition),
            currentRotation
        );

        GridData selectedData = database.objectsData[selectedObjectIndex].ID == 0 ?
           floorData : furnitureData;

        selectedData.AddObjectAt(
            gridPosition,
            database.objectsData[selectedObjectIndex].Size,
            database.objectsData[selectedObjectIndex].ID,
            index
        );

        previewSystem.UpdatePosition(grid.CellToWorld(gridPosition), false);
    }*/
    /*public void OnAction(Vector3Int gridPosition)
    {
        // 1. Verificar la validez de la colocación en la grilla
        bool placementValidity = CheckPlacementValidity(gridPosition, selectedObjectIndex);

        // 2. Verificar si el objeto está en una zona prohibida
        bool canPlaceInProhibitedZone = (zonaProhibida == null || zonaProhibida.PuedeColocar());

        // 3. Si alguna de las condiciones no se cumple, salir del método
        if (!placementValidity || !canPlaceInProhibitedZone)
        {
            // Puedes agregar aquí un sonido o feedback visual de error
            return;
        }

        // 4. Si la colocación es válida en ambos casos, se coloca el objeto
        int index = objectPlacer.PlaceObject(
            database.objectsData[selectedObjectIndex].Prefab,
            grid.CellToWorld(gridPosition),
            currentRotation
        );

        GridData selectedData = database.objectsData[selectedObjectIndex].ID == 0 ?
           floorData : furnitureData;

        selectedData.AddObjectAt(
            gridPosition,
            database.objectsData[selectedObjectIndex].Size,
            database.objectsData[selectedObjectIndex].ID,
            index
        );

        previewSystem.UpdatePosition(grid.CellToWorld(gridPosition), false);
    }*/


    /*public void OnAction(Vector3Int gridPosition)
    {
        bool placementValidity = CheckPlacementValidity(gridPosition, selectedObjectIndex);
        if (!placementValidity) return;

        // 👉 Ahora pasa la rotación:
        int index = objectPlacer.PlaceObject(
            database.objectsData[selectedObjectIndex].Prefab,
            grid.CellToWorld(gridPosition),
            currentRotation // pasa rotación
        );

        GridData selectedData = database.objectsData[selectedObjectIndex].ID == 0 ?
           floorData : furnitureData;

        selectedData.AddObjectAt(
            gridPosition,
            database.objectsData[selectedObjectIndex].Size,
            database.objectsData[selectedObjectIndex].ID,
            index
        );

        previewSystem.UpdatePosition(grid.CellToWorld(gridPosition), false);
    }*/


    private bool CheckPlacementValidity(Vector3Int gridPosition, int selectedObjectIndex)
    {


        GridData selectedData = database.objectsData[selectedObjectIndex].ID == 0 ?
        floorData : furnitureData;

        // Condición 1: Espacio libre en la grilla
        bool hasGridSpace = selectedData.CanPlaceObejcAt(gridPosition, database.objectsData[selectedObjectIndex].Size);

        // Condición 2: No hay zona prohibida en la posición
        Vector3 previewPosition = grid.CellToWorld(gridPosition);
        Collider[] colliders = Physics.OverlapBox(previewPosition, new Vector3(0.5f, 0.5f, 0.5f)); // Ajusta el tamaño según tu objeto

        bool isOverlappingProhibitedZone = false;
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("ZonaProhibida"))
            {
                isOverlappingProhibitedZone = true;
                break;
            }
        }

        // El objeto es válido si tiene espacio en la grilla Y NO está sobre una zona prohibida
        return hasGridSpace && !isOverlappingProhibitedZone;



        /* GridData selectedData = database.objectsData[selectedObjectIndex].ID == 0 ?
             floorData : furnitureData;

         return selectedData.CanPlaceObejcAt(gridPosition, database.objectsData[selectedObjectIndex].Size);*/
    }

    public void UpdateState(Vector3Int gridPosition)
    {
        /*bool placementValidity = CheckPlacementValidity(gridPosition, selectedObjectIndex);

        previewSystem.UpdatePosition(grid.CellToWorld(gridPosition), placementValidity);
        previewSystem.UpdateRotation(currentRotation); // 👉 APLICA ROTACIÓN AL PREVIEW
        */
        bool placementValidity = CheckPlacementValidity(gridPosition, selectedObjectIndex);

        // Se usa la función de Physics.OverlapBox que ya se había implementado.
        bool isProhibited = IsOverlappingProhibitedZone(gridPosition);

        // La validez final es si es válido en la grilla Y NO está en una zona prohibida.
        bool finalValidity = placementValidity && !isProhibited;

        previewSystem.UpdatePosition(grid.CellToWorld(gridPosition), finalValidity);
        previewSystem.UpdateRotation(currentRotation);
    }

    // Método que verifica si el objeto se superpone con una zona prohibida
    private bool IsOverlappingProhibitedZone(Vector3Int gridPosition)
    {
        Vector3 previewPosition = grid.CellToWorld(gridPosition);
        // Ajusta el tamaño del box para que coincida con la estantería de previsualización
        Collider[] colliders = Physics.OverlapBox(previewPosition, new Vector3(0.5f, 0.5f, 0.5f));

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("ZonaProhibida"))
            {
                return true;
            }
        }
        return false;
    }


    public void RotatePreview()
    {
        currentRotation += 90f;
        if (currentRotation >= 360f)
            currentRotation = 0f;
    }
}
