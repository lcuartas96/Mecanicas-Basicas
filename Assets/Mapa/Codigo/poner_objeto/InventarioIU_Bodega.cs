
/*using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InventarioIU_Bodega : MonoBehaviour
{

    public GameObject buttonPrefab;
    public Transform contentPanel;
    public Transform[] puntosInstancia;
    private int contadorInstancias;

    public void AgregarAlInventario(Sprite icono, GameObject prefab, string nombreBoton, string descripcionPieza, GameObject objetoEscena)
    {
        if (contadorInstancias < 13)
        {
            GameObject nuevoBoton = Instantiate(buttonPrefab, contentPanel);

            Image imagenIcono = nuevoBoton.GetComponentInChildren<Image>();
            if (imagenIcono != null)
                imagenIcono.sprite = icono;

            TextMeshProUGUI textoBoton = nuevoBoton.GetComponentInChildren<TextMeshProUGUI>();
            if (textoBoton != null)
                textoBoton.text = nombreBoton;

            BtnInventarioBodega btn = nuevoBoton.GetComponent<BtnInventarioBodega>();
            btn.prebafInstancia = prefab; // Solo como respaldo
            btn.objetoEscena = objetoEscena; // El objeto real desactivado
            btn.posicionInstancia = puntosInstancia[contadorInstancias % puntosInstancia.Length];
            btn.descripcion = descripcionPieza;
            btn.nombre = nombreBoton;

            Button botonUI = nuevoBoton.GetComponent<Button>();
            botonUI.onClick.AddListener(btn.InstanciarPieza);

            contadorInstancias += 1;
        }
    }
}*/

/*using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventarioIU_Bodega : MonoBehaviour
{
    [Header("Referencias UI")]
    public GameObject buttonPrefab;
    public Transform contentPanel;

    [Header("Puntos de colocación")]
    public List<Transform> puntosInstancia;

    public void AgregarAlInventario(
    Sprite icono,
    GameObject prefab,
    string nombreBoton,
    string descripcionPieza,
    GameObject objetoEscena,
    List<int> indicesPuntosInstancia,
    Vector3 rotacionPersonalizada
)
    {
        GameObject nuevoBoton = Instantiate(buttonPrefab, contentPanel);

        Image imagenIcono = nuevoBoton.GetComponentInChildren<Image>();
        if (imagenIcono != null)
            imagenIcono.sprite = icono;

        TextMeshProUGUI textoBoton = nuevoBoton.GetComponentInChildren<TextMeshProUGUI>();
        if (textoBoton != null)
            textoBoton.text = nombreBoton;

        BtnInventarioBodega btn = nuevoBoton.GetComponent<BtnInventarioBodega>();
        if (btn != null)
        {
            btn.prefabInstancia = prefab;
            btn.objetoEscena = objetoEscena;

            // 🔑 Guarda toda la lista de índices
            btn.indicesPuntosInstancia = indicesPuntosInstancia;
            btn.puntosInstanciaGlobal = puntosInstancia;

            btn.descripcion = descripcionPieza;
            btn.nombre = nombreBoton;
            btn.rotacionPersonalizada = rotacionPersonalizada;

            Button botonUI = nuevoBoton.GetComponent<Button>();
            botonUI.onClick.AddListener(btn.InstanciarPiezaEnTodosLosPuntos);
        }
        else
        {
            Debug.LogError("El prefab del botón no tiene BtnInventarioBodega.");
        }
    }

}*/

/*using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventarioIU_Bodega : MonoBehaviour
{
    [Header("Referencias UI")]
    public GameObject buttonPrefab;
    public Transform contentPanel;

    [Header("Puntos de colocación")]
    public List<Transform> puntosInstancia;

    public void AgregarAlInventario(
        Sprite icono,
        GameObject prefab,
        string nombreBoton,
        string descripcionPieza,
        GameObject objetoEscena,
        List<int> indicesPuntosInstancia,   // ✅ Lista de índices
        Vector3 rotacionPersonalizada
    )
    {
        GameObject nuevoBoton = Instantiate(buttonPrefab, contentPanel);

        Image imagenIcono = nuevoBoton.GetComponentInChildren<Image>();
        if (imagenIcono != null)
            imagenIcono.sprite = icono;

        TextMeshProUGUI textoBoton = nuevoBoton.GetComponentInChildren<TextMeshProUGUI>();
        if (textoBoton != null)
            textoBoton.text = nombreBoton;

        BtnInventarioBodega btn = nuevoBoton.GetComponent<BtnInventarioBodega>();
        if (btn != null)
        {
            btn.prefabInstancia = prefab;
            btn.objetoEscena = objetoEscena;

            btn.indicesPuntosInstancia = indicesPuntosInstancia; // ✅ Guarda lista
            btn.puntosInstanciaGlobal = puntosInstancia;         // ✅ Referencia a lista global

            btn.descripcion = descripcionPieza;
            btn.nombre = nombreBoton;
            btn.rotacionPersonalizada = rotacionPersonalizada;

            Button botonUI = nuevoBoton.GetComponent<Button>();
            botonUI.onClick.AddListener(btn.InstanciarPiezaEnTodosLosPuntos);
        }
        else
        {
            Debug.LogError("El prefab del botón no tiene BtnInventarioBodega.");
        }
    }
}*/

using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InventarioIU_Bodega : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform contentPanel;
    public Transform[] puntosInstancia;
    private int contadorInstancias;

    public void AgregarAlInventario(Sprite icono, GameObject prefab, string nombreBoton, string descripcionPieza, GameObject objetoEscena, Vector3? rotacionPersonalizada = null)
    {
        if (contadorInstancias < 13)
        {
            GameObject nuevoBoton = Instantiate(buttonPrefab, contentPanel);

            Image imagenIcono = nuevoBoton.GetComponentInChildren<Image>();
            if (imagenIcono != null)
                imagenIcono.sprite = icono;

            TextMeshProUGUI textoBoton = nuevoBoton.GetComponentInChildren<TextMeshProUGUI>();
            if (textoBoton != null)
                textoBoton.text = nombreBoton;

            BtnInventarioBodega btn = nuevoBoton.GetComponent<BtnInventarioBodega>();
            btn.prebafInstancia = prefab; // Respaldo
            btn.objetoEscena = objetoEscena; // Objeto real desactivado
            btn.posicionInstancia = puntosInstancia[contadorInstancias % puntosInstancia.Length];
            btn.descripcion = descripcionPieza;
            btn.nombre = nombreBoton;

            if (rotacionPersonalizada.HasValue)
                btn.rotacionPersonalizada = rotacionPersonalizada.Value;

            Button botonUI = nuevoBoton.GetComponent<Button>();
            botonUI.onClick.AddListener(btn.InstanciarPieza);

            contadorInstancias += 1;
        }
    }
}




/*using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventarioIU_Bodega : MonoBehaviour
{
    [Header("Referencias UI")]
    public GameObject buttonPrefab;
    public Transform contentPanel;

    [Header("Puntos de colocación")]
    public List<Transform> puntosInstancia;

    public void AgregarAlInventario(
        Sprite icono,
        GameObject prefab,
        string nombreBoton,
        string descripcionPieza,
        GameObject objetoEscena,
        int indicePunto,
        Vector3 rotacionPersonalizada // 👉 Nueva rotación personalizada
    )
    {
        if (indicePunto < 0 || indicePunto >= puntosInstancia.Count)
        {
            Debug.LogError($"Índice de punto inválido: {indicePunto}");
            return;
        }

        GameObject nuevoBoton = Instantiate(buttonPrefab, contentPanel);

        Image imagenIcono = nuevoBoton.GetComponentInChildren<Image>();
        if (imagenIcono != null)
            imagenIcono.sprite = icono;

        TextMeshProUGUI textoBoton = nuevoBoton.GetComponentInChildren<TextMeshProUGUI>();
        if (textoBoton != null)
            textoBoton.text = nombreBoton;

        BtnInventarioBodega btn = nuevoBoton.GetComponent<BtnInventarioBodega>();
        if (btn != null)
        {
            btn.prefabInstancia = prefab;
            btn.objetoEscena = objetoEscena;
            btn.posicionInstancia = puntosInstancia[indicePunto];
            btn.descripcion = descripcionPieza;
            btn.nombre = nombreBoton;

            btn.rotacionPersonalizada = rotacionPersonalizada; // 👉 Guarda ángulo personalizado

            Button botonUI = nuevoBoton.GetComponent<Button>();
            botonUI.onClick.AddListener(btn.InstanciarPiezaMotor);
        }
        else
        {
            Debug.LogError("El prefab del botón no tiene BtnInventarioBodega.");
        }
    }
}*/

/*using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventarioIU_Bodega : MonoBehaviour
{
    [Header("Referencias UI")]
    public GameObject buttonPrefab;
    public Transform contentPanel;

    [Header("Puntos de colocación")]
    public List<Transform> puntosInstancia;

    public void AgregarAlInventario(
        Sprite icono,
        GameObject prefab,
        string nombreBoton,
        string descripcionPieza,
        GameObject objetoEscena,
        //int indicePunto,
        List<int> indicesPuntosInstancia,
        Vector3 rotacionPersonalizada // 👉 Nueva rotación personalizada
    )
    {*/
/*foreach (int indicePunto in indicesPuntosInstancia)
{

    if (indicePunto < 0 || indicePunto >= puntosInstancia.Count)
    {
    Debug.LogError($"Índice de punto inválido: {indicePunto}");
    continue;
    }

    GameObject nuevoBoton = Instantiate(buttonPrefab, contentPanel);

    Image imagenIcono = nuevoBoton.GetComponentInChildren<Image>();
    if (imagenIcono != null)
        imagenIcono.sprite = icono;

    TextMeshProUGUI textoBoton = nuevoBoton.GetComponentInChildren<TextMeshProUGUI>();
    if (textoBoton != null)
        textoBoton.text = nombreBoton;

    BtnInventarioBodega btn = nuevoBoton.GetComponent<BtnInventarioBodega>();
    if (btn != null)
    {
        btn.prefabInstancia = prefab;
        btn.objetoEscena = objetoEscena;
        btn.posicionInstancia = puntosInstancia[indicePunto]; // ✅ El punto específico
       //btn.posicionInstancia = puntosInstancia[indicePunto];
        btn.descripcion = descripcionPieza;
        btn.nombre = nombreBoton;

        btn.rotacionPersonalizada = rotacionPersonalizada; // 👉 Guarda ángulo personalizado

        Button botonUI = nuevoBoton.GetComponent<Button>();
        botonUI.onClick.AddListener(btn.InstanciarPiezaMotor);
    }
    else
    {
        Debug.LogError("El prefab del botón no tiene BtnInventarioBodega.");
    }

}*/

/*GameObject nuevoBoton = Instantiate(buttonPrefab, contentPanel);

Image imagenIcono = nuevoBoton.GetComponentInChildren<Image>();
if (imagenIcono != null)
    imagenIcono.sprite = icono;

TextMeshProUGUI textoBoton = nuevoBoton.GetComponentInChildren<TextMeshProUGUI>();
if (textoBoton != null)
    textoBoton.text = nombreBoton;

BtnInventarioBodega btn = nuevoBoton.GetComponent<BtnInventarioBodega>();
if (btn != null)
{
    btn.prefabInstancia = prefab;
    btn.objetoEscena = objetoEscena;
    btn.nombre = nombreBoton;
    btn.descripcion = descripcionPieza;
    btn.rotacionPersonalizada = rotacionPersonalizada;

    btn.posiblesPuntosInstancia.Clear();
    foreach (int indice in indicesPuntosInstancia)
    {
        if (indice >= 0 && indice < puntosInstancia.Count)
            btn.posiblesPuntosInstancia.Add(puntosInstancia[indice]);
    }

    Button botonUI = nuevoBoton.GetComponent<Button>();
    botonUI.onClick.AddListener(btn.InstanciarPiezaMotor);
}
else
{
    Debug.LogError("El prefab del botón no tiene BtnInventarioBodega.");
}

}
}*/


/*using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventarioIU_Bodega : MonoBehaviour
{
    [Header("Referencias UI")]
    public GameObject buttonPrefab;
    public Transform contentPanel;

    [Header("Puntos de colocación")]
    public List<Transform> puntosInstancia;

    // 🔑 NUEVO: versión múltiple
    public void AgregarAlInventarioMultiple(
        Sprite icono,
        GameObject prefab,
        string nombreBoton,
        string descripcionPieza,
        GameObject objetoEscena,
        List<int> indicesPuntosInstancia,
        Vector3 rotacionPersonalizada
    )
    {
        foreach (int indicePunto in indicesPuntosInstancia)
        {
            if (indicePunto < 0 || indicePunto >= puntosInstancia.Count)
            {
                Debug.LogError($"Índice de punto inválido: {indicePunto}");
                continue;
            }

            GameObject nuevoBoton = Instantiate(buttonPrefab, contentPanel);

            Image imagenIcono = nuevoBoton.GetComponentInChildren<Image>();
            if (imagenIcono != null)
                imagenIcono.sprite = icono;

            TextMeshProUGUI textoBoton = nuevoBoton.GetComponentInChildren<TextMeshProUGUI>();
            if (textoBoton != null)
                textoBoton.text = nombreBoton;

            BtnInventarioBodega btn = nuevoBoton.GetComponent<BtnInventarioBodega>();
            if (btn != null)
            {
                btn.prefabInstancia = prefab;
                btn.objetoEscena = objetoEscena;
                btn.posicionInstancia = puntosInstancia[indicePunto]; // ✅ El punto específico
                btn.descripcion = descripcionPieza;
                btn.nombre = nombreBoton;

                btn.rotacionPersonalizada = rotacionPersonalizada;

                Button botonUI = nuevoBoton.GetComponent<Button>();
                botonUI.onClick.AddListener(btn.InstanciarPiezaMotor);
            }
            else
            {
                Debug.LogError("El prefab del botón no tiene BtnInventarioBodega.");
            }
        }
    }
}*/
