/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnInventarioBodega : MonoBehaviour
{

    public GameObject prebafInstancia; //Prefab a instanciar
    public Transform posicionInstancia; // Punto en el que vamos a realizar la instancia
    public string nombre, descripcion;
    public GameObject objetoEscena; // Referencia al objeto desactivado

    [Header("Orientación")]
    public Vector3 rotacionPersonalizada = Vector3.zero;

    /// <summary>
    /// Metodo utilizado para instanciar las piezas que vamos a armar en el punto deseado
    /// </summary>
    public void InstanciarPieza()
    {
        if (posicionInstancia == null)
        {
            Debug.LogWarning("No se asignó un punto de colocación.");
            return;
        }

        Quaternion rotacionFinal = Quaternion.Euler(rotacionPersonalizada);

        if (objetoEscena != null)
        {
            objetoEscena.transform.position = posicionInstancia.position;
            objetoEscena.transform.rotation = rotacionFinal;
            objetoEscena.SetActive(true);
        }
        else if (prefabInstancia != null)
        {
            Instantiate(prefabInstancia, posicionInstancia.position, rotacionFinal);
        }

        this.gameObject.SetActive(false);
    }

}
}*/

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnInventarioBodega : MonoBehaviour
{
    public GameObject prefabInstancia;
    public Transform posicionInstancia;
    public string nombre, descripcion;
    public GameObject objetoEscena;

    [Header("Orientación")]
    public Vector3 rotacionPersonalizada = Vector3.zero;

    public void InstanciarPieza()
    {
        if (posicionInstancia == null)
        {
            Debug.LogWarning("No se asignó un punto de colocación.");
            return;
        }

        Quaternion rotacionFinal = Quaternion.Euler(rotacionPersonalizada);

        if (objetoEscena != null)
        {
            objetoEscena.transform.position = posicionInstancia.position;
            objetoEscena.transform.rotation = rotacionFinal;
            objetoEscena.SetActive(true);
        }
        else if (prefabInstancia != null)
        {
            Instantiate(prefabInstancia, posicionInstancia.position, rotacionFinal);
        }

        this.gameObject.SetActive(false);
    }
}*/

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnInventarioBodega : MonoBehaviour
{
    public GameObject prefabInstancia;
    public GameObject objetoEscena;

    // 🔑 Lista de índices a usar
    public List<int> indicesPuntosInstancia = new List<int>();

    // 🔑 Referencia a la lista global
    public List<Transform> puntosInstanciaGlobal = new List<Transform>();

    public string nombre, descripcion;

    [Header("Orientación")]
    public Vector3 rotacionPersonalizada = Vector3.zero;

    public void InstanciarPiezaEnTodosLosPuntos()
    {
        if (prefabInstancia == null)
        {
            Debug.LogWarning("No hay prefab asignado.");
            return;
        }

        Quaternion rotacionFinal = Quaternion.Euler(rotacionPersonalizada);

        foreach (int indice in indicesPuntosInstancia)
        {
            if (indice < 0 || indice >= puntosInstanciaGlobal.Count)
            {
                Debug.LogError($"Índice inválido: {indice}");
                continue;
            }

            Transform punto = puntosInstanciaGlobal[indice];

            // ✅ Instancia copia
            Instantiate(prefabInstancia, punto.position, rotacionFinal);
        }

        // Opcional: si quieres que el botón desaparezca después de usarse
        this.gameObject.SetActive(false);
    }
}*/

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnInventarioBodega : MonoBehaviour
{
    public GameObject prefabInstancia;
    public GameObject objetoEscena; // No lo usamos para copias, pero puede servir

    public List<int> indicesPuntosInstancia = new List<int>();   // ✅ Los índices a usar
    public List<Transform> puntosInstanciaGlobal = new List<Transform>(); // ✅ Lista global

    public string nombre, descripcion;

    [Header("Orientación")]
    public Vector3 rotacionPersonalizada = Vector3.zero;

    public void InstanciarPiezaEnTodosLosPuntos()
    {
        if (prefabInstancia == null)
        {
            
            Debug.LogWarning("No hay prefab asignado.");
            return;
        }

        Quaternion rotacionFinal = Quaternion.Euler(rotacionPersonalizada);

        foreach (int indice in indicesPuntosInstancia)
        {
            if (indice < 0 || indice >= puntosInstanciaGlobal.Count)
            {
                Debug.LogError($"Índice de punto inválido: {indice}");
                continue;
            }

            Transform punto = puntosInstanciaGlobal[indice];
            Instantiate(prefabInstancia, punto.position, rotacionFinal);
        }

        this.gameObject.SetActive(false);
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnInventarioBodega : MonoBehaviour
{
    public GameObject prebafInstancia; // Prefab a instanciar (respaldo)
    public Transform posicionInstancia; // Punto en el que vamos a realizar la instancia
    public string nombre, descripcion;
    public GameObject objetoEscena; // Referencia al objeto desactivado

    [Header("Rotación Personalizada")]
    public Vector3 rotacionPersonalizada; // 👉 Nueva rotación personalizada

    /// <summary>
    /// Metodo utilizado para instanciar las piezas que vamos a armar en el punto deseado
    /// </summary>
    public void InstanciarPieza()
    {
        if (objetoEscena != null)
        {
            Debug.Log($"Instanciando en: {posicionInstancia.position}");

            objetoEscena.transform.position = posicionInstancia.position;
            objetoEscena.transform.rotation = Quaternion.Euler(rotacionPersonalizada); // 👉 Aplica rotación personalizada

            objetoEscena.SetActive(true); // Reactiva la caja original
        }

        this.gameObject.SetActive(false); // Oculta el botón del inventario
    }
}






/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnInventarioBodega : MonoBehaviour
{
    public GameObject prefabInstancia;
    public Transform posicionInstancia;
    public string nombre, descripcion;
    public GameObject objetoEscena;

    [Header("Orientación")]
    public Vector3 rotacionPersonalizada = Vector3.zero;

    public void InstanciarPiezaMotor()
    {
        if (posicionInstancia == null)
        {
            Debug.LogWarning("No se asignó un punto de colocación.");
            return;
        }

        Quaternion rotacionFinal = Quaternion.Euler(rotacionPersonalizada);

        if (objetoEscena != null)
        {
            objetoEscena.transform.position = posicionInstancia.position;
            objetoEscena.transform.rotation = rotacionFinal;
            objetoEscena.SetActive(true);
        }
        else if (prefabInstancia != null)
        {
            Instantiate(prefabInstancia, posicionInstancia.position, rotacionFinal);
        }

        this.gameObject.SetActive(false);
    }
}*/

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnInventarioBodega : MonoBehaviour
{
    public GameObject prefabInstancia;
    public string nombre, descripcion;
    public GameObject objetoEscena;

    [Header("Orientación")]
    public Vector3 rotacionPersonalizada = Vector3.zero;

    [Header("Puntos de colocación múltiples")]
    public List<Transform> posiblesPuntosInstancia = new List<Transform>();

    private int puntoActual = 0; // 👉 Controla en qué punto vas

    public void InstanciarPiezaMotor()
    {
        if (posiblesPuntosInstancia == null || posiblesPuntosInstancia.Count == 0)
        {
            Debug.LogWarning("No se asignaron puntos de colocación.");
            return;
        }

        if (puntoActual >= posiblesPuntosInstancia.Count)
        {
            Debug.Log("Ya se usaron todos los puntos de colocación.");
            return;
        }

        Transform puntoSeleccionado = posiblesPuntosInstancia[puntoActual];
        Quaternion rotacionFinal = Quaternion.Euler(rotacionPersonalizada);

        if (objetoEscena != null)
        {
            objetoEscena.transform.position = puntoSeleccionado.position;
            objetoEscena.transform.rotation = rotacionFinal;
            objetoEscena.SetActive(true);
        }
        else if (prefabInstancia != null)
        {
            Instantiate(prefabInstancia, puntoSeleccionado.position, rotacionFinal);
        }

        puntoActual++; // 👉 Pasa al siguiente punto la próxima vez
    }
}*/



/*using UnityEngine;

public class BtnInventarioBodega : MonoBehaviour
{
    public GameObject prefabInstancia;
    public Transform posicionInstancia;
    public string nombre, descripcion;
    public GameObject objetoEscena;

    [Header("Orientación")]
    public Vector3 rotacionPersonalizada = Vector3.zero;

    public void InstanciarPiezaMotor()
    {
        if (posicionInstancia == null)
        {
            Debug.LogWarning("No se asignó un punto de colocación.");
            return;
        }

        Quaternion rotacionFinal = Quaternion.Euler(rotacionPersonalizada);

        if (objetoEscena != null)
        {
            objetoEscena.transform.position = posicionInstancia.position;
            objetoEscena.transform.rotation = rotacionFinal;
            objetoEscena.SetActive(true);
        }
        else if (prefabInstancia != null)
        {
            Instantiate(prefabInstancia, posicionInstancia.position, rotacionFinal);
        }

        this.gameObject.SetActive(false);
    }
}
*/