using UnityEngine;
using UnityEngine.UI;

public class AplicarEtiqueta : MonoBehaviour
{
    public Sprite spriteEtiqueta; // Imagen de la etiqueta a pegar

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(PegarEtiqueta);
    }

    /*void PegarEtiqueta()
    {
        Debug.Log("Intentando pegar etiqueta");

        GameObject caja = SeleccionCaja.cajaSeleccionada;

        if (caja != null)
        {
            Debug.Log("Etiqueta se pega en: " + caja.name);
            GameObject etiquetaGO = new GameObject("Etiqueta_" + spriteEtiqueta.name);
            Debug.Log("Etiqueta GameObject creado");
            etiquetaGO.transform.SetParent(caja.transform);
           // etiquetaGO.transform.localPosition = new Vector3(0, 0.5f, 0.5f); // Frente
            etiquetaGO.transform.localPosition = Vector3.zero;
            etiquetaGO.transform.localRotation = Quaternion.identity;
            etiquetaGO.transform.localScale = Vector3.one * 0.2f;

            SpriteRenderer sr = etiquetaGO.AddComponent<SpriteRenderer>();
            sr.sprite = spriteEtiqueta;
        }
        else
        {
            Debug.LogWarning("No hay caja seleccionada.");
        }
    }
    */
    /*void PegarEtiqueta()
    {
        Debug.Log("Intentando pegar etiqueta");

        GameObject caja = SeleccionCaja.cajaSeleccionada;

        if (caja != null)
        {
            Debug.Log("Etiqueta se pega en: " + caja.name);

            GameObject etiquetaGO = new GameObject("Etiqueta_" + spriteEtiqueta.name);
            etiquetaGO.transform.SetParent(caja.transform);
            Vector3 offsetFrontal = caja.transform.forward * 0.51f + Vector3.up * 0.3f;
            etiquetaGO.transform.localPosition = caja.transform.InverseTransformVector(offsetFrontal);

            etiquetaGO.transform.localRotation = Quaternion.identity;
            etiquetaGO.transform.localScale = Vector3.one * 0.2f;

            SpriteRenderer sr = etiquetaGO.AddComponent<SpriteRenderer>();
            sr.sprite = spriteEtiqueta;

            if (spriteEtiqueta == null)
                Debug.LogWarning("El spriteEtiqueta está vacío");
            else
                Debug.Log("Etiqueta creada correctamente con sprite: " + spriteEtiqueta.name);
        }
        else
        {
            Debug.LogWarning("No hay caja seleccionada.");
        }
    }*/

    void PegarEtiqueta()
    {
        GameObject caja = SeleccionCaja.cajaSeleccionada;

        if (caja != null)
        {
            // Buscar el punto de anclaje dentro de la caja
            Transform puntoEtiqueta = caja.transform.Find("PuntoEtiquetaFrontal");

            if (puntoEtiqueta == null)
            {
                Debug.LogWarning("No se encontró 'PuntoEtiquetaFrontal' en la caja.");
                return;
            }

            // Crear y colocar la etiqueta en ese punto
            GameObject etiquetaGO = new GameObject("Etiqueta_" + spriteEtiqueta.name);
            etiquetaGO.transform.SetParent(puntoEtiqueta);
            etiquetaGO.transform.localPosition = Vector3.zero;
            etiquetaGO.transform.localRotation = Quaternion.identity;
            etiquetaGO.transform.localScale = Vector3.one * 0.2f;

            SpriteRenderer sr = etiquetaGO.AddComponent<SpriteRenderer>();
            sr.sprite = spriteEtiqueta;

            Debug.Log("Etiqueta pegada al objeto: " + puntoEtiqueta.name);
        }
        else
        {
            Debug.LogWarning("No hay caja seleccionada.");
        }
    }


}
