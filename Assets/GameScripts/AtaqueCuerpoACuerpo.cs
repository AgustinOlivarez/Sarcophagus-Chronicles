using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueCuerpoACuerpo : MonoBehaviour
{
    public Transform areaAtaque;
    public float radioAtaque = 1f;
    public LayerMask capaEnemigos;
    public int dano = 1;

    public SpriteRenderer spriteRenderer; // arrastrás el Sprite Renderer desde el personaje
    public Sprite spriteNormal; // imagen en estado normal
    public Sprite spriteAtaque; // imagen al atacar
    public Sprite spriteDerecha;
    public Sprite spriteIzquierda;
    public Sprite spriteAtaqueIzquierda;
    public Sprite spriteAtaqueDerecha;

    public float duracionAtaque = 0.3f; // tiempo que dura la pose de ataque
    public Boolean puedeAtacar = true; // variable para controlar si se puede atacar
    public AudioSource audioSource;
    public AudioClip sonidoGolpe;


    public IEnumerator EjecutarAtaque()
    {
        puedeAtacar = false;

        // ▶️ Cambiar sprite según dirección
        if (transform.localScale.x < 0)
        {
            spriteRenderer.sprite = spriteAtaqueIzquierda;
        }
        else
        {
            spriteRenderer.sprite = spriteAtaqueDerecha;
        }

        // 🔊 Reproducir sonido
        if (audioSource != null && sonidoGolpe != null)
        {
            audioSource.PlayOneShot(sonidoGolpe);

        }

        MovimientoJugador movimiento = GetComponent<MovimientoJugador>();

        if (movimiento.ultimaDireccionX < 0)
        {
            spriteRenderer.sprite = spriteIzquierda;
        }
        else
        {
            spriteRenderer.sprite = spriteDerecha;
        }


        // 💥 Detectar enemigos
        Collider2D[] enemigosGolpeados = Physics2D.OverlapCircleAll(areaAtaque.position, radioAtaque, capaEnemigos);
        foreach (Collider2D enemigo in enemigosGolpeados)
        {
            if (enemigo.TryGetComponent<Enemigo>(out var scriptEnemigo))
            {
                scriptEnemigo.RecibirDano(dano);
            }
        }

        // ⏳ Esperar duración del ataque
        yield return new WaitForSeconds(duracionAtaque);

        // 🧍 Volver al sprite normal
        spriteRenderer.sprite = spriteNormal;
        puedeAtacar = true;
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
