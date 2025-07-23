using System.Collections;
using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    public float velocidadTransicion = 30f;
    public float tiempoCooldown = 1f;

    private float anchoPantalla;
    private Transform jugador;
    private bool enTransicion = false;
    private float tiempoUltimoSalto = -Mathf.Infinity;

    void Start()
    {
        anchoPantalla = Camera.main.orthographicSize * 2f * Camera.main.aspect;
    }

    void LateUpdate()
    {
        if (jugador == null || enTransicion) return;

        float distanciaX = jugador.position.x - transform.position.x;
        float limite = anchoPantalla / 2f;

        if (Time.time - tiempoUltimoSalto < tiempoCooldown) return;

        if (distanciaX > limite)
        {
            tiempoUltimoSalto = Time.time;
            StartCoroutine(MoverCamara(new Vector3(transform.position.x + anchoPantalla, transform.position.y, transform.position.z)));
        }
        else if (distanciaX < -limite)
        {
            tiempoUltimoSalto = Time.time;
            StartCoroutine(MoverCamara(new Vector3(transform.position.x - anchoPantalla, transform.position.y, transform.position.z)));
        }
    }

    IEnumerator MoverCamara(Vector3 destino)
    {
        enTransicion = true;

        while (Vector3.Distance(transform.position, destino) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destino, velocidadTransicion * Time.deltaTime);
            yield return null;
        }

        transform.position = destino;
        enTransicion = false;
    }

    public void EstablecerJugador(Transform nuevoJugador)
    {
        jugador = nuevoJugador;
    }
}
