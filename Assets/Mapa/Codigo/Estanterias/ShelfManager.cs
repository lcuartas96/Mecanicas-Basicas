using UnityEngine;

public class ShelfManager : MonoBehaviour
{
    // Asigna tus prefabs en el Inspector de Unity
    public GameObject shelfPrefab1;
    public GameObject shelfPrefab2;

    // Asigna los GameObjects vacíos de conexión de cada prefab en el Inspector
    public Transform connectionPointPrefab1;
    public Transform connectionPointPrefab2;

    void Start()
    {
        // 1. Instanciar los prefabs
        GameObject shelfInstance1 = Instantiate(shelfPrefab1, Vector3.zero, Quaternion.identity);
        GameObject shelfInstance2 = Instantiate(shelfPrefab2, new Vector3(5, 0, 0), Quaternion.identity);

        // 2. Encontrar los puntos de conexión en los objetos instanciados
        Transform connectionPointInstance1 = FindChildByName(shelfInstance1.transform, connectionPointPrefab1.name);
        Transform connectionPointInstance2 = FindChildByName(shelfInstance2.transform, connectionPointPrefab2.name);

        if (connectionPointInstance1 != null && connectionPointInstance2 != null)
        {
            // 3. Unir las estanterías
            Vector3 offset = connectionPointInstance1.position - connectionPointInstance2.position;
            shelfInstance2.transform.position += offset;
        }
        else
        {
            Debug.LogError("No se pudieron encontrar los puntos de conexión. Asegúrate de que los nombres coincidan.");
        }
    }

    // Método de utilidad para encontrar un hijo por su nombre, útil si los objetos tienen una jerarquía compleja
    private Transform FindChildByName(Transform parent, string childName)
    {
        foreach (Transform child in parent)
        {
            if (child.name == childName)
            {
                return child;
            }
            // Si el objeto no se encuentra, buscar recursivamente en sus hijos
            Transform result = FindChildByName(child, childName);
            if (result != null)
            {
                return result;
            }
        }
        return null;
    }
}
