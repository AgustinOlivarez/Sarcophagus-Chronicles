using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform puntoA;
    public Transform puntoB;
    public float fuerzaSalto = 10f;
    public float tiempoEntreSaltos = 2f;

    public Sprite spriteNormalDerecha;
    public Sprite spriteAtaqueDerecha;
    public Sprite spriteNormalIzquierda;
    public Sprite spriteAtaqueIzquierda;

    public GameObject zonaDeDaño; // tu área de ataque (debe estar en el lugar del rayo y desactivada por defecto)

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    private Transform objetivoActual;
    private float tiempoProximoSalto;
    private bool enAtaque = false;
    private bool mirandoDerecha = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        objetivoActual = puntoB;
        tiempoProximoSalto = Time.time + tiempoEntreSaltos;

        zonaDeDaño.SetActive(false); // asegurarse que está desactivada
    }

    void Update()
    {
        if (Time.time >= tiempoProximoSalto && !enAtaque)
        {
            SaltarAOtroPunto();
            tiempoProximoSalto = Time.time + tiempoEntreSaltos;
        }
    }

    void SaltarAOtroPunto()
    {
        Vector2 direccion = (objetivoActual.position - transform.position).normalized;
        rb.velocity = new Vector2(direccion.x * 3f, fuerzaSalto);

        // Elegir sprite y dirección
        mirandoDerecha = direccion.x > 0;
        spriteRenderer.sprite = mirandoDerecha ? spriteNormalDerecha : spriteNormalIzquierda;

        // Cambiar el objetivo al otro punto
        objetivoActual = (objetivoActual == puntoA) ? puntoB : puntoA;

        Invoke("RealizarAtaque", 1.2f); // Esperar antes de atacar
    }

    void RealizarAtaque()
    {
        enAtaque = true;

        // Cambiar sprite al de ataque
        spriteRenderer.sprite = mirandoDerecha ? spriteAtaqueDerecha : spriteAtaqueIzquierda;

        // Activar zona de daño
        zonaDeDaño.SetActive(true);

        // Desactivar tras un segundo
        Invoke("FinAtaque", 1f);
    }

    void FinAtaque()
    {
        // Volver sprite a normal
        spriteRenderer.sprite = mirandoDerecha ? spriteNormalDerecha : spriteNormalIzquierda;

        zonaDeDaño.SetActive(false);
        enAtaque = false;
    }
}
