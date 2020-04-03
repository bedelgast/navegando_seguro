using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausa : MonoBehaviour
{
    //Script asociado al controlador de la partida y a la animacion de entrada de los personajes en las escenas de entrada de cada uno
    //Una pausa con el boton de espacio del teclado. Cuando el timeScale es 1 el juego se ejecuta normal, cuando es 0 se pausa todo

    void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            if (Time.timeScale == 1)
            {   
                Time.timeScale = 0;
            }
            else if (Time.timeScale == 0)
            {   
                Time.timeScale = 1;
            }
        }
    }


}
