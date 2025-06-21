using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraPorPantallas : MonoBehaviour
{
    public Transform objetivo;  // Personaje activo
    public float anchoPantalla = 16f;
    public float altoPantalla = 9f;
    public float velocidadLerp = 5f;  // Qué tan rápido se mueve la cámara

    private Vector2Int actualPantalla;
    private Vector3 targetPos;

    void Start()
    {
        ActualizarPantalla();
        transform.position = targetPos;
    }

    void LateUpdate()
    {
        if (objetivo == null) return;

        Vector2Int nuevaPantalla = new Vector2Int(
            Mathf.FloorToInt(objetivo.position.x / anchoPantalla),
            Mathf.FloorToInt(objetivo.position.y / altoPantalla)
        );

        if (nuevaPantalla != actualPantalla)
        {
            actualPantalla = nuevaPantalla;
            targetPos = new Vector3(
                actualPantalla.x * anchoPantalla + anchoPantalla / 2f,
                actualPantalla.y * altoPantalla + altoPantalla / 2f,
                -10f
            );
        }

        // Movimiento suave hacia la posición target
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * velocidadLerp);
    }

    public void ActualizarObjetivo(Transform nuevoObjetivo)
    {
        objetivo = nuevoObjetivo;
        ActualizarPantalla();
    }

    private void ActualizarPantalla()
    {
        if (objetivo == null) return;

        actualPantalla = new Vector2Int(
            Mathf.FloorToInt(objetivo.position.x / anchoPantalla),
            Mathf.FloorToInt(objetivo.position.y / altoPantalla)
        );

        targetPos = new Vector3(
            actualPantalla.x * anchoPantalla + anchoPantalla / 2f,
            actualPantalla.y * altoPantalla + altoPantalla / 2f,
            -10f
        );
    }
}
