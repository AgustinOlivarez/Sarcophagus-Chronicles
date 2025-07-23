using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform puntoA;
    public Transform puntoB;
    public float fuerzaSalto = 10f;            // Más controlado
    public float velocidadHorizontal = 6f;     // Más velocidad lateral
    public float gravedadExtra = 3f;           // Hace que caiga más rápido
    public float tiempoEntreSaltos = 2f;

    public Sprite spriteNormalDerecha;
    public Sprite spriteNormalIzquierda;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    private Transform objetivoActual;
    private float tiempoProximoSalto;
    private bool mirandoDerecha = true;
    private bool proximoSaltoEsVertical = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        objetivoActual = puntoB;
        tiempoProximoSalto = Time.time + tiempoEntreSaltos;
    }

    void Update()
    {
        if (Time.time >= tiempoProximoSalto)
        {
            if (proximoSaltoEsVertical)
                SaltarEnElLugar();
            else
                SaltarAOtroPunto();

            proximoSaltoEsVertical = !proximoSaltoEsVertical;
            tiempoProximoSalto = Time.time + tiempoEntreSaltos;
        }
    }

    void FixedUpdate()
    {
        // Aplicar más gravedad al caer
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (gravedadExtra - 1) * Time.fixedDeltaTime;
        }
    }

    void SaltarAOtroPunto()
    {
        Vector2 direccion = (objetivoActual.position - transform.position).normalized;
        rb.velocity = new Vector2(direccion.x * velocidadHorizontal, fuerzaSalto);

        // Cambiar sprite según dirección
        mirandoDerecha = direccion.x > 0;
        spriteRenderer.sprite = mirandoDerecha ? spriteNormalDerecha : spriteNormalIzquierda;

        objetivoActual = (objetivoActual == puntoA) ? puntoB : puntoA;
    }

    void SaltarEnElLugar()
    {
        rb.velocity = new Vector2(0, fuerzaSalto);
        // No cambia el sprite, porque salta en el lugar
    }
}