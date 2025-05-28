/*using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InventarioUI : MonoBehaviour
{
    public GameObject buttonPrefab; // Prefab del bot�n
    public Transform contentPanel;  // Contenedor de los botones (dentro del panel del inventario)
    public Transform puntoInstancia; // Punto de instancia de las piezas
    private GameObject prefabSeleccionado; // El prefab seleccionado actualmente
    private int contadorInstancias; // Para limitar la cantidad de objetos en el inventario

    /// <summary>
    /// Metodo implementado al momento de agregar nuevos objetos al inventario
    /// </summary>
    /// <param name="icono"> El icono que tendr� el boton</param>
    /// <param name="prefab"> El prefab que instanciar� ese boton </param>
    /// <param name="nombreBoton"> El nombre del objeto que tendr� el boton </param>
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
            btn.onClick.AddListener(btnInventario.InstanciarPiezaMotor); // Agregamos la acci�n al bot�n
        }
        contadorInstancias += 1; // Aumentamos el contador
    }    
}
*/

using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InventarioUI : MonoBehaviour
{
    public GameObject buttonPrefab; // Prefab del bot�n
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

            // Asignaci�n secuencial del punto de instancia
            btnInventario.posicionInstancia = puntosInstancia[contadorInstancias % puntosInstancia.Length];

            btnInventario.descripcion = descripcionPieza;
            btnInventario.nombre = nombreBoton;

            Button btn = nuevoBoton.GetComponent<Button>();
            btn.onClick.AddListener(btnInventario.InstanciarPiezaMotor);
        }
        contadorInstancias += 1;
    }
}
