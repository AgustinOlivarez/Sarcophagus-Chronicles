using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscenaTrigger : MonoBehaviour
{
    public string BossFight; // Nombre escena
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jugador")) 
        {
            SceneManager.LoadScene(BossFight);
        }
    }
}
