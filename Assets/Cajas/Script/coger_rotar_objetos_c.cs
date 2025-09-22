using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.SocialPlatforms.Impl;

public class coger_rotar_objetos_c : MonoBehaviour
{

    public float rotationSpeed = 100f; // Velocidad de rotación
    private Vector3 currentRotation; // Almacena la rotación actual en euler angles

    public GameObject HandPoint; // Punto donde se sujetará el objeto
    private GameObject pickedObject = null; // Objeto recogido

    public GameObject Estanteria_1; // Primer punto de colocacion
    public GameObject Estanteria_2; // Segundo punto de colocación
    public GameObject Estanteria_3; // Tercer punto de colocaciòn




    public GameObject Recipiente; // Objeto que se activa cuando se recoge algo 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Verificar que la cámara principal no sea nula
        if (Camera.main == null)
        {
            Debug.LogError("No hay una cámara principal (MainCamera) en la escena.");
            return;
        }

        // Si hay un objeto recogido, permitir rotarlo
        if (pickedObject != null)
        {
            // Detecta si el clic del ratón está sostenido (botón izquierdo)
            if (Input.GetMouseButton(0))
            {
                float mouseX = Input.GetAxis("Mouse X");
                float mouseY = Input.GetAxis("Mouse Y");

                currentRotation.x += mouseY * rotationSpeed * Time.deltaTime;
                currentRotation.y -= mouseX * rotationSpeed * Time.deltaTime;

                pickedObject.transform.rotation = Quaternion.Euler(currentRotation);
            }

            // Detectar clic derecho para soltar el objeto
            if (Input.GetMouseButtonDown(1))
            {
                ReleaseObject();
            }
        }
        else
        {
            // Detectar clic izquierdo para intentar recoger un objeto
            if (Input.GetMouseButtonDown(0))
            {
                TryPickObject();
            }
        }
    }

    private void TryPickObject()
    {
        if (HandPoint == null)
        {
            Debug.LogError("El campo HandPoint no está asignado. Arrastra un objeto vacío al campo HandPoint en el inspector.");
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Filtrar el raycast para que solo detecte la capa de los objetos recogibles
        int layerMask = LayerMask.GetMask("ObjetoRecogibles");

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            Debug.Log($"El rayo golpeó: {hit.collider.gameObject.name} con etiqueta: {hit.collider.gameObject.tag}");

            if (hit.collider.CompareTag("Objeto"))
            {
                PickObject(hit.collider.gameObject);
            }
            else
            {
                Debug.Log("El objeto seleccionado no tiene la etiqueta 'Objeto'.");
            }
        }
        else
        {
            Debug.Log("No se detectó ningún objeto recogible con el rayo.");
        }
    }

    private void PickObject(GameObject Cap)
    {
        if (Cap == null) return; // Verificar que el objeto no sea nulo

        Rigidbody rb = Cap.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false; // gravedad es falsa
            rb.isKinematic = true; // cinematica es verdadera
        }
        else
        {
            Debug.LogError("El objeto no tiene un componente Rigidbody.");
            return;
        }

        Cap.transform.position = HandPoint.transform.position;
        Cap.transform.SetParent(HandPoint.transform);

        currentRotation = Cap.transform.eulerAngles;
        pickedObject = Cap;

        if (Recipiente != null)
        {
            Recipiente.SetActive(true); // Activar el recipiente
        }
    }
    private void ReleaseObject()
    {
        if (pickedObject == null) return; // Verificar que hay un objeto recogido

        Transform closestPlacement = GetClosestPlacementPoint(); // nuevo codigo llama a GetClosestPlacementPoint()
        if (closestPlacement != null)
        {
            pickedObject.transform.position = closestPlacement.position;
        }

        Rigidbody rb = pickedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = true;
            rb.isKinematic = false;
        }

        pickedObject.transform.SetParent(null);
        pickedObject = null;

        if (Recipiente != null)
        {
           //Recipiente.SetActive(false); // Desactivar el recipiente al soltar
        }

    }

    private Transform GetClosestPlacementPoint() // llama a los GameObjets 
    {
        if (Estanteria_1 == null || Estanteria_2 == null || Estanteria_3 == null) return null; // si DRX y TABLERO ES IGUAL A NULO 

        float distance1 = Vector3.Distance(pickedObject.transform.position, Estanteria_1.transform.position);
        float distance2 = Vector3.Distance(pickedObject.transform.position, Estanteria_2.transform.position);
        float distance3 = Vector3.Distance(pickedObject.transform.position, Estanteria_3.transform.position);

        float threshold = 1f; // Distancia máxima para ajustar el objeto

        if (distance1 < threshold && distance1 < distance2)
        {
            return Estanteria_1.transform; // DRX es la distancia 1
        }
        else if (distance2 < threshold && distance2 < distance3)
        {
            return Estanteria_2.transform; // TABLERO es la distancia 2
        }
        else if (distance3 < threshold)
        {
            return Estanteria_3.transform; // TABLERO es la distancia 3
        }

        return null;
    }

}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coger_rotar_objetos_c : MonoBehaviour
{
    public float rotationSpeed = 100f;
    private Vector3 currentRotation;

    public GameObject HandPoint;
    private GameObject pickedObject = null;

    public GameObject Recipiente;

    private List<Transform> placementPoints = new List<Transform>(); // ?? Lista dinámica

    void Start()
    {
        // Buscar todos los puntos de colocación al inicio
        FindPlacementPoints();
    }

    void Update()
    {
        if (Camera.main == null)
        {
            Debug.LogError("No hay una cámara principal (MainCamera) en la escena.");
            return;
        }

        if (pickedObject != null)
        {
            // Rotación mientras se mantiene el click izquierdo
            if (Input.GetMouseButton(0))
            {
                float mouseX = Input.GetAxis("Mouse X");
                float mouseY = Input.GetAxis("Mouse Y");

                currentRotation.x += mouseY * rotationSpeed * Time.deltaTime;
                currentRotation.y -= mouseX * rotationSpeed * Time.deltaTime;

                pickedObject.transform.rotation = Quaternion.Euler(currentRotation);
            }

            // Soltar con click derecho
            if (Input.GetMouseButtonDown(1))
            {
                ReleaseObject();
            }
        }
        else
        {
            // Intentar recoger con click izquierdo
            if (Input.GetMouseButtonDown(0))
            {
                TryPickObject();
            }
        }
    }

    private void TryPickObject()
    {
        if (HandPoint == null)
        {
            Debug.LogError("El campo HandPoint no está asignado.");
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        int layerMask = LayerMask.GetMask("ObjetoRecogibles");

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            if (hit.collider.CompareTag("Objeto"))
            {
                PickObject(hit.collider.gameObject);
            }
        }
    }

    private void PickObject(GameObject Cap)
    {
        if (Cap == null) return;

        Rigidbody rb = Cap.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
            rb.isKinematic = true;
        }

        Cap.transform.position = HandPoint.transform.position;
        Cap.transform.SetParent(HandPoint.transform);

        currentRotation = Cap.transform.eulerAngles;
        pickedObject = Cap;

        if (Recipiente != null) Recipiente.SetActive(true);
    }

    private void ReleaseObject()
    {
        if (pickedObject == null) return;

        Transform closestPlacement = GetClosestPlacementPoint();
        if (closestPlacement != null)
        {
            pickedObject.transform.position = closestPlacement.position;
        }
        else
        {
            // ?? Si no hay punto cercano, la dejamos en frente de la mano
            pickedObject.transform.position = HandPoint.transform.position + HandPoint.transform.forward * 0.5f;
        }

        Rigidbody rb = pickedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = true;
            rb.isKinematic = false;
        }

        pickedObject.transform.SetParent(null);

        // ?? Nos aseguramos de que el objeto sigue activo
        pickedObject.SetActive(true);

        pickedObject = null;

        if (Recipiente != null)
        {
            //Recipiente.SetActive(false);
        }
    }

    private Transform GetClosestPlacementPoint()
    {
        Transform closest = null;
        float minDistance = Mathf.Infinity;
        float threshold = 1.5f;

        foreach (Transform point in placementPoints)
        {
            float dist = Vector3.Distance(pickedObject.transform.position, point.position);
            if (dist < minDistance && dist < threshold)
            {
                minDistance = dist;
                closest = point;
            }
        }

        return closest;
    }

    private void FindPlacementPoints()
    {
        placementPoints.Clear();

        GameObject[] points = GameObject.FindGameObjectsWithTag("PlacementPoint");
        foreach (GameObject go in points)
        {
            placementPoints.Add(go.transform);
        }

        Debug.Log($"Se encontraron {placementPoints.Count} puntos de colocación.");
    }
}*/

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coger_rotar_objetos_c : MonoBehaviour
{
    public float rotationSpeed = 100f; // Velocidad de rotación
    private Vector3 currentRotation;   // Rotación actual en Euler angles

    [Header("Puntos de referencia")]
    public GameObject HandPoint; // Punto donde se sujeta el objeto
    private GameObject pickedObject = null; // Objeto recogido

    [Header("Estanterías")]
    public GameObject Estanteria_1;
    public GameObject Estanteria_2;
    public GameObject Estanteria_3;

    void Update()
    {
        // Verificar cámara principal
        if (Camera.main == null)
        {
            Debug.LogError("No hay una cámara principal (MainCamera) en la escena.");
            return;
        }

        if (pickedObject != null)
        {
            // Rotar mientras se mantiene clic izquierdo
            if (Input.GetMouseButton(0))
            {
                float mouseX = Input.GetAxis("Mouse X");
                float mouseY = Input.GetAxis("Mouse Y");

                currentRotation.x += mouseY * rotationSpeed * Time.deltaTime;
                currentRotation.y -= mouseX * rotationSpeed * Time.deltaTime;

                pickedObject.transform.rotation = Quaternion.Euler(currentRotation);
            }

            // Soltar con clic derecho
            if (Input.GetMouseButtonDown(1))
            {
                ReleaseObject();
            }
        }
        else
        {
            // Intentar recoger con clic izquierdo
            if (Input.GetMouseButtonDown(0))
            {
                TryPickObject();
            }
        }
    }

    private void TryPickObject()
    {
        if (HandPoint == null)
        {
            Debug.LogError("El campo HandPoint no está asignado. Arrastra un objeto vacío al campo HandPoint en el inspector.");
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Filtrar solo la capa "ObjetoRecogibles"
        int layerMask = LayerMask.GetMask("ObjetoRecogibles");

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            Debug.Log($"El rayo golpeó: {hit.collider.gameObject.name} con etiqueta: {hit.collider.gameObject.tag}");

            if (hit.collider.CompareTag("Objeto"))
            {
                PickObject(hit.collider.gameObject);
            }
            else
            {
                Debug.Log("El objeto seleccionado no tiene la etiqueta 'Objeto'.");
            }
        }
        else
        {
            Debug.Log("No se detectó ningún objeto recogible con el rayo.");
        }
    }

    private void PickObject(GameObject Cap)
    {
        if (Cap == null) return;

        Rigidbody rb = Cap.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
            rb.isKinematic = true;
        }
        else
        {
            Debug.LogError("El objeto no tiene un componente Rigidbody.");
            return;
        }

        Cap.transform.position = HandPoint.transform.position;
        Cap.transform.SetParent(HandPoint.transform);

        currentRotation = Vector3.zero; // Reseteamos la rotación al recoger
        Cap.transform.localRotation = Quaternion.identity;

        pickedObject = Cap;
    }

    private void ReleaseObject()
    {
        if (pickedObject == null) return;

        Transform closestPlacement = GetClosestPlacementPoint();
        if (closestPlacement != null)
        {
            pickedObject.transform.position = closestPlacement.position;
        }

        Rigidbody rb = pickedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = true;
            rb.isKinematic = false;
        }

        pickedObject.transform.SetParent(null);
        pickedObject = null;
    }

    private Transform GetClosestPlacementPoint()
    {
        // Si alguna estantería no está asignada, salir
        if (Estanteria_1 == null || Estanteria_2 == null || Estanteria_3 == null) return null;

        Transform[] puntos = { Estanteria_1.transform, Estanteria_2.transform, Estanteria_3.transform };
        Transform masCercano = null;
        float minDist = Mathf.Infinity;

        foreach (Transform punto in puntos)
        {
            float dist = Vector3.Distance(pickedObject.transform.position, punto.position);
            if (dist < minDist)
            {
                minDist = dist;
                masCercano = punto;
            }
        }

        float threshold = 1f; // distancia máxima permitida
        return (minDist < threshold) ? masCercano : null;
    }
}
*/



