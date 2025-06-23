using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int vida = 3;

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
