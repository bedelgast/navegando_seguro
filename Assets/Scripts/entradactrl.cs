using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class entradactrl : MonoBehaviour
{
    //Script que controla el cambio de escena de la entrada del jugador para la "batalla"
    //Se lo creo por que la entrada tiene una animacion que cuando se terminaba no devolvia el control del personaje al jugador
    //No sabia como resolver el problema, qsy... fue la mejor solucion que encontre y tiene basicamente dos lineas de codigo. Sry not sry. Otro tipico "atado con alambre"

    string escena;

    void Start()
    {
        escena = SceneManager.GetActiveScene().name;
        Invoke("CambiarEscena",4); //Invoca el cambio de escena en 4seg, que es el tiempo de la animacion de entrada
    }

    void CambiarEscena()
    {
        if (escena == "entrada-el")
        {
            SceneManager.LoadScene("batalla-el");
        }
        else
        {
            if (escena == "entrada-ella")
            {
                SceneManager.LoadScene("batalla-ella");
            }
            else
            {
                SceneManager.LoadScene("batalla-pix");
            }
        }
    }
}