using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJugador : MonoBehaviour
{
    public float vida = 5;
    public UIController uiController;
    public SpriteRenderer spriteArqueologo;
    public SpriteRenderer spriteMomia;
    public ControladorPersonajes controlador;
    //Menu que se muestra cuando morimos
    public GameObject menuMuerte;
        void Start()
    {
        menuMuerte.SetActive(false);
        uiController.ActualizarVida(vida);
    }
    // Método para recibir daño del jugador
    public void RecibirDanoJugador(float cantidad)
    {

        Debug.Log($"Daño recibido: {cantidad} en {Time.time}");
        vida -= cantidad;
        vida = Mathf.Clamp(vida, 0f, 5f);
        //Actualizar UI de la vida
        uiController.ActualizarVida(vida);
        // Elegir personaje activo
        GameObject personajeActual = controlador.ObtenerPersonajeActivo(); // lo vemos abajo

        // Saber cuál sprite usar
        SpriteRenderer sprite = personajeActual == controlador.arqueologo ? spriteArqueologo : spriteMomia;

        StartCoroutine(Parpadeo(sprite, 0.5f, 0.1f));
        if (vida <= 0f)
        {
            Morir();
        }
    }
    //Parpadeo del Sprite del jugador
    public IEnumerator Parpadeo(SpriteRenderer spriteRenderer, float duracion, float intervalo)
    {
        float tiempo = 0f;
        while (tiempo < duracion)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(intervalo);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(intervalo);
            tiempo += intervalo * 2;
        }
    }
    //Para resetear la vida del jugador, se puede llamar desde el GameManager o desde un botón en el UI
    public void ReiniciarVida()
    {
        vida = 5;
        uiController.ActualizarVida(vida);
    }
    void Morir()
    {
        Debug.Log("¡Jugador muerto!");
        menuMuerte.SetActive(true);
        Time.timeScale = 1f; // opcional, para pausar el juego
    }
}
