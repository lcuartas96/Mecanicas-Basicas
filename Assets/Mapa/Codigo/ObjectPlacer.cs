using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> placedGameOjbect = new();

    public int PlaceObject(GameObject prefab, Vector3 position)
    {

        GameObject newObject = Instantiate(prefab);
        newObject.transform.position = position;
        placedGameOjbect.Add(newObject);
        return placedGameOjbect.Count - 1;
    }

    internal void RemoveObjectAt(int gameObjectIndex)
    {
        if (placedGameOjbect.Count <= gameObjectIndex || placedGameOjbect[gameObjectIndex] == null)
            return;
        Destroy(placedGameOjbect[gameObjectIndex]);
        placedGameOjbect[gameObjectIndex] = null;
    }
}
