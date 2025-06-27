using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPersonajes : MonoBehaviour
{
    public GameObject arqueologo;
    public GameObject momia;
    public UIController uiController;
    

    private GameObject personajeActivo;
    
    // Agrega una referencia al script MovimientoJugador de cada personaje
    private MovimientoJugador movimientoArqueologo;
    private MovimientoJugador movimientoMomia;


    void Start()
    {
        // Obtén los componentes MovimientoJugador de cada personaje al inicio
        movimientoArqueologo = arqueologo.GetComponent<MovimientoJugador>();
        movimientoMomia = momia.GetComponent<MovimientoJugador>();

        // Inicializa el arqueólogo como personaje activo y desactiva el movimiento de la momia
        personajeActivo = arqueologo;
        arqueologo.SetActive(true);
        momia.SetActive(false);

        movimientoArqueologo.enabled = true; // Habilita el script de movimiento para el arqueólogo
        movimientoMomia.enabled = false;    // Deshabilita el script de movimiento para la momia
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            CambiarPersonaje();
        }
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
            
        }
    }
}