using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coger_rotar_objetos : MonoBehaviour
{
    public float rotationSpeed = 100f; // Velocidad de rotación
    private Vector3 currentRotation; // Almacena la rotación actual en euler angles

    public GameObject HandPoint; // Punto donde se sujetará el objeto
    private GameObject pickedObject = null; // Objeto recogido

    public GameObject DRX_2; // Primer punto de colocacion 
    public GameObject TABLERO; // Segundo punto de colocación
    public GameObject COFRE; // Tercer punto de colocaciòn

    public GameObject Convencional_simple; // Objeto que se activa cuando se recoge algo 
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
        if (pickedObject != null)
        {
            // Detecta si el clic del ratón está sostenido (botón izquierdo)
            if (Input.GetMouseButton(1))
            {
                float mouseX = Input.GetAxis("Mouse X");
                float mouseY = Input.GetAxis("Mouse Y");

                currentRotation.x += mouseY * rotationSpeed * Time.deltaTime;
                currentRotation.y -= mouseX * rotationSpeed * Time.deltaTime;

                pickedObject.transform.rotation = Quaternion.Euler(currentRotation);
            }

        }
        // Con un solo clic derecho recoges o sueltas
        if (Input.GetMouseButtonDown(0))
        {
            if (pickedObject != null)
            {
                ReleaseObject();
            }
            else
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
        int layerMask = LayerMask.GetMask("Piezas");

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            Debug.Log($"El rayo golpeó: {hit.collider.gameObject.name} con etiqueta: {hit.collider.gameObject.tag}");

            if (hit.collider.CompareTag("Piezas"))
            {
                PickObject(hit.collider.gameObject);
            }
            else
            {
                Debug.Log("El objeto seleccionado no tiene la etiqueta 'Piezas'.");
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

        if (Convencional_simple != null)
        {
            Convencional_simple.SetActive(true); // Activar el recipiente
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

        if (Convencional_simple != null)
        {
            Convencional_simple.SetActive(false); // Desactivar el recipiente al soltar
        }

    }

    private Transform GetClosestPlacementPoint() // llama a los GameObjets 
    {
        if (DRX_2 == null || TABLERO == null || COFRE == null) return null; // si DRX y TABLERO ES IGUAL A NULO 

        float distance1 = Vector3.Distance(pickedObject.transform.position, DRX_2.transform.position);
        float distance2 = Vector3.Distance(pickedObject.transform.position, TABLERO.transform.position);
        float distance3 = Vector3.Distance(pickedObject.transform.position, COFRE.transform.position);

        float threshold = 1f; // Distancia máxima para ajustar el objeto

        if (distance1 < threshold && distance1 < distance2)
        {
            return DRX_2.transform; // DRX es la distancia 1
        }
        else if (distance2 < threshold && distance2 < distance3)
        {
            return TABLERO.transform; // TABLERO es la distancia 2
        }
        else if (distance3 < threshold)
        {
            return COFRE.transform; // TABLERO es la distancia 3
        }

        return null;
    }

    /*public void ActivarInfo()
    {
        if (boton)
        {
            boton = false;
            anim.SetBool("Encender", false);
            animInterfaz.SetBool("Interfaz", false);
        }
        else
        {
            party.Play();
            boton = true;
            anim.SetBool("Encender", true);
            animInterfaz.SetBool("Interfaz", true);
        }
    }*/
}
