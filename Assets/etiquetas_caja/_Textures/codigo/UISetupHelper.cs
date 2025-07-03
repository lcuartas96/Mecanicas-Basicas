using UnityEngine;
using UnityEngine.UI;

public class UISetupHelper : MonoBehaviour
{
    [Header("Configuración Automática")]
    public bool configurarAutomaticamente = true;
    public bool crearCanvasAutomaticamente = true;

    [Header("Referencias UI")]
    public Canvas canvas;
    public GameObject panelPrincipal;
    public GameObject panelBotones;
    public Text textoTitulo;
    public Text textoTexturaActual;
    public Text textoInstrucciones;

    [Header("Estilo UI")]
    public Color colorFondo = new Color(0.2f, 0.2f, 0.2f, 0.8f);
    public Color colorBoton = Color.white;
    public Color colorTexto = Color.white;
    public int tamañoFuenteTitulo = 24;
    public int tamañoFuenteTexto = 16;

    void Start()
    {
        if (configurarAutomaticamente)
        {
            ConfigurarUI();
        }
    }

    [ContextMenu("Configurar UI")]
    public void ConfigurarUI()
    {
        if (crearCanvasAutomaticamente && canvas == null)
        {
            CrearCanvas();
        }

        CrearPanelPrincipal();
        CrearElementosUI();
        ConfigurarTextureChanger();
    }

    void CrearCanvas()
    {
        GameObject canvasGO = new GameObject("Canvas_TextureChanger");
        canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = 10;

        // Agregar CanvasScaler
        CanvasScaler scaler = canvasGO.AddComponent<CanvasScaler>();
        scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        scaler.referenceResolution = new Vector2(1920, 1080);
        scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
        scaler.matchWidthOrHeight = 0.5f;

        // Agregar GraphicRaycaster
        canvasGO.AddComponent<GraphicRaycaster>();

        Debug.Log("Canvas creado automáticamente");
    }

    void CrearPanelPrincipal()
    {
        if (panelPrincipal == null)
        {
            panelPrincipal = new GameObject("Panel_Principal");
            panelPrincipal.transform.SetParent(canvas.transform);

            // Configurar RectTransform
            RectTransform rectTransform = panelPrincipal.AddComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.anchorMax = new Vector2(1, 1);
            rectTransform.offsetMin = new Vector2(20, 20);
            rectTransform.offsetMax = new Vector2(-20, -20);
            rectTransform.localScale = Vector3.one;

            // Agregar imagen de fondo
            Image imagen = panelPrincipal.AddComponent<Image>();
            imagen.color = colorFondo;

            // Agregar layout
            VerticalLayoutGroup layout = panelPrincipal.AddComponent<VerticalLayoutGroup>();
            layout.childAlignment = TextAnchor.UpperCenter;
            layout.childControlHeight = false;
            layout.childControlWidth = false;
            layout.childForceExpandHeight = false;
            layout.childForceExpandWidth = false;
            layout.spacing = 10;
            layout.padding = new RectOffset(20, 20, 20, 20);
        }
    }

    void CrearElementosUI()
    {
        // Crear título
        if (textoTitulo == null)
        {
            textoTitulo = CrearTexto("Titulo", "Selector de Texturas", tamañoFuenteTitulo);
            textoTitulo.alignment = TextAnchor.MiddleCenter;
            textoTitulo.fontStyle = FontStyle.Bold;
        }

        // Crear texto de textura actual
        if (textoTexturaActual == null)
        {
            textoTexturaActual = CrearTexto("TexturaActual", "Textura Actual: Ninguna", tamañoFuenteTexto);
            textoTexturaActual.alignment = TextAnchor.MiddleCenter;
        }

        // Crear panel de botones
        if (panelBotones == null)
        {
            panelBotones = new GameObject("Panel_Botones");
            panelBotones.transform.SetParent(panelPrincipal.transform);

            RectTransform rectTransform = panelBotones.AddComponent<RectTransform>();
            rectTransform.localScale = Vector3.one;
            rectTransform.sizeDelta = new Vector2(800, 200);

            // Configurar GridLayoutGroup para los botones
            GridLayoutGroup gridLayout = panelBotones.AddComponent<GridLayoutGroup>();
            gridLayout.cellSize = new Vector2(120, 120);
            gridLayout.spacing = new Vector2(10, 10);
            gridLayout.childAlignment = TextAnchor.MiddleCenter;
            gridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            gridLayout.constraintCount = 5; // 5 columnas
        }

        // Crear texto de instrucciones
        if (textoInstrucciones == null)
        {
            textoInstrucciones = CrearTexto("Instrucciones",
                "Haz clic en los botones para cambiar la textura\\n" +
                "Usa las flechas ? ? para navegar\\n" +
                "Presiona R para textura aleatoria",
                tamañoFuenteTexto - 2);
            textoInstrucciones.alignment = TextAnchor.MiddleCenter;
        }
    }

    Text CrearTexto(string nombre, string contenido, int tamañoFuente)
    {
        GameObject textoGO = new GameObject($"Text_{nombre}");
        textoGO.transform.SetParent(panelPrincipal.transform);

        RectTransform rectTransform = textoGO.AddComponent<RectTransform>();
        rectTransform.localScale = Vector3.one;
        rectTransform.sizeDelta = new Vector2(800, 50);

        Text texto = textoGO.AddComponent<Text>();
        texto.text = contenido;
        texto.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        texto.fontSize = tamañoFuente;
        texto.color = colorTexto;
        texto.alignment = TextAnchor.MiddleCenter;

        return texto;
    }

    void ConfigurarTextureChanger()
    {
        // Buscar el TextureChanger en la escena
        TextureChanger textureChanger = FindObjectOfType<TextureChanger>();

        if (textureChanger != null)
        {
            // Asignar las referencias de UI
            textureChanger.panelBotones = panelBotones.transform;
            textureChanger.textoTexturaActual = textoTexturaActual;
            textureChanger.textoInstrucciones = textoInstrucciones;

            Debug.Log("TextureChanger configurado automáticamente");
        }
        else
        {
            Debug.LogWarning("No se encontró un TextureChanger en la escena");
        }
    }

    [ContextMenu("Limpiar UI")]
    public void LimpiarUI()
    {
        if (canvas != null)
        {
            if (Application.isPlaying)
                Destroy(canvas.gameObject);
            else
                DestroyImmediate(canvas.gameObject);
        }

        canvas = null;
        panelPrincipal = null;
        panelBotones = null;
        textoTitulo = null;
        textoTexturaActual = null;
        textoInstrucciones = null;
    }
}
