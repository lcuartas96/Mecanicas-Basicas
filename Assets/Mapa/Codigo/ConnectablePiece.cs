using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectablePiece : MonoBehaviour
{
    [Header("Piece Settings")]
    public bool autoConnect = false;
    public bool canBeMoved = true;
    public List<ConnectionPoint> connectionPoints = new List<ConnectionPoint>();

    [Header("Physics")]
    public bool usePhysics = true;
    private Rigidbody rb;
    private bool isDragging = false;

    [Header("Audio")]
    public AudioClip connectionSound;
    public AudioClip disconnectionSound;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        // Encontrar todos los puntos de conexión hijos
        ConnectionPoint[] childPoints = GetComponentsInChildren<ConnectionPoint>();
        connectionPoints.Clear();
        connectionPoints.AddRange(childPoints);

        // Si no usa física, desactivar gravedad
        if (!usePhysics && rb != null)
        {
            rb.useGravity = false;
            rb.isKinematic = true;
        }
    }

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (!canBeMoved) return;

        // Detectar clic del mouse para arrastrar
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    StartDragging();
                }
            }
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            StopDragging();
        }

        if (isDragging)
        {
            DragPiece();
        }

        // Tecla para desconectar todas las conexiones
        if (Input.GetKeyDown(KeyCode.X))
        {
            DisconnectAll();
        }
    }

    void StartDragging()
    {
        isDragging = true;
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }

    void StopDragging()
    {
        isDragging = false;
        if (rb != null && usePhysics)
        {
            rb.isKinematic = false;
        }
    }

    void DragPiece()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, transform.position);
        float distance;

        if (plane.Raycast(ray, out distance))
        {
            Vector3 targetPosition = ray.GetPoint(distance);
            transform.position = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
        }
    }

    public void OnConnectionMade(ConnectionPoint from, ConnectionPoint to)
    {
        Debug.Log($"Pieza {gameObject.name} conectada");

        // Reproducir sonido
        if (audioSource != null && connectionSound != null)
        {
            audioSource.PlayOneShot(connectionSound);
        }

        // Aquí puedes agregar lógica adicional cuando se hace una conexión
        // Por ejemplo, cambiar propiedades de la pieza, activar efectos, etc.
    }

    public void OnConnectionBroken(ConnectionPoint from, ConnectionPoint to)
    {
        Debug.Log($"Pieza {gameObject.name} desconectada");

        // Reproducir sonido
        if (audioSource != null && disconnectionSound != null)
        {
            audioSource.PlayOneShot(disconnectionSound);
        }
    }

    public void DisconnectAll()
    {
        foreach (ConnectionPoint point in connectionPoints)
        {
            if (point.isOccupied)
            {
                point.Disconnect();
            }
        }
    }

    public bool IsConnectedTo(ConnectablePiece other)
    {
        foreach (ConnectionPoint point in connectionPoints)
        {
            if (point.connectedTo != null &&
                point.connectedTo.GetComponentInParent<ConnectablePiece>() == other)
            {
                return true;
            }
        }
        return false;
    }

    public List<ConnectablePiece> GetConnectedPieces()
    {
        List<ConnectablePiece> connected = new List<ConnectablePiece>();

        foreach (ConnectionPoint point in connectionPoints)
        {
            if (point.connectedTo != null)
            {
                ConnectablePiece connectedPiece = point.connectedTo.GetComponentInParent<ConnectablePiece>();
                if (connectedPiece != null && !connected.Contains(connectedPiece))
                {
                    connected.Add(connectedPiece);
                }
            }
        }

        return connected;
    }
}
