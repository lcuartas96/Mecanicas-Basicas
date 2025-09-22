using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaInteractiva1 : MonoBehaviour
{
    [Header("Rotación")]
    public float rotationSpeed = 100f;
    private Vector3 currentRotation;

    [Header("Referencia para sujetar")]
    public Transform HandPoint; // Objeto vacío en el jugador

    [Header("Puntos de colocación")]
    public GameObject Estanteria_1;
    public GameObject Estanteria_2;
    public GameObject Estanteria_3;

    private GameObject pickedObject = null;

    void Update()
    {
        if (Camera.main == null) return;

        if (pickedObject != null)
        {
            // Rotar mientras está recogida
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
            // Recoger con clic izquierdo
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
            if (hit.collider.gameObject == this.gameObject) // Solo esta caja
            {
                PickObject();
            }
        }
    }

    private void PickObject()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
            rb.isKinematic = true;
        }

        transform.position = HandPoint.position;
        transform.SetParent(HandPoint);

        currentRotation = transform.eulerAngles;
        pickedObject = this.gameObject;
    }

    private void ReleaseObject()
    {
        if (pickedObject == null) return;

        Transform closestPlacement = GetClosestPlacementPoint();
        if (closestPlacement != null)
        {
            transform.position = closestPlacement.position;
        }
        else
        {
            // Si no hay punto cerca, la suelta al frente
            transform.position = HandPoint.position + HandPoint.forward * 0.5f;
        }

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = true;
            rb.isKinematic = false;
        }

        transform.SetParent(null);
        pickedObject = null;
    }

    private Transform GetClosestPlacementPoint()
    {
        if (Estanteria_1 == null || Estanteria_2 == null || Estanteria_3 == null)
        {
            Debug.LogWarning("No se asignaron los tres puntos de estantería.");
            return null;
        }

        float distance1 = Vector3.Distance(transform.position, Estanteria_1.transform.position);
        float distance2 = Vector3.Distance(transform.position, Estanteria_2.transform.position);
        float distance3 = Vector3.Distance(transform.position, Estanteria_3.transform.position);

        float threshold = 1.5f; // Distancia máxima

        if (distance1 < threshold && distance1 < distance2 && distance1 < distance3)
        {
            return Estanteria_1.transform;
        }
        else if (distance2 < threshold && distance2 < distance3)
        {
            return Estanteria_2.transform;
        }
        else if (distance3 < threshold)
        {
            return Estanteria_3.transform;
        }

        return null;
    }
}

