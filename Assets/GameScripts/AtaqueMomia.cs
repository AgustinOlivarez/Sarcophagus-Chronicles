using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueMomia : MonoBehaviour
{
    public Transform areaAtaque;
    public float radioAtaque = 1f;
    public LayerMask capaEnemigos;
    public int dano = 1;

    public SpriteRenderer spriteRenderer;
    public Sprite spriteNormal;
    public Sprite spriteAtaque;
    public float duracionAtaque = 0.3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            EjecutarAtaque();
        }
    }

    void EjecutarAtaque()
    {
        spriteRenderer.sprite = spriteAtaque;
        StartCoroutine(RestaurarSprite());

        Collider2D[] enemigosGolpeados = Physics2D.OverlapCircleAll(areaAtaque.position, radioAtaque, capaEnemigos);

        foreach (Collider2D enemigo in enemigosGolpeados)
        {
            enemigo.GetComponent<Enemigo>()?.RecibirDano(dano);
        }
    }

    IEnumerator RestaurarSprite()
    {
        yield return new WaitForSeconds(duracionAtaque);
        spriteRenderer.sprite = spriteNormal;
    }

    void OnDrawGizmosSelected()
    {
        if (areaAtaque != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(areaAtaque.position, radioAtaque);
        }
    }
}
