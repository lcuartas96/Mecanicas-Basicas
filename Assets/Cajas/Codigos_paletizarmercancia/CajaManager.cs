using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CajaManager : MonoBehaviour
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
        /* var caja = cajasDisponibles.Find(c => c.nombre == nombreCaja);
         if (caja != null && !iconosActivos.ContainsKey(nombreCaja))
         {
             caja.caja3D.SetActive(false);

             GameObject nuevoIcono = Instantiate(iconoCajaPrefab, panelInventario);
             nuevoIcono.GetComponent<Image>().sprite = caja.iconoUI;
             iconosActivos[nombreCaja] = nuevoIcono;
         }
        */
        var caja = cajasDisponibles.Find(c => c.nombre == nombreCaja);
        if (caja != null && !iconosActivos.ContainsKey(nombreCaja))
        {
            caja.caja3D.SetActive(false);

            GameObject nuevoIcono = Instantiate(iconoCajaPrefab, panelInventario);
            nuevoIcono.GetComponent<Image>().sprite = caja.iconoUI;

            // Asignar función de soltar al hacer clic
            Button boton = nuevoIcono.GetComponent<Button>();
            if (boton != null)
            {
                boton.onClick.AddListener(() => SoltarCajaIndividual(nombreCaja));
            }

            iconosActivos[nombreCaja] = nuevoIcono;
        }
    }

    // Llamar esto desde un botón "Soltar todo" - ahora usa posiciones aleatorias
    /*public void SoltarTodo()
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
    }*/



    public void SoltarCajaIndividual(string nombreCaja)
    {
        if (iconosActivos.ContainsKey(nombreCaja))
        {
            var caja = cajasDisponibles.Find(c => c.nombre == nombreCaja);
            if (caja != null)
            {
                // Posición aleatoria
                System.Random rng = new System.Random();
                Transform posicionAleatoria = posicionesSoltar[rng.Next(posicionesSoltar.Length)];
                caja.caja3D.transform.position = posicionAleatoria.position;

                caja.caja3D.SetActive(true);

                Destroy(iconosActivos[nombreCaja]);
                iconosActivos.Remove(nombreCaja);
            }
        }
    }


}
