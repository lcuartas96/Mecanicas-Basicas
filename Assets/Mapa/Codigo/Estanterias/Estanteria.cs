/*using UnityEngine;

public class Estanteria : MonoBehaviour
{
    [Header("Puntos donde se colocarán los objetos")]
    public Transform[] puntosInstancia;  // Puntos dentro de la estantería
    private int contador = 0;            // Controla el siguiente punto disponible

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Click izquierdo
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                // Comprueba si el objeto clicado pertenece a esta estantería
                if (hit.collider.transform.IsChildOf(transform))
                {
                    Debug.Log("🟩 Click detectado en la estantería: " + hit.collider.name);
                    ColocarObjetoEnPunto();
                }
            }
        }
    }


    void ColocarObjetoEnPunto()
    {
        if (InventarioUI.objetoSeleccionado == null)
        {
            Debug.LogWarning("⚠ No hay objeto seleccionado en el inventario.");
            return;
        }

        if (puntosInstancia == null || puntosInstancia.Length == 0)
        {
            Debug.LogWarning("⚠ No hay puntos de instancia asignados en la estantería.");
            return;
        }

        if (contador >= puntosInstancia.Length)
        {
            Debug.Log("⚠ No quedan puntos disponibles en esta estantería.");
            return;
        }

        Transform punto = puntosInstancia[contador];
        GameObject prefab = InventarioUI.objetoSeleccionado;

        Debug.Log($"Instanciando {prefab.name} en punto {contador}: posición {punto.position}");

        GameObject nuevo = Instantiate(prefab, punto.position, punto.rotation);
        nuevo.name = prefab.name + "_instanciado_" + contador;

        Debug.Log("✅ Objeto colocado en la estantería: " + nuevo.name + " | Posición final: " + nuevo.transform.position);
        contador++;
    }

}*/


/*using UnityEngine;

public class Estanteria : MonoBehaviour
{
    [Header("Puntos donde se colocarán los objetos")]
    public Transform[] puntosInstancia;  // Puntos dentro de la estantería
    private int contador = 0;            // Controla el siguiente punto disponible

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Click izquierdo
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                // Comprueba si el objeto clicado pertenece a esta estantería
                if (hit.collider.transform.IsChildOf(transform))
                {
                    Debug.Log("🟩 Click detectado en la estantería: " + hit.collider.name);
                    ColocarObjetoEnPunto();
                }
            }
        }
    }

    void ColocarObjetoEnPunto()
    {
        if (InventarioUI.objetoSeleccionado == null)
        {
            Debug.LogWarning("⚠ No hay objeto seleccionado en el inventario.");
            return;
        }

        if (puntosInstancia == null || puntosInstancia.Length == 0)
        {
            Debug.LogWarning("⚠ No hay puntos de instancia asignados en la estantería.");
            return;
        }

        if (contador >= puntosInstancia.Length)
        {
            Debug.Log("⚠ No quedan puntos disponibles en esta estantería.");
            return;
        }

        Transform punto = puntosInstancia[contador];
        GameObject prefab = InventarioUI.objetoSeleccionado;

        Debug.Log($"📦 Instanciando {prefab.name} en punto {contador}: posición {punto.position}");

        // Instancia y activa el objeto
        GameObject nuevo = Instantiate(prefab, punto.position, punto.rotation);
        nuevo.SetActive(true);
        nuevo.name = prefab.name + "_instanciado_" + contador;

        // 🔹 Asegurar que la escala sea normal
        nuevo.transform.localScale = Vector3.one;

        // 🔹 Si tiene Rigidbody, desactivar la física
        Rigidbody rb = nuevo.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
            rb.isKinematic = true; // evita que la física lo empuje
        }

        Debug.Log($"✅ Objeto colocado en la estantería: {nuevo.name} | Posición final: {nuevo.transform.position}");

        // 👇 NUEVO CÓDIGO: quitar la caja del panel del inventario
        if (InventarioUI.botonSeleccionado != null)
        {
            GameObject.Destroy(InventarioUI.botonSeleccionado);
            InventarioUI.botonSeleccionado = null;
        }

        // Limpia la selección
        InventarioUI.objetoSeleccionado = null;

        contador++;
        
    }
}*/

/*
using UnityEngine;

public class Estanteria : MonoBehaviour
{
    [Header("Puntos donde se colocarán los objetos")]
    public Transform[] puntosInstancia;  // Puntos dentro de la estantería

    private int contador = 0;  // Controla el siguiente punto disponible

    void Update()
    {
        // Detectar clic izquierdo del mouse
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Lanza un rayo desde la cámara
            if (Physics.Raycast(ray, out hit, 100f))
            {
                // Si el objeto clicado pertenece a esta estantería
                if (hit.collider.transform.IsChildOf(transform))
                {
                    Debug.Log("🟩 Click detectado en la estantería: " + hit.collider.name);
                    ColocarObjetoEnPunto();
                }
            }
        }
    }

    /// <summary>
    /// Coloca el objeto seleccionado en el siguiente punto disponible.
    /// </summary>
    void ColocarObjetoEnPunto()
    {
        // Validaciones
        if (InventarioUI.objetoSeleccionado == null)
        {
            Debug.LogWarning("⚠ No hay objeto seleccionado en el inventario.");
            return;
        }

        if (puntosInstancia == null || puntosInstancia.Length == 0)
        {
            Debug.LogWarning("⚠ No hay puntos de instancia asignados en la estantería.");
            return;
        }

        if (contador >= puntosInstancia.Length)
        {
            Debug.Log("⚠ No quedan puntos disponibles en esta estantería.");
            return;
        }

        // Obtiene el punto actual
        Transform punto = puntosInstancia[contador];
        GameObject prefab = InventarioUI.objetoSeleccionado;

        Debug.Log($"📦 Instanciando {prefab.name} en punto {contador}: posición {punto.position}");

        // Instancia y activa el objeto
        GameObject nuevo = Instantiate(prefab, punto.position, punto.rotation);
        nuevo.SetActive(true);
        nuevo.name = prefab.name + "_instanciado_" + contador;

        // Asegura la escala correcta
        nuevo.transform.localScale = Vector3.one;

        // Si tiene Rigidbody, desactivar la física para que no se mueva
        Rigidbody rb = nuevo.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
            rb.isKinematic = true;
        }

        Debug.Log($"✅ Objeto colocado en la estantería: {nuevo.name} | Posición final: {nuevo.transform.position}");

        // 🔹 NO eliminamos el botón del inventario
        // Solo limpiamos la selección actual
        InventarioUI.objetoSeleccionado = null;
        InventarioUI.botonSeleccionado = null;

        // 🔹 Oculta el panel de inventario después de colocar el objeto
        if (InventarioUI.instancia != null)
            InventarioUI.instancia.OcultarPanelDespuesDeColocar();

        contador++;
    }
}*/

/*using UnityEngine;

public class Estanteria : MonoBehaviour
{
    [Header("Puntos donde se colocarán los objetos")]
    public Transform[] puntosInstancia;  // Puntos dentro de la estantería
    private int contador = 0;            // Controla el siguiente punto disponible

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Click izquierdo
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                // ✅ Si se hace clic sobre una pieza o parte de esta estantería
                if (hit.collider.transform.IsChildOf(transform))
                {
                    Debug.Log("🟩 Click detectado en la estantería: " + hit.collider.name);

                    // Si hay un objeto seleccionado → colocarlo
                    if (InventarioUI.objetoSeleccionado != null)
                    {
                        ColocarObjetoEnPunto();
                    }
                    else
                    {
                        // ✅ Si no hay objeto seleccionado, reactivar el panel del inventario
                        if (InventarioUI.instancia != null && InventarioUI.instancia.panelInventario != null)
                        {
                            InventarioUI.instancia.panelInventario.SetActive(true);
                            Debug.Log("📂 Panel del inventario reactivado para seleccionar un nuevo objeto.");
                        }
                    }
                }
            }
        }
    }

    // ===========================================================
    // MÉTODO PARA COLOCAR EL OBJETO EN UN PUNTO DE LA ESTANTERÍA
    // ===========================================================
    void ColocarObjetoEnPunto()
    {
        if (InventarioUI.objetoSeleccionado == null)
        {
            Debug.LogWarning("⚠ No hay objeto seleccionado en el inventario.");
            return;
        }

        if (puntosInstancia == null || puntosInstancia.Length == 0)
        {
            Debug.LogWarning("⚠ No hay puntos de instancia asignados en la estantería.");
            return;
        }

        if (contador >= puntosInstancia.Length)
        {
            Debug.Log("⚠ No quedan puntos disponibles en esta estantería.");
            return;
        }

        Transform punto = puntosInstancia[contador];
        GameObject prefab = InventarioUI.objetoSeleccionado;

        Debug.Log($"📦 Instanciando {prefab.name} en punto {contador}: posición {punto.position}");

        // Instanciar y activar el objeto
        GameObject nuevo = Instantiate(prefab, punto.position, punto.rotation);
        nuevo.SetActive(true);
        nuevo.name = prefab.name + "_instanciado_" + contador;

        // Asegurar escala normal
        nuevo.transform.localScale = Vector3.one;

        // Desactivar la física si tiene Rigidbody
        Rigidbody rb = nuevo.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
            rb.isKinematic = true; // evita que la física lo empuje
        }

        Debug.Log($"✅ Objeto colocado: {nuevo.name} | Posición final: {nuevo.transform.position}");

        // 👇 Eliminar el botón del inventario (solo visual, no el prefab original)
        if (InventarioUI.botonSeleccionado != null)
        {
            GameObject.Destroy(InventarioUI.botonSeleccionado);
            InventarioUI.botonSeleccionado = null;
        }

        // Ocultar el panel temporalmente después de colocar
        if (InventarioUI.instancia != null)
        {
            InventarioUI.instancia.OcultarPanelDespuesDeColocar();
        }

        // Limpiar la selección y pasar al siguiente punto
        InventarioUI.objetoSeleccionado = null;
        contador++;
    }
}*/



using UnityEngine;

public class Estanteria : MonoBehaviour
{
    [Header("Puntos donde se colocarán los objetos")]
    public Transform[] puntosInstancia;  // Puntos dentro de la estantería
    private int contador = 0;            // Controla el siguiente punto disponible

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Click izquierdo
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                // Comprueba si el objeto clicado pertenece a esta estantería
                if (hit.collider.transform.IsChildOf(transform))
                {
                    Debug.Log("🟩 Click detectado en la estantería: " + hit.collider.name);
                    ColocarObjetoEnPunto();
                }
            }
        }
    }

    void ColocarObjetoEnPunto()
    {
        if (InventarioUI.objetoSeleccionado == null)
        {
            Debug.LogWarning("⚠ No hay objeto seleccionado en el inventario.");
            return;
        }

        if (puntosInstancia == null || puntosInstancia.Length == 0)
        {
            Debug.LogWarning("⚠ No hay puntos de instancia asignados en la estantería.");
            return;
        }

        if (contador >= puntosInstancia.Length)
        {
            Debug.Log("⚠ No quedan puntos disponibles en esta estantería.");
            return;
        }

        Transform punto = puntosInstancia[contador];
        GameObject prefab = InventarioUI.objetoSeleccionado;

        Debug.Log($"📦 Instanciando {prefab.name} en punto {contador}: posición {punto.position}");

        // Instancia y activa el objeto
        GameObject nuevo = Instantiate(prefab, punto.position, punto.rotation);
        nuevo.SetActive(true);
        nuevo.name = prefab.name + "_instanciado_" + contador;

        // 🔹 Asegurar que la escala sea normal
        //nuevo.transform.localScale = Vector3.one;
        nuevo.transform.localScale = new Vector3(40f, 40f, 40f); // 🔹 Duplica el tamaño


        // 🔹 Si tiene Rigidbody, desactivar la física
        Rigidbody rb = nuevo.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
            rb.isKinematic = true; // evita que la física lo empuje
        }

        Debug.Log($"✅ Objeto colocado en la estantería: {nuevo.name} | Posición final: {nuevo.transform.position}");
        contador++;

        // ✅ Eliminar el botón del inventario correspondiente
        if (InventarioUI.botonSeleccionado != null)
        {
            Destroy(InventarioUI.botonSeleccionado);
            Debug.Log("🗑 Botón del inventario eliminado tras colocar el objeto: " + prefab.name);
            InventarioUI.botonSeleccionado = null;
            InventarioUI.objetoSeleccionado = null;
        }


    }
}
