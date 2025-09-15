using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewSystem : MonoBehaviour
{
    [SerializeField]
    private float previewYOffset = 0f;

    [SerializeField]
    private GameObject cellIndicator;
    public GameObject previewObject;

    [SerializeField]
    //private Material previewMaterialsPrefab;
    //private Material previewMaterialInstance;

    private Renderer cellIndicatorRenderer;

    private void Start()
    {
        //previewMaterialInstance = new Material(previewMaterialsPrefab);
        cellIndicator.SetActive(false);
        cellIndicatorRenderer = cellIndicator.GetComponentInChildren<Renderer>();
    }

    public void StartShowingPlacementPreview(GameObject prefab, Vector2Int size)
    {
        previewObject = Instantiate(prefab);
        PreparePreavie(previewObject);
        PrepareCursor(size);
        cellIndicator.SetActive(true);
    }

    private void PrepareCursor(Vector2Int size)
    {
       if(size.x > 0 || size.y > 0)
        {
            cellIndicator.transform.localScale = new Vector3(size.x, 1, size.y);
            //cellIndicator.GetComponentInChildren<Renderer>().material.mainTextureScale = size;
            cellIndicatorRenderer.material.mainTextureScale = size;
        }
    }

    private void PreparePreavie(GameObject previewObject)
    {
        Renderer[] renderers = previewObject.GetComponentsInChildren<Renderer>();

        //Renderer[] renderers = previewObject.GetComponentInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            Material[] materials = renderer.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                //materials[i] = previewMaterialInstance;
            }
            renderer.materials = materials;
        }
    }

    public void StopShowingPreview()
    {
        cellIndicator.SetActive(false);
        if(previewObject != null)
            Destroy(previewObject);


    }

    public void UpdatePosition(Vector3 position, bool validity)
    {

        if(previewObject != null) 
        {
            MovePreview(position);
          
            ApplyFeedbackToPreview(validity);
        }
       
        MoveCursor(position);
        
        ApplyFeedbackToCursor(validity);



    }
    public void UpdateRotation(float yRotation)
    {
        if (previewObject == null) return;

        previewObject.transform.rotation = Quaternion.Euler(0, yRotation, 0); // SE AGREGO PARA LA ROTACION 
    }


    /*private void ApplyFeedbackToPreview(bool validity)
    {
        Color c = validity ? Color.white : Color.red;

        c.a = 0.5f;
        //previewMaterialInstance.color = c;
    }*/

    private void ApplyFeedbackToCursor(bool validity)
    {
        Color c = validity ? Color.white : Color.red;

        c.a = 0.5f;
        cellIndicatorRenderer.material.color = c;
        
    }

    private void MoveCursor(Vector3 position)
    {
        cellIndicator.transform.position = position;
    }

    private void MovePreview(Vector3 position)
    {
        previewObject.transform.position = new Vector3(
            position.x,
            position.y + previewYOffset,
            position.z);

    }

    internal void StartShowingRemovePreview()
    {
        cellIndicator.SetActive(true);
        PrepareCursor(Vector2Int.one);
        ApplyFeedbackToCursor(false);
    }

    // Dentro de PreviewSystem.cs
    private void ApplyFeedbackToPreview(bool validity) // COLOR DE VALIDACION 
    {
        Color c = validity ? Color.white : Color.red;
        c.a = 0.5f;

        Renderer[] renderers = previewObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in renderers)
        {
            foreach (Material mat in rend.materials)
            {
                mat.color = c;
            }
        }
    }
}
