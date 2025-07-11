using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovingState : IBuildingState
{

    private int gameObjectIndex = -1;
    Grid grid;
    PreviewSystem previewSystem;
    GridData floorData;
    GridData furnitureData;
    ObjectPlacer objectPlacer;

    public RemovingState(Grid grid,
                         PreviewSystem previewSystem,
                         GridData floorData,
                         GridData furnitureData,
                         ObjectPlacer objectPlacer)
    {
        this.grid = grid;
        this.previewSystem = previewSystem;
        this.floorData = floorData;
        this.furnitureData = furnitureData;
        this.objectPlacer = objectPlacer;

        previewSystem.StartShowingRemovePreview();
    }

    public void EndState()
    {
        previewSystem.StopShowingPreview();
    }

    public void OnAction(Vector3Int gridPosition)
    {
        GridData selectedData = null;
        if(furnitureData.CanPlaceObejcAt(gridPosition,Vector2Int.one) == false)
        {
            selectedData = furnitureData;
        }else if (floorData.CanPlaceObejcAt(gridPosition,Vector2Int.one) == false)
        {
            selectedData = floorData;
        }

        if(selectedData == null)
        {

        }
        else
        {
          //  gameObjectIndex = selectedData.GetRepresentationIndex(gridPosition);
        }

    }

    public void UpdateState(Vector3Int gridPosition)
    {
        throw new System.NotImplementedException();
    }

    //SoundFeedback soundFeedback;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
