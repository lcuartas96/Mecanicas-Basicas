using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaEtiquetado : MonoBehaviour
{
    public Transform canvasEtiquetas; // Referencia al canvas con imágenes
    public Transform cajaPadreDestino; // Donde se pegarán las etiquetas en la caja

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Caja"))
        {
            // Buscar el lugar donde colocar etiquetas dentro de la caja
            Transform caja = other.transform;

            // Copiar cada imagen del canvas como etiqueta nueva en la caja
            foreach (Transform etiqueta in canvasEtiquetas)
            {
                GameObject nuevaEtiqueta = new GameObject("EtiquetaClon");
                nuevaEtiqueta.transform.SetParent(caja);
                nuevaEtiqueta.transform.localPosition = Vector3.up * 0.5f + Random.insideUnitSphere * 0.1f;
                nuevaEtiqueta.transform.localRotation = Quaternion.identity;
                nuevaEtiqueta.transform.localScale = Vector3.one * 0.2f;

                SpriteRenderer sr = nuevaEtiqueta.AddComponent<SpriteRenderer>();
               // Image img = etiqueta.GetComponent<UnityEngine.UI.Image>();
               // if (img != null) sr.sprite = img.sprite;
            }
        }
    }
}
