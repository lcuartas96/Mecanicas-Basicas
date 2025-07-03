using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Etiquetar_Caja : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject caja;              // Caja que se etiquetará
    public Sprite imagenEtiqueta;        // Imagen que irá como etiqueta
    public Vector3 offsetEtiqueta = new Vector3(0, 0.5f, 0.5f); // Posición relativa de la etiqueta

    void Start()
    {
        CrearEtiquetaUI();
    }

    void CrearEtiquetaUI()
    {
        // Crear un Canvas en World Space
        GameObject canvasGO = new GameObject("CanvasEtiqueta");
        canvasGO.transform.SetParent(caja.transform);
        canvasGO.transform.localPosition = offsetEtiqueta;
        canvasGO.transform.localRotation = Quaternion.identity;

        Canvas canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;
        canvas.worldCamera = Camera.main;

        CanvasScaler scaler = canvasGO.AddComponent<CanvasScaler>();
        scaler.dynamicPixelsPerUnit = 10;

        canvasGO.AddComponent<GraphicRaycaster>();

        RectTransform canvasRect = canvas.GetComponent<RectTransform>();
        canvasRect.sizeDelta = new Vector2(1f, 1f); // Tamaño del canvas

        // Crear la imagen (UI)
        GameObject imageGO = new GameObject("EtiquetaImagen");
        imageGO.transform.SetParent(canvasGO.transform, false);

        Image image = imageGO.AddComponent<Image>();
        image.sprite = imagenEtiqueta;
        image.preserveAspect = true;

        RectTransform imageRect = image.GetComponent<RectTransform>();
        imageRect.anchoredPosition = Vector2.zero;
        imageRect.sizeDelta = new Vector2(100f, 100f); // Tamaño visual de la etiqueta en unidades de píxel del canvas

        // Escalar el canvas si se ve muy grande o pequeño
        canvasGO.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
    }
}
