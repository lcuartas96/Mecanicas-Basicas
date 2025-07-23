using UnityEngine;
using System.Collections.Generic;

// Script para los puntos de conexión en los extremos de las piezas
public class ConnectionPoint : MonoBehaviour
{
    [Header("Connection Settings")]
    public bool isOccupied = false;
    public ConnectionPoint connectedTo = null;
    public float connectionDistance = 0.5f;

    [Header("Visual Feedback")]
    public GameObject connectionIndicator; // Objeto visual para mostrar el punto
    public Material availableMaterial;
    public Material occupiedMaterial;
    public Material nearConnectionMaterial;

    private Renderer indicatorRenderer;
    private ConnectablePiece parentPiece;

    void Start()
    {
        parentPiece = GetComponentInParent<ConnectablePiece>();

        if (connectionIndicator != null)
        {
            indicatorRenderer = connectionIndicator.GetComponent<Renderer>();
            UpdateVisualState();
        }
    }

    void Update()
    {
        if (!isOccupied)
        {
            CheckForNearbyConnections();
        }
    }

    void CheckForNearbyConnections()
    {
        ConnectionPoint[] allConnectionPoints = FindObjectsOfType<ConnectionPoint>();
        bool nearConnection = false;

        foreach (ConnectionPoint other in allConnectionPoints)
        {
            if (other != this && !other.isOccupied && other.parentPiece != this.parentPiece)
            {
                float distance = Vector3.Distance(transform.position, other.transform.position);

                if (distance <= connectionDistance)
                {
                    nearConnection = true;

                    // Si se presiona una tecla o se cumple una condición, conectar
                    if (Input.GetKeyDown(KeyCode.Space) || (parentPiece != null && parentPiece.autoConnect))
                    {
                        ConnectTo(other);
                        return;
                    }
                }
            }
        }

        // Actualizar visual basado en proximidad
        if (indicatorRenderer != null)
        {
            if (nearConnection)
            {
                indicatorRenderer.material = nearConnectionMaterial;
            }
            else
            {
                indicatorRenderer.material = availableMaterial;
            }
        }
    }

    public void ConnectTo(ConnectionPoint other)
    {
        if (other == null || isOccupied || other.isOccupied) return;

        // Establecer conexión
        this.connectedTo = other;
        other.connectedTo = this;

        this.isOccupied = true;
        other.isOccupied = true;

        // Posicionar las piezas para que se alineen perfectamente
        AlignPieces(other);

        // Actualizar estados visuales
        UpdateVisualState();
        other.UpdateVisualState();

        // Notificar a las piezas padre
        if (parentPiece != null)
        {
            parentPiece.OnConnectionMade(this, other);
        }

        if (other.parentPiece != null)
        {
            other.parentPiece.OnConnectionMade(other, this);
        }

        Debug.Log($"Conexión establecida entre {gameObject.name} y {other.gameObject.name}");
    }

    void AlignPieces(ConnectionPoint other)
    {
        if (parentPiece == null || other.parentPiece == null) return;

        // Calcular la posición objetivo para alinear las piezas
        Vector3 offset = other.transform.position - this.transform.position;
        Vector3 targetPosition = parentPiece.transform.position + offset;

        // Mover la pieza padre a la posición alineada
        parentPiece.transform.position = targetPosition;
    }

    public void Disconnect()
    {
        if (connectedTo != null)
        {
            ConnectionPoint other = connectedTo;

            // Limpiar referencias
            this.connectedTo = null;
            other.connectedTo = null;

            this.isOccupied = false;
            other.isOccupied = false;

            // Actualizar estados visuales
            UpdateVisualState();
            other.UpdateVisualState();

            // Notificar desconexión
            if (parentPiece != null)
            {
                parentPiece.OnConnectionBroken(this, other);
            }

            if (other.parentPiece != null)
            {
                other.parentPiece.OnConnectionBroken(other, this);
            }

            Debug.Log("Conexión rota");
        }
    }

    void UpdateVisualState()
    {
        if (indicatorRenderer == null) return;

        if (isOccupied)
        {
            indicatorRenderer.material = occupiedMaterial;
        }
        else
        {
            indicatorRenderer.material = availableMaterial;
        }
    }

    void OnDrawGizmos()
    {
        // Dibujar el radio de conexión en el editor
        Gizmos.color = isOccupied ? Color.red : Color.green;
        Gizmos.DrawWireSphere(transform.position, connectionDistance);

        // Dibujar línea de conexión si existe
        if (connectedTo != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, connectedTo.transform.position);
        }
    }
}