using UnityEngine;

public class ParallaxFondo : MonoBehaviour
{
    public Transform personajeActivo;  // Puede ser arqueólogo o momia
    public Transform camara;
    public float factorParallax = 0.1f;

    private Renderer rend;
    private Vector3 posicionOriginal;

    void Start()
    {
        rend = GetComponent<Renderer>();
        posicionOriginal = transform.position;
    }

    void Update()
    {
        if (personajeActivo == null) return;

        // Scroll infinito horizontal
        float offsetX = personajeActivo.position.x * factorParallax;
        rend.material.mainTextureOffset = new Vector2(offsetX, 0);

        // Mantener el fondo alineado con la cámara en Y
        transform.position = new Vector3(posicionOriginal.x, camara.position.y, posicionOriginal.z);
    }


    // Método para cambiar el personaje activo desde ControladorPersonajes
    public void CambiarPersonajeActivo(Transform nuevoPersonaje)
    {
        personajeActivo = nuevoPersonaje;
    }
}
