using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanioFuego : MonoBehaviour
{
    public int vida = 1;
    //Para realizar el danio
    public float dano = 0.5f;
    public float cooldown = 2f; // tiempo entre cada daño
    private bool puedeHacerDano = true;
    public int vidaInicial = 3;
    private Vector3 posicionInicial;

    // Setear la posición inicial y la vida al inicio de cada enemigo
    void Start()
    {
        posicionInicial = transform.position;
        vidaInicial = vida;
    }
    //Si el enemigo colisiona con el jugador, le hace daño
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador") && puedeHacerDano)
        {
            VidaJugador vida = FindObjectOfType<VidaJugador>();
            if (vida != null)
            {
                vida.RecibirDanoJugador(dano);
                StartCoroutine(EsperarCooldown());
            }
        }
    }

    //Cooldown para volver a hacer daño
    IEnumerator EsperarCooldown()
    {
        puedeHacerDano = false;
        yield return new WaitForSeconds(cooldown);
        puedeHacerDano = true;
    }

    
}



