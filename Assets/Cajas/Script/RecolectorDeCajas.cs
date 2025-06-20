using UnityEngine;

public class RecolectorDeCajas : MonoBehaviour
{
    public string tagDeCajas = "Caja"; // Asegúrate que las cajas tengan este tag
    public InventarioUI inventarioUI;

    public void RecogerCajas()
    {
        GameObject[] cajas = GameObject.FindGameObjectsWithTag(tagDeCajas);

        foreach (GameObject caja in cajas)
        {
            PiezaInstanciada info = caja.GetComponent<PiezaInstanciada>();
            if (info != null && inventarioUI != null)
            {
                //inventarioUI.AgregarAlInventario(info.iconoPieza, info.prefabOriginal, info.nombrePieza, info.descripcionPieza);
            }

            Destroy(caja);
        }
    }
}
