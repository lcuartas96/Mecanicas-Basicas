/*using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventariocaja : MonoBehaviour
{
    [System.Serializable]
    public class CajaInfo
    {
        public GameObject caja3D; // caja 
        public Sprite iconoUI; // imagen de la caja
        public string nombre; // nombre de la caja hay que ponerla igual al nombre del objeto caja
    }

    public List<CajaInfo> cajasDisponibles;         // Lista de cajas que se pueden recoger 
    public Transform panelInventario;               // Panel donde se agregan íconos o la imagen 
    public GameObject iconoCajaPrefab;              // Prefab del ícono de caja
    public Transform posicionSoltar;                // Lugar donde reaparece la caja 

    private Dictionary<string, GameObject> iconosActivos = new Dictionary<string, GameObject>();

    // Llamar esto desde botones de UI
    public void RecogerCaja(string nombreCaja)
    {
        var caja = cajasDisponibles.Find(c => c.nombre == nombreCaja);
        if (caja != null && !iconosActivos.ContainsKey(nombreCaja))
        {
            caja.caja3D.SetActive(false);

            GameObject nuevoIcono = Instantiate(iconoCajaPrefab, panelInventario);
            nuevoIcono.GetComponent<Image>().sprite = caja.iconoUI;
            iconosActivos[nombreCaja] = nuevoIcono;
        }
    }

    // Llamar esto desde un botón "Soltar todo"
    public void SoltarTodo()
    {
        foreach (var entry in iconosActivos)
        {
            var caja = cajasDisponibles.Find(c => c.nombre == entry.Key);
            if (caja != null)
            {
                caja.caja3D.transform.position = posicionSoltar.position;
                caja.caja3D.SetActive(true);
                Destroy(entry.Value); // Eliminar el ícono del Canvas
            }
        }
        iconosActivos.Clear();
    }
}
*/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventariocaja : MonoBehaviour
{
    [System.Serializable]
    public class CajaInfo
    {
        public GameObject caja3D;  // Caja física en escena
        public Sprite iconoUI;     // Imagen en el Canvas
        public string nombre;      // Nombre (debe coincidir con el nombre del objeto en escena)
    }

    public List<CajaInfo> cajasDisponibles;         // Lista de cajas que se pueden recoger
    public Transform panelInventario;               // Panel donde se agregan íconos
    public GameObject iconoCajaPrefab;              // Prefab del ícono de caja
    public Transform[] posicionesSoltar;            // Nuevas posiciones aleatorias donde soltar cajas

    private Dictionary<string, GameObject> iconosActivos = new Dictionary<string, GameObject>();

    // Llamar esto desde botones de UI
    public void RecogerCaja(string nombreCaja)
    {
        var caja = cajasDisponibles.Find(c => c.nombre == nombreCaja);
        if (caja != null && !iconosActivos.ContainsKey(nombreCaja))
        {
            caja.caja3D.SetActive(false);

            GameObject nuevoIcono = Instantiate(iconoCajaPrefab, panelInventario);
            nuevoIcono.GetComponent<Image>().sprite = caja.iconoUI;
            iconosActivos[nombreCaja] = nuevoIcono;
        }
    }

    // Llamar esto desde un botón "Soltar todo" - ahora usa posiciones aleatorias
    public void SoltarTodo()
    {
        System.Random rng = new System.Random();

        foreach (var entry in iconosActivos)
        {
            var caja = cajasDisponibles.Find(c => c.nombre == entry.Key);
            if (caja != null)
            {
                // Selecciona una posición aleatoria
                Transform posicionAleatoria = posicionesSoltar[rng.Next(posicionesSoltar.Length)];
                caja.caja3D.transform.position = posicionAleatoria.position;

                caja.caja3D.SetActive(true);
                Destroy(entry.Value);
            }
        }

        iconosActivos.Clear();
    }
}



