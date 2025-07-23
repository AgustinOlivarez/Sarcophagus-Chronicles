using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemigo : MonoBehaviour
{
    public int vida = 3;
    //Para realizar el danio
    public float dano = 0.5f;
    public float cooldown = 2f; // tiempo entre cada daño
    private bool puedeHacerDano = true;
    public int vidaInicial = 3;
    private Vector3 posicionInicial;
    public GameObject panelVictoria;

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

    public void RecibirDano(int cantidad)
    {
        vida -= cantidad;
        if (vida <= 0)
        {
            Morir();
        }
    }

    internal void RecibirDanio(int danio)
    {
        throw new NotImplementedException();
    }

    void Morir()
    {
        gameObject.SetActive(false);
        if (CompareTag("Boss") && panelVictoria != null)
        {
            panelVictoria.SetActive(true);
            Time.timeScale = 0f;
        }
        
    }
    
    // 🔁 Respawn: restaurar vida y reactivar
    public void Respawnear()
    {
        vida = vidaInicial;
        transform.position = posicionInicial; // opcional
        gameObject.SetActive(true);
        puedeHacerDano = true;
        Debug.Log("Enemigo respawneado");
    }
}
