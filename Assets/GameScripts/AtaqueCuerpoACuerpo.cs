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
    public float duracionAtaque = 0.3f; // tiempo que dura la pose de ataque
    public Boolean puedeAtacar = true; // variable para controlar si se puede atacar
    public AudioSource audioSource;
    public AudioClip sonidoGolpe;


    public IEnumerator EjecutarAtaque()
    {
        puedeAtacar = false;
        spriteRenderer.sprite = spriteAtaque;

        audioSource.PlayOneShot(sonidoGolpe);

        Collider2D[] enemigosGolpeados = Physics2D.OverlapCircleAll(areaAtaque.position, radioAtaque, capaEnemigos);
        foreach (Collider2D enemigo in enemigosGolpeados)
        {
            enemigo.GetComponent<Enemigo>()?.RecibirDano(dano);
        }

        yield return new WaitForSeconds(duracionAtaque);
        spriteRenderer.sprite = spriteNormal;

        yield return new WaitForSeconds(0.1f);
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
    
        IEnumerator RestaurarSprite()
    {
        yield return new WaitForSeconds(duracionAtaque);
        spriteRenderer.sprite = spriteNormal;
    }

}

