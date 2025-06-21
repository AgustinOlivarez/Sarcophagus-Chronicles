using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI textoPersonaje;
    public TextMeshProUGUI textoVida;

    public void ActualizarPersonaje(string nombre)
    {
        textoPersonaje.text = "Personaje: " + nombre;
    }

    public void ActualizarVida(int vida)
    {
        textoVida.text = "Vida: " + vida;
    }
}
