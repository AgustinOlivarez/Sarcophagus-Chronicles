using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Renderer fondo;
    public GameObject menuPrincipal;
    public GameObject menuGameOver;

    // Variable. Declarar comienzo del juego
    public bool start = false;

    // Cuando choca con un obstaculo. Termina el juego
    public bool gameOver = false;
    //Declarar y poner un valor en velocidad (puede usarse para cualquier cosa por ahora)
    public float velocidad = 2;

    // Declarar el Suelo y piedras
    public GameObject col;
    public GameObject piedra1;
    public GameObject piedra2;
    


    // Listas
    public List<GameObject> cols;
    public List<GameObject> obstaculos;
    // Start is called before the first frame update
    void Start()
    {
        // Crear piedra (no hago un bucle for porque solo soln 2 piedras)
        obstaculos.Add(Instantiate(piedra1, new Vector2(14, -2), Quaternion.identity));
        obstaculos.Add(Instantiate(piedra2, new Vector2(18, -2), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
        fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.02f, 0) * Time.deltaTime;

        // Configuracion acciones teclas (Tecla X)
        // X
        if (start == false)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                start = true;
            }
        }

        if (start == true && gameOver == true)
        {
            menuGameOver.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                //SceneManager.LoadScene(SceneManager.GetActiveScene().name); (comento esto porq me daba error)
            }
        }

        if (start == true && gameOver == false)
        {
            menuPrincipal.SetActive(false);
            fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.015f, 0) * Time.deltaTime;

            // Mover Obstaculos
            for (int i = 0; i < obstaculos.Count; i++)
            {
                if (obstaculos[i].transform.position.x <= -10)
                {
                    float randomObs = Random.Range(11, 18);
                    obstaculos[i].transform.position = new Vector3(randomObs, -2, 0);
                }
                obstaculos[i].transform.position = obstaculos[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }
        }

    }
}

