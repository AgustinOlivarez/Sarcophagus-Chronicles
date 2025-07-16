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
        Debug.Log($"{gameObject.name} recibi� {cantidad} de da�o. Vida restante: {vida}");

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
        Destroy(gameObject);
    }
}
