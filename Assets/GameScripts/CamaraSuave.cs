using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraSuave : MonoBehaviour
{
    public Transform objetivo;
    public float tiempoSuavizado = 0.3f;
    public float minX = -3.363f;
    public float maxX = 0.403f;
    public float minY = 4.0738f;
    public float maxY = 4.7261f;

    private Vector3 velocidad = Vector3.zero;

    void LateUpdate()
    {
        if (objetivo == null) return;

        Vector3 destino = new Vector3(objetivo.position.x, objetivo.position.y, -10f);
        //transform.position = Vector3.SmoothDamp(transform.position, destino, ref velocidad, tiempoSuavizado);


        Vector3 pos = transform.position;
        destino.x = Mathf.Clamp(destino.x, minX, maxX);
        destino.y = Mathf.Clamp(destino.y, minY, maxY);

        transform.position = Vector3.SmoothDamp(transform.position, destino, ref velocidad, tiempoSuavizado);
        //pos.x = Mathf.Clamp(pos.x, minX, maxX);
        //pos.y = Mathf.Clamp(pos.y, minY, maxY);
        //transform.position = pos;
    }

    public void ActualizarObjetivo(Transform nuevoObjetivo)
    {
        objetivo = nuevoObjetivo;
    }
}
