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


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            EjecutarAtaque();
        }
    }

    //void EjecutarAtaque()
    //{
    //Collider2D[] enemigosGolpeados = Physics2D.OverlapCircleAll(areaAtaque.position, radioAtaque, capaEnemigos);

    //foreach (Collider2D enemigo in enemigosGolpeados)
    //{
    //enemigo.GetComponent<Enemigo>()?.RecibirDano(dano);
    //}
    //}

    void EjecutarAtaque()
    {
        // Cambiar a sprite de ataque
        spriteRenderer.sprite = spriteAtaque;
        StartCoroutine(RestaurarSprite());

        // Detectar enemigos
        Collider2D[] enemigosGolpeados = Physics2D.OverlapCircleAll(areaAtaque.position, radioAtaque, capaEnemigos);

        foreach (Collider2D enemigo in enemigosGolpeados)
        {
            enemigo.GetComponent<Enemigo>()?.RecibirDano(dano);
        }
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

