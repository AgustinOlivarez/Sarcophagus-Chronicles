using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ControladorPersonajes : MonoBehaviour
{
    public GameObject arqueologo;
    public GameObject momia;
    public UIController uiController;

    private GameObject personajeActivo;

    void Start()
    {
        personajeActivo = arqueologo;
        arqueologo.SetActive(true);
        momia.SetActive(false);
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
            arqueologo.SetActive(false);
            momia.SetActive(true);
            momia.transform.position = posicionActual;
            personajeActivo = momia;

            uiController.ActualizarPersonaje("Momia");
        }
        else
        {
            momia.SetActive(false);
            arqueologo.SetActive(true);
            arqueologo.transform.position = posicionActual;
            personajeActivo = arqueologo;

            uiController.ActualizarPersonaje("Arqueólogo");
        }
    }
}