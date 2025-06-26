using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraConLimites : MonoBehaviour
{
    public Transform objetivo;
    public float suavizado = 0.3f;
    public Vector2 minLimite;
    public Vector2 maxLimite;

    private Vector3 velocidad = Vector3.zero;
    private float tamañoOrtoY;
    private float tamañoOrtoX;

    void Start()
    {
        // Calcular mitad del tamaño visible de la cámara (en unidades del mundo)
        tamañoOrtoY = Camera.main.orthographicSize;
        tamañoOrtoX = tamañoOrtoY * Camera.main.aspect;
    }

    void LateUpdate()
    {
        if (objetivo == null) return;

        Vector3 destino = new Vector3(objetivo.position.x, objetivo.position.y, -10f);

        // Limitar en X
        destino.x = Mathf.Clamp(destino.x, minLimite.x + tamañoOrtoX, maxLimite.x - tamañoOrtoX);
        // Limitar en Y
        destino.y = Mathf.Clamp(destino.y, minLimite.y + tamañoOrtoY, maxLimite.y - tamañoOrtoY);

        transform.position = Vector3.SmoothDamp(transform.position, destino, ref velocidad, suavizado);
    }
    public void ActualizarObjetivo(Transform nuevoObjetivo)
    {
        objetivo = nuevoObjetivo;
    }
}
