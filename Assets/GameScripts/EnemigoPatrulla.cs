using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoPatrulla : MonoBehaviour
{
    public float velocidad = 2f;
    public Transform puntoIzquierda;
    public Transform puntoDerecha;

    private bool yendoDerecha = true;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Patrullar();
    }

    void Patrullar()
    {
        if (yendoDerecha)
        {
            rb.velocity = new Vector2(velocidad, rb.velocity.y);
            if (transform.position.x >= puntoDerecha.position.x)
                yendoDerecha = false;
        }
        else
        {
            rb.velocity = new Vector2(-velocidad, rb.velocity.y);
            if (transform.position.x <= puntoIzquierda.position.x)
                yendoDerecha = true;
        }
    }
}
