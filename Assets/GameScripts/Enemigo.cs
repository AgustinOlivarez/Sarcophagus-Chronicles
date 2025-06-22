using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int vida = 3;

    public void RecibirDaño(int cantidad)
    {
        vida -= cantidad;
        Debug.Log($"{gameObject.name} recibió {cantidad} de daño. Vida restante: {vida}");

        if (vida <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        Destroy(gameObject);
    }
}
