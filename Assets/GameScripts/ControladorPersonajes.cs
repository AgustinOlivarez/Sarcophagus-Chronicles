using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPersonajes : MonoBehaviour
{
    public GameObject arqueologo;
    public GameObject momia;
    public UIController uiController;
    
    public CamaraFollow camaraFollow;
    private GameObject personajeActivo;
    private AtaqueCuerpoACuerpo ataqueArqueologo;
    private AtaqueCuerpoACuerpo ataqueMomia;

    private MovimientoJugador movimientoArqueologo;
    private MovimientoJugador movimientoMomia;


    void Start()
    {
        // Obtén los componentes MovimientoJugador y AtaqueCuerpoACuerpo de cada personaje al inicio
        movimientoArqueologo = arqueologo.GetComponent<MovimientoJugador>();
        movimientoMomia = momia.GetComponent<MovimientoJugador>();
        ataqueArqueologo = arqueologo.GetComponent<AtaqueCuerpoACuerpo>();
        ataqueMomia = momia.GetComponent<AtaqueCuerpoACuerpo>();

        // Inicializa el arqueólogo como personaje activo y desactiva el movimiento de la momia
        personajeActivo = arqueologo;
        arqueologo.SetActive(true);
        momia.SetActive(false);

        movimientoArqueologo.enabled = true; // Habilita el script de movimiento para el arqueólogo
        movimientoMomia.enabled = false;    // Deshabilita el script de movimiento para la momia
        camaraFollow.EstablecerJugador(personajeActivo.transform);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            CambiarPersonaje();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (personajeActivo == arqueologo && ataqueArqueologo.puedeAtacar)
                StartCoroutine(ataqueArqueologo.EjecutarAtaque());
            else if (personajeActivo == momia && ataqueMomia.puedeAtacar)
                StartCoroutine(ataqueMomia.EjecutarAtaque());
        }
    }
    public GameObject ObtenerPersonajeActivo()
    {
        return personajeActivo;
    }
    void CambiarPersonaje()
    {
        Vector3 posicionActual = personajeActivo.transform.position;

        if (personajeActivo == arqueologo)
        {
            // Desactiva el arqueólogo y su movimiento
            arqueologo.SetActive(false);
            movimientoArqueologo.enabled = false;

            // Activa la momia y su movimiento
            momia.SetActive(true);
            momia.transform.position = posicionActual;
            personajeActivo = momia;
            movimientoMomia.enabled = true;
            uiController.ActualizarPersonaje("Momia");
            camaraFollow.EstablecerJugador(personajeActivo.transform);


        }
        else // Si el personaje activo es la momia
        {
            // Desactiva la momia y su movimiento
            momia.SetActive(false);
            movimientoMomia.enabled = false;

            // Activa el arqueólogo y su movimiento
            arqueologo.SetActive(true);
            arqueologo.transform.position = posicionActual;
            personajeActivo = arqueologo;
            movimientoArqueologo.enabled = true;
            uiController.ActualizarPersonaje("Arqueologo");
            camaraFollow.EstablecerJugador(personajeActivo.transform);


        }
    }
    public void CambiarAPersonajeInicial()
    {
        if (personajeActivo == momia)
        {
            // Desactiva la momia y su movimiento
            momia.SetActive(false);
            movimientoMomia.enabled = false;

            // Activa el arqueólogo y su movimiento
            arqueologo.SetActive(true);
            personajeActivo = arqueologo;
            movimientoArqueologo.enabled = true;

            uiController.ActualizarPersonaje("Arqueologo");
        }
        else
        {
            return;
        }
    }
}