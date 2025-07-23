using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float velocidad = 2;
    public VidaJugador vidaJugador;

    public Vector3 posicionInicial;
    private Vector3 checkpointPosition;
    public ControladorPersonajes controlador;
    public GameObject menuMuerte;
    public GameObject menuVictoria;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        posicionInicial = controlador.arqueologo.transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RespawnDesdeInicio();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            RespawnDesdeCheckpoint();
        }
    }

    public void GuardarCheckpoint(Vector3 newPosition)
    {
        checkpointPosition = newPosition;
    }

    public void RespawnDesdeCheckpoint()
    {
        controlador.CambiarAPersonajeInicial();
        Time.timeScale = 1f;

        controlador.arqueologo.transform.position = checkpointPosition;
        controlador.momia.transform.position = checkpointPosition;

        vidaJugador.ReiniciarVida();

        foreach (Enemigo enemigo in FindObjectsOfType<Enemigo>(true))
        {
            enemigo.Respawnear();
        }

        menuMuerte.SetActive(false);
        menuVictoria.SetActive(false);
    }


    public void RespawnDesdeInicio()
    {
        controlador.CambiarAPersonajeInicial();
        Time.timeScale = 1f;

        controlador.arqueologo.transform.position = posicionInicial;
        controlador.momia.transform.position = posicionInicial;

        vidaJugador.ReiniciarVida();

        foreach (Enemigo enemigo in FindObjectsOfType<Enemigo>(true))
        {
            enemigo.Respawnear();
        }

        menuMuerte.SetActive(false);
        menuVictoria.SetActive(false);
    }

    
}
