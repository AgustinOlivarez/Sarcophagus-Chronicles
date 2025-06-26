using UnityEngine;

public class ParallaxFondo : MonoBehaviour
{
    public Transform personajeActivo;  
    //public Transform camara;
    public float factorParallax = 0.1f;
    public float maxOffsetX = 2.365f; // según la cantidad de "ciclos" que querés mostrar


    private Renderer rend;
    //private Vector3 posicionOriginal;

    void Start()
    {
        rend = GetComponent<Renderer>();
        //posicionOriginal = transform.position;
        
        // Calcular automáticamente el offset máximo
        float anchoQuad = GetComponent<Renderer>().bounds.size.x;
        maxOffsetX = anchoQuad * factorParallax;
    }

    void Update()
    {
        if (personajeActivo == null) return;

        // Scroll infinito horizontal
        float offsetX = personajeActivo.position.x * factorParallax;
        offsetX = Mathf.Clamp(offsetX, 0f, maxOffsetX); // evita que se pase del fondo visible
        rend.material.mainTextureOffset = new Vector2(offsetX, 0);

        // Mantener el fondo alineado con la cámara en Y
        //transform.position = new Vector3(posicionOriginal.x, camara.position.y, posicionOriginal.z);
        
    }


    // Método para cambiar el personaje activo desde ControladorPersonajes
    public void CambiarPersonajeActivo(Transform nuevoPersonaje)
    {
        personajeActivo = nuevoPersonaje;
    }
}
