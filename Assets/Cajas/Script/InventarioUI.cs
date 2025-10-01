/*using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InventarioUI : MonoBehaviour
{
    public GameObject buttonPrefab; // Prefab del botón
    public Transform contentPanel;  // Contenedor de los botones (dentro del panel del inventario)
    public Transform puntoInstancia; // Punto de instancia de las piezas
    private GameObject prefabSeleccionado; // El prefab seleccionado actualmente
    private int contadorInstancias; // Para limitar la cantidad de objetos en el inventario

    /// <summary>
    /// Metodo implementado al momento de agregar nuevos objetos al inventario
    /// </summary>
    /// <param name="icono"> El icono que tendrá el boton</param>
    /// <param name="prefab"> El prefab que instanciará ese boton </param>
    /// <param name="nombreBoton"> El nombre del objeto que tendrá el boton </param>
    public void AgregarAlInventario(Sprite icono, GameObject prefab, string nombreBoton, string descripcionPieza)
    {
        if (contadorInstancias < 13) // Si hay menos de 13 piezas en el inventario
        {
            prefabSeleccionado = prefab; // Asignamos el prefab

            GameObject nuevoBoton = Instantiate(buttonPrefab, contentPanel);// Instanciamos el boton en el inventario
            Image iamgenIcono = nuevoBoton.GetComponentInChildren<Image>(); // Obtenemos el componenete imagen
            iamgenIcono.sprite = icono; // Asignamos la imagen al boton

            TextMeshProUGUI textoBoton = nuevoBoton.GetComponentInChildren<TextMeshProUGUI>(); // Obtenemos el componente texto
            textoBoton.text = nombreBoton; // Asignamos el texto al boton

            btnInventario btnInventario = nuevoBoton.GetComponent<btnInventario>(); // Obtenemos el componenete inventario
            btnInventario.prebafInstancia = prefabSeleccionado; // Agregamos el prefab seleccionado
            btnInventario.posicionInstancia = puntoInstancia; // Le Asignamos el punto de instancia
            btnInventario.descripcion = descripcionPieza; // Agregamos la descripcion de la pieza
            btnInventario.nombre = nombreBoton; // Agregamos la descripcion de la pieza
   
            Button btn = nuevoBoton.GetComponent<Button>(); // Obtenemos el componenete button
            btn.onClick.AddListener(btnInventario.InstanciarPiezaMotor); // Agregamos la acción al botón
        }
        contadorInstancias += 1; // Aumentamos el contador
    }    
}
*/

/*using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InventarioUI : MonoBehaviour
{
    public GameObject buttonPrefab; // Prefab del botón
    public Transform contentPanel;  // Contenedor de los botones (dentro del panel del inventario)
    public Transform[] puntosInstancia; // Varios puntos de instancia
    private GameObject prefabSeleccionado; // El prefab seleccionado actualmente
    private int contadorInstancias; // Para limitar la cantidad de objetos en el inventario*/

/*public void AgregarAlInventario(Sprite icono, GameObject prefab, string nombreBoton, string descripcionPieza)
{
    if (contadorInstancias < 13)
    {
        prefabSeleccionado = prefab;

        GameObject nuevoBoton = Instantiate(buttonPrefab, contentPanel);
        Image imagenIcono = nuevoBoton.GetComponentInChildren<Image>();
        imagenIcono.sprite = icono;

        TextMeshProUGUI textoBoton = nuevoBoton.GetComponentInChildren<TextMeshProUGUI>();
        textoBoton.text = nombreBoton;

        btnInventario btnInventario = nuevoBoton.GetComponent<btnInventario>();
        btnInventario.prebafInstancia = prefabSeleccionado;

        // Asignación secuencial del punto de instancia
        btnInventario.posicionInstancia = puntosInstancia[contadorInstancias % puntosInstancia.Length];

        btnInventario.descripcion = descripcionPieza;
        btnInventario.nombre = nombreBoton;

        Button btn = nuevoBoton.GetComponent<Button>();
        btn.onClick.AddListener(btnInventario.InstanciarPiezaMotor);
    }
    contadorInstancias += 1;
}*/

/* public void AgregarAlInventario(Sprite icono, GameObject prefab, string nombreBoton, string descripcionPieza)
 {
     if (contadorInstancias < 13)
     {
         prefabSeleccionado = prefab;

         GameObject nuevoBoton = Instantiate(buttonPrefab, contentPanel);
         Image imagenIcono = nuevoBoton.GetComponentInChildren<Image>();
         imagenIcono.sprite = icono;

         TextMeshProUGUI textoBoton = nuevoBoton.GetComponentInChildren<TextMeshProUGUI>();
         textoBoton.text = nombreBoton;

         btnInventario btnInventario = nuevoBoton.GetComponent<btnInventario>();
         btnInventario.prebafInstancia = prefabSeleccionado;

         // Asignación aleatoria del punto de instancia
         btnInventario.posicionInstancia = puntosInstancia[Random.Range(0, puntosInstancia.Length)];

         btnInventario.descripcion = descripcionPieza;
         btnInventario.nombre = nombreBoton;

         Button btn = nuevoBoton.GetComponent<Button>();
         btn.onClick.AddListener(btnInventario.InstanciarPiezaMotor);

         contadorInstancias += 1;
     }
 }

}*/


/*using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InventarioUI : MonoBehaviour
{
    public GameObject buttonPrefab; // Prefab del botón
    public Transform contentPanel;  // Contenedor de los botones (dentro del panel del inventario)
    public Transform[] puntosInstancia; // Varios puntos de instancia
    private GameObject prefabSeleccionado; // El prefab seleccionado actualmente
    private int contadorInstancias; // Para limitar la cantidad de objetos en el inventario

    public void AgregarAlInventario(Sprite icono, GameObject prefab, string nombreBoton, string descripcionPieza)
    {
        if (contadorInstancias < 13)
        {
            prefabSeleccionado = prefab;

            GameObject nuevoBoton = Instantiate(buttonPrefab, contentPanel);
            Image imagenIcono = nuevoBoton.GetComponentInChildren<Image>();
            imagenIcono.sprite = icono;

            TextMeshProUGUI textoBoton = nuevoBoton.GetComponentInChildren<TextMeshProUGUI>();
            textoBoton.text = nombreBoton;

            btnInventario btnInventario = nuevoBoton.GetComponent<btnInventario>();
            btnInventario.prebafInstancia = prefabSeleccionado;

            // Asignación secuencial del punto de instancia
            btnInventario.posicionInstancia = puntosInstancia[contadorInstancias % puntosInstancia.Length];

            btnInventario.descripcion = descripcionPieza;
            btnInventario.nombre = nombreBoton;

            Button btn = nuevoBoton.GetComponent<Button>();
            btn.onClick.AddListener(btnInventario.InstanciarPiezaMotor);
        }
        contadorInstancias += 1;
    }
}*/



/*using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InventarioUI : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform contentPanel;
    public Transform[] puntosInstancia;
    private int contadorInstancias;


    public static GameObject objetoSeleccionado; // <- Objeto que está listo para colocarse

    // Este método se llama cuando el jugador presiona el botón del inventario
    public void SeleccionarObjeto(GameObject prefab)
    {
        objetoSeleccionado = prefab;
        Debug.Log("Objeto seleccionado: " + prefab.name);
    }

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

            btnInventario btn = nuevoBoton.GetComponent<btnInventario>();
            btn.prebafInstancia = prefab; // Solo como respaldo
            btn.objetoEscena = objetoEscena; // El objeto real desactivado
            btn.posicionInstancia = puntosInstancia[contadorInstancias % puntosInstancia.Length];
            btn.descripcion = descripcionPieza;
            btn.nombre = nombreBoton;

            Button botonUI = nuevoBoton.GetComponent<Button>();
            botonUI.onClick.AddListener(btn.InstanciarPiezaMotor);

            contadorInstancias += 1;
        }
    }
}*/ // original


/*using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InventarioUI : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform contentPanel;
    public Transform[] puntosInstancia; // fallback si no existe "posicion1"
    private int contadorInstancias;


    public void AgregarAlInventario(Sprite icono, GameObject prefab, string nombreBoton, string descripcionPieza, GameObject objetoEscena)
    {
        if (contadorInstancias < 13)
        {
            GameObject nuevoBoton = Instantiate(buttonPrefab, contentPanel);

            // Asignar icono
            Image imagenIcono = nuevoBoton.GetComponentInChildren<Image>();
            if (imagenIcono != null)
                imagenIcono.sprite = icono;

            // Asignar texto
            TextMeshProUGUI textoBoton = nuevoBoton.GetComponentInChildren<TextMeshProUGUI>();
            if (textoBoton != null)
                textoBoton.text = nombreBoton;

            // Configurar botón inventario
            btnInventario btn = nuevoBoton.GetComponent<btnInventario>();
            btn.prebafInstancia = prefab;       // respaldo
            btn.objetoEscena = objetoEscena;    // el objeto real desactivado
            btn.descripcion = descripcionPieza;
            btn.nombre = nombreBoton;

            // Buscar dentro del objeto en escena el hijo llamado "posicion1"
            Transform punto = objetoEscena.transform.Find("posicion1");

            if (punto != null)
            {
                btn.posicionInstancia = punto;  // usamos el hijo del prefab
            }
            else
            {
                // si no encuentra "posicion1", usa la lista del inspector como respaldo
                btn.posicionInstancia = puntosInstancia[contadorInstancias % puntosInstancia.Length];
            }

            // Agregar acción al botón
            Button botonUI = nuevoBoton.GetComponent<Button>();
            botonUI.onClick.AddListener(btn.InstanciarPiezaMotor);

            contadorInstancias += 1;
        }
    }


}*/

/*using UnityEngine;
using UnityEngine.UI;

public class btnInventario : MonoBehaviour
{
    public GameObject prebafInstancia;   // prefab de la estantería
    public GameObject objetoEscena;      // respaldo (puede quedar pero no se usa para el spawn)
    public Transform posicionInstancia;  // fallback
    public string nombre;
    public string descripcion;


    public void InstanciarPiezaMotor()
    {
        if (prebafInstancia == null)
        {
            Debug.LogError("btnInventario: No hay prefab asignado.");
            return;
        }

        // Instanciar la estantería
        GameObject nuevaEstanteria = Instantiate(prebafInstancia);
        nuevaEstanteria.SetActive(true);

        // Buscar el hijo llamado "posicion1" en la estantería recién creada
        Transform punto = FindChildRecursive(nuevaEstanteria.transform, "posicion1");

        if (punto != null)
        {
            Debug.Log("btnInventario: Encontré 'posicion1' en la estantería clonada.");
            // Aquí colocas la caja en 'posicion1' (puedes instanciar tu prefab de caja en vez de un cubo básico)
            GameObject caja = GameObject.CreatePrimitive(PrimitiveType.Cube);
            caja.transform.SetParent(punto, false); // se alinea a la posición/rotación local del punto
        }
        else if (posicionInstancia != null)
        {
            Debug.Log("btnInventario: No encontré 'posicion1', uso fallback.");
            GameObject caja = GameObject.CreatePrimitive(PrimitiveType.Cube);
            caja.transform.position = posicionInstancia.position;
            caja.transform.rotation = posicionInstancia.rotation;
        }
        else
        {
            Debug.LogWarning("btnInventario: No encontré 'posicion1' ni fallback para colocar la caja.");
        }
    }

    private Transform FindChildRecursive(Transform parent, string name)
    {
        if (parent.name == name) return parent;
        foreach (Transform child in parent)
        {
            Transform found = FindChildRecursive(child, name);
            if (found != null) return found;
        }
        return null;
    }


}*/

/*using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InventarioUI : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform contentPanel;
    public Transform[] puntosInstancia; // respaldo
    private int contadorInstancias;


public void AgregarAlInventario(Sprite icono, GameObject prefab, string nombreBoton, string descripcionPieza, GameObject objetoEscena)
    {
        if (contadorInstancias < 13)
        {
            GameObject nuevoBoton = Instantiate(buttonPrefab, contentPanel);

            // Asignar icono
            Image imagenIcono = nuevoBoton.GetComponentInChildren<Image>();
            if (imagenIcono != null)
                imagenIcono.sprite = icono;

            // Asignar texto
            TextMeshProUGUI textoBoton = nuevoBoton.GetComponentInChildren<TextMeshProUGUI>();
            if (textoBoton != null)
                textoBoton.text = nombreBoton;

            // Configurar botón inventario
            btnInventario btn = nuevoBoton.GetComponent<btnInventario>();
            btn.prebafInstancia = prefab;        // el prefab de la estantería
            btn.objetoEscena = objetoEscena;     // el objeto desactivado (respaldo)
            btn.descripcion = descripcionPieza;
            btn.nombre = nombreBoton;

            // fallback: si no encuentra "posicion1" en el prefab instanciado, usará este punto
            if (puntosInstancia != null && puntosInstancia.Length > 0)
            {
                btn.posicionInstancia = puntosInstancia[contadorInstancias % puntosInstancia.Length];
            }

            // Acción del botón
            Button botonUI = nuevoBoton.GetComponent<Button>();
            botonUI.onClick.AddListener(btn.InstanciarPiezaMotor);

            contadorInstancias += 1;
        }
    }


}*/

using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InventarioUI : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform contentPanel;
    private int contadorInstancias;


    public static GameObject objetoSeleccionado; // Objeto listo para colocarse

    // Cuando se presiona un botón del inventario
    public void SeleccionarObjeto(GameObject prefab)
    {
        objetoSeleccionado = prefab;
        Debug.Log("Objeto seleccionado: " + prefab.name);
    }

    public void AgregarAlInventario(Sprite icono, GameObject prefab, string nombreBoton, string descripcionPieza, GameObject objetoEscena)
    {
        if (contadorInstancias < 13)
        {
            GameObject nuevoBoton = Instantiate(buttonPrefab, contentPanel);

            // Asignar icono
            Image imagenIcono = nuevoBoton.GetComponentInChildren<Image>();
            if (imagenIcono != null)
                imagenIcono.sprite = icono;

            // Asignar texto
            TextMeshProUGUI textoBoton = nuevoBoton.GetComponentInChildren<TextMeshProUGUI>();
            if (textoBoton != null)
                textoBoton.text = nombreBoton;

            // Configurar info del botón
            btnInventario btn = nuevoBoton.GetComponent<btnInventario>();
            btn.prebafInstancia = prefab;
            btn.objetoEscena = objetoEscena;
            btn.descripcion = descripcionPieza;
            btn.nombre = nombreBoton;

            // Listener -> seleccionar el objeto
            Button botonUI = nuevoBoton.GetComponent<Button>();
            botonUI.onClick.AddListener(() => SeleccionarObjeto(prefab));

            contadorInstancias += 1;
        }
    }


}
