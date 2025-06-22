using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueCuerpoACuerpo : MonoBehaviour
{
    public Transform areaAtaque;
    public float radioAtaque = 1f;
    public LayerMask capaEnemigos;
    public int daño = 1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            EjecutarAtaque();
        }
    }

    void EjecutarAtaque()
    {
        Collider2D[] enemigosGolpeados = Physics2D.OverlapCircleAll(areaAtaque.position, radioAtaque, capaEnemigos);

        foreach (Collider2D enemigo in enemigosGolpeados)
        {
            enemigo.GetComponent<Enemigo>()?.RecibirDaño(daño);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (areaAtaque != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(areaAtaque.position, radioAtaque);
        }
    }
}
