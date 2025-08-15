using UnityEngine;

public class ZonaProhibida : MonoBehaviour
{
    private bool estanteriaDentro = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Estanteria"))
        {
            estanteriaDentro = true;
            Debug.Log("⚠ No puedes colocar la estantería aquí.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Estanteria"))
        {
            estanteriaDentro = false;
        }
    }

    // Llamar a este método desde el script que coloca la estantería
    public bool PuedeColocar()
    {
        return !estanteriaDentro;
    }
}
