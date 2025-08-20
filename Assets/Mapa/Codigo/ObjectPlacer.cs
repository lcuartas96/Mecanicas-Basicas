using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> placedGameOjbect = new();

    // Referencia al script ZonaProhibida
    private ZonaProhibida zonaProhibida;

    /*public int PlaceObject(GameObject prefab, Vector3 position)
    {

        GameObject newObject = Instantiate(prefab);
        newObject.transform.position = position;
        placedGameOjbect.Add(newObject);
        return placedGameOjbect.Count - 1;
    }*/

    private void Start()
    {
        // Encuentra la zona prohibida en la escena al inicio
        zonaProhibida = FindObjectOfType<ZonaProhibida>();
    }

    public int PlaceObject(GameObject prefab, Vector3 position, float yRotation)
    {


        // 1. Verifica si la zona prohibida existe y si la posición es válida.
        //    (Necesitarías una forma de pasar la posición del objeto a verificar)
        //    Aquí, la validación se haría en el script que llama a PlaceObject.

        // Ejemplo: Si el script que te llama es "Colocador"
        // en Colocador:
        // if(zonaProhibida.PuedeColocar())
        // {
        //     objectPlacer.PlaceObject(prefab, position, yRotation);
        // }

        // El método original de PlaceObject no cambia,
        // la lógica de validación se haría ANTES de llamarlo.

        GameObject newObject = Instantiate(prefab, position, Quaternion.Euler(0, yRotation, 0));
        placedGameOjbect.Add(newObject);
        return placedGameOjbect.Count - 1; // SE AGREGO PARA LA ROTACION
    }

    internal void RemoveObjectAt(int gameObjectIndex)
    {
        if (placedGameOjbect.Count <= gameObjectIndex || placedGameOjbect[gameObjectIndex] == null)
            return;
        Destroy(placedGameOjbect[gameObjectIndex]);
        placedGameOjbect[gameObjectIndex] = null;
    }
}
