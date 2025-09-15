using UnityEngine;

public class UnirEstanterias : MonoBehaviour
{
    // Prefab de la estantería que estará fija
    public GameObject estanteriaPrefab1;

    // Prefab de la estantería que se moverá para unirse
    public GameObject estanteriaPrefab2;

    // Puntos de conexión en los prefabs (referencias)
    public Transform puntoDeConexionPrefab1;
    public Transform puntoDeConexionPrefab2;

    // Instancias de las estanterías en la escena
    private GameObject instanciaEstanteria1;
    private GameObject instanciaEstanteria2;

    void Start()
    {
        // Instanciar ambas estanterías
        instanciaEstanteria1 = Instantiate(estanteriaPrefab1, new Vector3(0, 0, 0), Quaternion.identity);
        instanciaEstanteria2 = Instantiate(estanteriaPrefab2, new Vector3(5, 0, 0), Quaternion.identity); // Puedes ajustar la posición inicial

        // Unir las estanterías después de un breve momento
        Invoke("UnirEstanteriasInstanciadas", 0.1f);
    }

    void UnirEstanteriasInstanciadas()
    {
        // Asegúrate de que los puntos de conexión se encuentran dentro de las estanterías
        Transform miPuntoDeConexion = instanciaEstanteria2.transform.Find(puntoDeConexionPrefab2.name);
        Transform puntoDeConexionDeLaOtraEstanteria = instanciaEstanteria1.transform.Find(puntoDeConexionPrefab1.name);

        if (miPuntoDeConexion == null || puntoDeConexionDeLaOtraEstanteria == null)
        {
            Debug.LogError("¡No se pudieron encontrar los puntos de conexión en los objetos instanciados!");
            return;
        }

        // Calcula el desplazamiento que necesita la estantería 2
        Vector3 desplazamiento = puntoDeConexionDeLaOtraEstanteria.position - miPuntoDeConexion.position;

        // Mueve la estantería 2 para que los puntos de conexión se alineen
        instanciaEstanteria2.transform.position += desplazamiento;
    }
}