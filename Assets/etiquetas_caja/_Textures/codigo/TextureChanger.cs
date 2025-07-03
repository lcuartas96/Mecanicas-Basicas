using UnityEngine;
using UnityEngine.UI;

public class TextureChanger : MonoBehaviour
{
    [Header("Configuración de la Caja")]
    public GameObject cajaObject; // El objeto de la caja
    public Renderer cajaRenderer; // El renderer de la caja

    [Header("Texturas Disponibles")]
    public Texture2D[] texturas; // Array de texturas disponibles
    public string[] nombresTexturas; // Nombres descriptivos de las texturas

    [Header("UI - Botones")]
    public Transform panelBotones; // Panel donde se generarán los botones
    public GameObject prefabBoton; // Prefab del botón (opcional)

    [Header("UI - Información")]
    public Text textoTexturaActual; // Texto que muestra la textura actual
    public Text textoInstrucciones; // Texto con instrucciones

    private int texturaActualIndex = 0;
    private Material materialCaja;

    void Start()
    {
        // Inicializar referencias
        InicializarComponentes();

        // Crear los botones dinámicamente
        CrearBotones();

        // Establecer la primera textura
        CambiarTextura(0);

        // Configurar UI inicial
        ActualizarUI();
    }

    void InicializarComponentes()
    {
        // Si no se asignó el renderer, intentar obtenerlo del objeto
        if (cajaRenderer == null && cajaObject != null)
        {
            cajaRenderer = cajaObject.GetComponent<Renderer>();
        }

        // Si aún no hay renderer, buscar en este objeto
        if (cajaRenderer == null)
        {
            cajaRenderer = GetComponent<Renderer>();
        }

        // Obtener o crear el material
        if (cajaRenderer != null)
        {
            materialCaja = cajaRenderer.material;
        }

        // Validar que tengamos las texturas
        if (texturas == null || texturas.Length == 0)
        {
            Debug.LogError("No se han asignado texturas al TextureChanger!");
            return;
        }

        // Si no hay nombres, crear nombres por defecto
        if (nombresTexturas == null || nombresTexturas.Length != texturas.Length)
        {
            nombresTexturas = new string[texturas.Length];
            for (int i = 0; i < texturas.Length; i++)
            {
                nombresTexturas[i] = texturas[i] != null ? texturas[i].name : $"Textura {i + 1}";
            }
        }
    }

    void CrearBotones()
    {
        if (panelBotones == null)
        {
            Debug.LogWarning("No se ha asignado el panel de botones. Los botones no se crearán automáticamente.");
            return;
        }

        // Limpiar botones existentes
        foreach (Transform child in panelBotones)
        {
            if (Application.isPlaying)
                Destroy(child.gameObject);
            else
                DestroyImmediate(child.gameObject);
        }

        // Crear un botón para cada textura
        for (int i = 0; i < texturas.Length; i++)
        {
            GameObject boton = CrearBoton(i);
            if (boton != null)
            {
                boton.transform.SetParent(panelBotones);
                boton.transform.localScale = Vector3.one;
            }
        }
    }

    GameObject CrearBoton(int index)
    {
        GameObject boton;

        if (prefabBoton != null)
        {
            // Usar el prefab proporcionado
            boton = Instantiate(prefabBoton);
        }
        else
        {
            // Crear un botón básico
            boton = new GameObject($"Boton_Textura_{index}");
            boton.AddComponent<RectTransform>();
            boton.AddComponent<CanvasRenderer>();
            boton.AddComponent<Image>();
            boton.AddComponent<Button>();

            // Configurar el botón
            RectTransform rectTransform = boton.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(100, 100);

            Image imagen = boton.GetComponent<Image>();
            imagen.color = Color.white;

            // Agregar la textura como sprite si es posible
            if (texturas[index] != null)
            {
                Sprite sprite = Sprite.Create(texturas[index],
                    new Rect(0, 0, texturas[index].width, texturas[index].height),
                    new Vector2(0.5f, 0.5f));
                imagen.sprite = sprite;
            }
        }

        // Configurar el evento del botón
        Button componenteBoton = boton.GetComponent<Button>();
        if (componenteBoton != null)
        {
            int capturedIndex = index; // Capturar el índice para el closure
            componenteBoton.onClick.AddListener(() => CambiarTextura(capturedIndex));
        }

        return boton;
    }

    public void CambiarTextura(int index)
    {
        // Validar el índice
        if (index < 0 || index >= texturas.Length)
        {
            Debug.LogError($"Índice de textura fuera de rango: {index}");
            return;
        }

        // Validar que la textura existe
        if (texturas[index] == null)
        {
            Debug.LogError($"La textura en el índice {index} es null");
            return;
        }

        // Validar que tenemos el material
        if (materialCaja == null)
        {
            Debug.LogError("No se encontró el material de la caja");
            return;
        }

        // Cambiar la textura
        materialCaja.mainTexture = texturas[index];
        texturaActualIndex = index;

        // Actualizar la UI
        ActualizarUI();

        // Log para debug
        Debug.Log($"Textura cambiada a: {nombresTexturas[index]}");
    }

    void ActualizarUI()
    {
        if (textoTexturaActual != null)
        {
            textoTexturaActual.text = $"Textura Actual: {nombresTexturas[texturaActualIndex]}";
        }

        if (textoInstrucciones != null)
        {
            textoInstrucciones.text = "Haz clic en un botón para cambiar la textura de la caja";
        }
    }

    // Métodos públicos para usar desde otros scripts o eventos
    public void SiguienteTextura()
    {
        int siguiente = (texturaActualIndex + 1) % texturas.Length;
        CambiarTextura(siguiente);
    }

    public void TexturaAnterior()
    {
        int anterior = (texturaActualIndex - 1 + texturas.Length) % texturas.Length;
        CambiarTextura(anterior);
    }

    public void TexturaAleatoria()
    {
        int aleatoria = Random.Range(0, texturas.Length);
        CambiarTextura(aleatoria);
    }

    // Método para cambiar textura por nombre
    public void CambiarTexturaPorNombre(string nombre)
    {
        for (int i = 0; i < nombresTexturas.Length; i++)
        {
            if (nombresTexturas[i].Equals(nombre, System.StringComparison.OrdinalIgnoreCase))
            {
                CambiarTextura(i);
                return;
            }
        }
        Debug.LogWarning($"No se encontró una textura con el nombre: {nombre}");
    }

    // Método para obtener información de la textura actual
    public string ObtenerInfoTexturaActual()
    {
        if (texturaActualIndex >= 0 && texturaActualIndex < texturas.Length)
        {
            Texture2D texturaActual = texturas[texturaActualIndex];
            return $"Nombre: {nombresTexturas[texturaActualIndex]}\n" +
                   $"Resolución: {texturaActual.width}x{texturaActual.height}\n" +
                   $"Formato: {texturaActual.format}";
        }
        return "No hay textura seleccionada";
    }

    void Update()
    {
        // Controles con teclado (opcional)
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SiguienteTextura();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            TexturaAnterior();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            TexturaAleatoria();
        }
    }
}