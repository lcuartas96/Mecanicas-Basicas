using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coger_Cajas : MonoBehaviour
{
    public float rotationSpeed = 100f; // Velocidad de rotación
    private Vector3 currentRotation; // Almacena la rotación actual en euler angles

    public GameObject HandPoint; // Punto donde se sujetará el objeto
    private GameObject ObjectRecojido = null; // Objeto recogido

    public GameObject Posicion1; // Primer punto de colocacion 
    public GameObject Posicion2; // Segundo punto de colocación
    public GameObject Posicion3; // Tercer punto de colocaciòn

    public GameObject Caja; // Objeto que se activa cuando se recoge algo 
    public Animator anim; // esta parte del codigo es la modificacion de la interfaz 
    public Animator animInterfaz;
    public AudioSource party;
    private bool boton = false;



    void Update()
    {
        // Verificar que la cámara principal no sea nula
        if (Camera.main == null)
        {
            Debug.LogError("No hay una cámara principal (MainCamera) en la escena.");
            return;
        }

        // Si hay un objeto recogido, permitir rotarlo
        if (ObjectRecojido != null)
        {
            // Detecta si el clic del ratón está sostenido (botón izquierdo)
            if (Input.GetMouseButton(0))
            {
                float mouseX = Input.GetAxis("Mouse X");
                float mouseY = Input.GetAxis("Mouse Y");

                currentRotation.x += mouseY * rotationSpeed * Time.deltaTime;
                currentRotation.y -= mouseX * rotationSpeed * Time.deltaTime;

                ObjectRecojido.transform.rotation = Quaternion.Euler(currentRotation);
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
        int layerMask = LayerMask.GetMask("CajaRecogida");

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            Debug.Log($"El rayo golpeó: {hit.collider.gameObject.name} con etiqueta: {hit.collider.gameObject.tag}");

            if (hit.collider.CompareTag("Caja"))
            {
                PickObject(hit.collider.gameObject);
            }
            else
            {
                Debug.Log("El objeto seleccionado no tiene la etiqueta 'Caja'.");
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
        ObjectRecojido = Cap;

        if (Caja != null)
        {
            Caja.SetActive(true); // Activar el recipiente
        }
    }

    private void ReleaseObject()
    {
        if (ObjectRecojido == null) return; // Verificar que hay un objeto recogido

        Transform closestPlacement = GetClosestPlacementPoint(); // nuevo codigo llama a GetClosestPlacementPoint()
        if (closestPlacement != null)
        {
            ObjectRecojido.transform.position = closestPlacement.position;
        }

        Rigidbody rb = ObjectRecojido.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = true;
            rb.isKinematic = false;
        }

        ObjectRecojido.transform.SetParent(null);
        ObjectRecojido = null;

        if (Caja != null)
        {
            Caja.SetActive(false); // Desactivar el recipiente al soltar
        }

    }

    private Transform GetClosestPlacementPoint() // llama a los GameObjets 
    {
        if (Posicion1 == null || Posicion2 == null || Posicion3 == null) return null; // si DRX y TABLERO ES IGUAL A NULO 

        float distance1 = Vector3.Distance(ObjectRecojido.transform.position, Posicion1.transform.position);
        float distance2 = Vector3.Distance(ObjectRecojido.transform.position, Posicion2.transform.position);
        float distance3 = Vector3.Distance(ObjectRecojido.transform.position, Posicion3.transform.position);

        float threshold = 1f; // Distancia máxima para ajustar el objeto

        if (distance1 < threshold && distance1 < distance2)
        {
            return Posicion1.transform; // DRX es la distancia 1
        }
        else if (distance2 < threshold && distance2 < distance3)
        {
            return Posicion2.transform; // TABLERO es la distancia 2
        }
        else if (distance3 < threshold)
        {
            return Posicion3.transform; // TABLERO es la distancia 3
        }

        return null;
    }

  
}
