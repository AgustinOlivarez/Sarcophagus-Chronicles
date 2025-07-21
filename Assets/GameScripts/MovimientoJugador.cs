using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 10f;
    private Rigidbody2D rb;
    private bool enSuelo;
    public AudioSource audioPasos;
    public float velocidadMinima = 0.1f;
    public Transform chequeoSuelo;
    public float radioChequeo = 0.2f;
    public LayerMask capaSuelo;

    public Sprite spriteDerecha; // asignalo desde el Inspector
    public Sprite spriteIzquierda; // asignalo desde el Inspector
    private SpriteRenderer spriteRenderer;
    public float ultimaDireccionX = 1f; // 1 = derecha, -1 = izquierda


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float movimiento = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movimiento * velocidad, rb.velocity.y);

        enSuelo = Physics2D.OverlapCircle(chequeoSuelo.position, radioChequeo, capaSuelo);

        if (Input.GetButtonDown("Jump") && enSuelo)
        {
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
        }

        // 🔁 Cambio de sprite según dirección
        if (Input.GetKeyDown(KeyCode.A))
        {
            spriteRenderer.sprite = spriteIzquierda;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            spriteRenderer.sprite = spriteDerecha;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal != 0)
        {
            ultimaDireccionX = horizontal;
        }


        // Sonido pasos
        if (Mathf.Abs(movimiento) > velocidadMinima && enSuelo)
        {
            if (!audioPasos.isPlaying)
                audioPasos.Play();
        }
        else
        {
            if (audioPasos.isPlaying)
                audioPasos.Pause();
        }
    }

    void OnDrawGizmosSelected()
    {
        if (chequeoSuelo != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(chequeoSuelo.position, radioChequeo);
        }
    }
}

