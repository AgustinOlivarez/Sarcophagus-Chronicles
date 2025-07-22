using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueCuerpoACuerpo : MonoBehaviour
{
    public Transform areaAtaqueIzquierda;
    public Transform areaAtaqueDerecha;
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

        // Determinar dirección del personaje
        MovimientoJugador movimiento = GetComponent<MovimientoJugador>();
        bool atacandoIzquierda = movimiento.ultimaDireccionX < 0;

        // Cambiar sprite de ataque
        spriteRenderer.sprite = atacandoIzquierda ? spriteAtaqueIzquierda : spriteAtaqueDerecha;

        // Reproducir sonido
        if (audioSource != null && sonidoGolpe != null)
        {
            audioSource.PlayOneShot(sonidoGolpe);
        }

        // 💥 Detectar enemigos en el área correspondiente
        Transform areaAtaque = atacandoIzquierda ? areaAtaqueIzquierda : areaAtaqueDerecha;

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

        // 🧍 Volver al sprite de dirección
        spriteRenderer.sprite = atacandoIzquierda ? spriteIzquierda : spriteDerecha;

        puedeAtacar = true;
    }

    // Visualización del área en la escena (opcional)
    private void OnDrawGizmosSelected()
    {
        if (areaAtaqueIzquierda != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(areaAtaqueIzquierda.position, radioAtaque);
        }
        if (areaAtaqueDerecha != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(areaAtaqueDerecha.position, radioAtaque);
        }
    }
}

