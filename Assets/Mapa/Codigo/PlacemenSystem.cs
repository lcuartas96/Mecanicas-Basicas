using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacemenSystem : MonoBehaviour
{

    //[SerializeField]
    //GameObject mouseIndicator,cellIndicator;
    [SerializeField]
    private InputManager inputManager;
    [SerializeField]
    private Grid grid;

    [SerializeField]
    private ObjectsDatabaseSO database;
    //private int selectedObjectIndex = -1;

    [SerializeField]
    private GameObject gridVisualization;
    [SerializeField]
    private AudioClip correctPlacementClip, wrongPlacementClip;
    [SerializeField]
    private AudioSource source;


    private GridData floorData, furnitureData;

    //private Renderer previewRenderer;

    //private List<GameObject> placedGameOjbect = new();

    [SerializeField]
    private PreviewSystem preview;

    private Vector3Int lastDetectedPosition = Vector3Int.zero;

    [SerializeField]
    private ObjectPlacer objectPlacer;

    //bool isRemoving;

    IBuildingState buildingState;


    private void Start()
    {
        StopPlacement();
        floorData = new();
        furnitureData = new();
        //previewRenderer = cellIndicator.GetComponentInChildren<Renderer>();



    }

    public void StartPlacement(int ID)
    {
        StopPlacement();
        gridVisualization.SetActive(true);
        buildingState = new PlacementState(ID,
                                           grid,
                                           preview,
                                           database,
                                           floorData,
                                           furnitureData,
                                           objectPlacer);
        inputManager.OnClicked += PlaceStructure;
        inputManager.OnExit += StopPlacement;

        /*selectedObjectIndex = database.objectsData.FindIndex(data => data.ID == ID);
        if(selectedObjectIndex < 0)
        {
            Debug.LogError($"No ID found {ID}");
            return;


        }
        gridVisualization.SetActive(true);
        preview.StartShowingPlacementPreview(
            database.objectsData[selectedObjectIndex].Prefab,
            database.objectsData[selectedObjectIndex].Size);
        //cellIndicator.SetActive(true);
        inputManager.OnClicked += PlaceStructure;
        inputManager.OnExit += StopPlacement;*/

 } 

   public void StartRemoving()
   {
       StopPlacement();
       gridVisualization.SetActive(true);
       buildingState = new RemovingState(grid, preview, floorData, furnitureData, objectPlacer);
       inputManager.OnClicked += PlaceStructure;
       inputManager.OnExit += StopPlacement;
   }

   private void PlaceStructure()
   {
       if(inputManager.IsPointerOverUI())
       {
           return;
       }

       Vector3 mousePosition = inputManager.GetSelectedMapPosition();
       Vector3Int gridPosition = grid.WorldToCell(mousePosition);

       buildingState.OnAction(gridPosition);

       /*bool placementValidity = CheckPlacementValidity(gridPosition, selectedObjectIndex);
       if (placementValidity == false)
       {
           //source.PlayOneShot(wrongPlacemenClip);
           return;
       }


       //source.Play();
       //source.PlayOneShot(correctPlacementClip);
       int index = objectPlacer.PlaceObject(database.objectsData[selectedObjectIndex].Prefab, grid.CellToWorld(gridPosition));


       GridData selectedData = database.objectsData[selectedObjectIndex].ID == 0 ?
          floorData :
          furnitureData;
       selectedData.AddObjectAt(gridPosition,
           database.objectsData[selectedObjectIndex].Size,
           database.objectsData[selectedObjectIndex].ID,
           index);
       preview.UpdatePosition(grid.CellToWorld(gridPosition), false);*/

  } 

/* private bool CheckPlacementValidity(Vector3Int gridPosition, int selectedObjectIndex)
 {
     GridData selectedData = database.objectsData[selectedObjectIndex].ID == 0 ? 
         floorData : 
         furnitureData;

     return selectedData.CanPlaceObejcAt(gridPosition, database.objectsData[selectedObjectIndex].Size);
 }*/

private void StopPlacement()
{
    if (buildingState == null)
        return;
    //selectedObjectIndex = -1;
    gridVisualization.SetActive(false);
    //cellIndicator.SetActive(false);
    //preview.StopShowingPreview();
    buildingState.EndState();
    inputManager.OnClicked -= PlaceStructure;
    inputManager.OnExit -= StopPlacement;
    lastDetectedPosition = Vector3Int.zero;
    buildingState = null;

}

private void Update()
{

    if (buildingState == null)
        return;
    Vector3 mousePosition = inputManager.GetSelectedMapPosition();
    Vector3Int gridPosition = grid.WorldToCell(mousePosition);

    if(lastDetectedPosition != gridPosition)
    {
        buildingState.UpdateState(gridPosition);
        lastDetectedPosition = gridPosition;
    }

    // 👉 Aquí agregas la entrada para rotar:
    if (Input.GetKeyDown(KeyCode.R))  // ROTA CON LA TECLA R
    {
        buildingState.RotatePreview();
    }
}

}