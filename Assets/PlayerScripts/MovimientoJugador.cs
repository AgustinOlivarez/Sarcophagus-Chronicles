using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 10f;
    private Rigidbody2D rb;
    private bool enSuelo;

    public Transform chequeoSuelo;
    public float radioChequeo = 0.2f;
    public LayerMask capaSuelo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

