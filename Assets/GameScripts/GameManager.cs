using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Renderer fondo;

    //Declarar y poner un valor en velocidad (puede usarse para cualquier cosa por ahora)
    public float velocidad = 2;
    //Declarar y poner un valor en la vida del jugador
    public VidaJugador vidaJugador;

    //Variables para checkpoint y respawn
    public static GameManager Instance;
    public Vector3 posicionInicial;
    private Vector3 checkpointPosition;
    public ControladorPersonajes controlador;
    public GameObject menuMuerte;

    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = controlador.arqueologo.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Para probar
        if (Input.GetKeyDown(KeyCode.R))
        {
            RespawnDesdeInicio();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            RespawnDesdeCheckpoint();
        }
    }
    //Respawn y checkpoints
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void GuardarCheckpoint(Vector3 newPosition)
    {
        checkpointPosition = newPosition;
    }

    public void RespawnDesdeCheckpoint()
    {
        // Activar el personaje por defecto o el último usado, como prefieras
        controlador.CambiarAPersonajeInicial();
        Time.timeScale = 1f;

        // Reposicionamos ambos personajes al checkpoint
        controlador.arqueologo.transform.position = checkpointPosition;
        controlador.momia.transform.position = checkpointPosition;

        // Reiniciar vida
        vidaJugador.ReiniciarVida();

        //Respawnear enemigos
        foreach (Enemigo enemigo in FindObjectsOfType<Enemigo>(true))
        {
            enemigo.Respawnear();
        }

        // Cerrar el panel de muerte si estaba activo
        menuMuerte.SetActive(false);
    }
        public void RespawnDesdeInicio()
    {
        // Activar personaje inicial o último usado (según cómo lo manejes)
        controlador.CambiarAPersonajeInicial();
        Time.timeScale = 1f;

        // Reposicionar ambos personajes a la posición inicial
        controlador.arqueologo.transform.position = posicionInicial;
        controlador.momia.transform.position = posicionInicial;

        // Reiniciar vida
        vidaJugador.ReiniciarVida();

        //Respawnear enemigos
        foreach (Enemigo enemigo in FindObjectsOfType<Enemigo>(true))
        {
            enemigo.Respawnear();
        }

        // Cerrar el panel de muerte (si lo estás desactivando así)
        menuMuerte.SetActive(false);
    }
}

