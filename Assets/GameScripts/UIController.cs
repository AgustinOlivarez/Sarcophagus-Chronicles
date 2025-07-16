using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI textoPersonaje;
    //Manejo de los corazones
    public List<Image> corazonesUI; // Asignar en el Inspector
    public Sprite corazonLleno;
    public Sprite corazonMedio;
    public Sprite corazonVacio;

    public void ActualizarVida(float vidaActual)
    {
        Debug.Log("Actualizando vida: " + vidaActual);
        int vidaEntera = Mathf.FloorToInt(vidaActual); // Parte entera
        bool tieneMedio = (vidaActual % 1f) >= 0.5f;

        for (int i = 0; i < corazonesUI.Count; i++)
        {
            if (i < vidaEntera)
            {
                corazonesUI[i].sprite = corazonLleno;
            }
            else if (i == vidaEntera && tieneMedio)
            {
                corazonesUI[i].sprite = corazonMedio;
            }
            else
            {
                corazonesUI[i].sprite = corazonVacio;
            }
        }
    }

    public void ActualizarPersonaje(string nombre)
    {
        textoPersonaje.text = "Personaje: " + nombre;
    }

}
