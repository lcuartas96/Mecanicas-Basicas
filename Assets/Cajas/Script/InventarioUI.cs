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



using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InventarioUI : MonoBehaviour
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
}






