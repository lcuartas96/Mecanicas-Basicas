using UnityEngine;

public class Seleccionable : MonoBehaviour
{
    private void OnMouseDown()
    {
        SelectionManager.Instance.SeleccionarObjeto(transform);
    }
}
