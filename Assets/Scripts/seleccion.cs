using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class seleccion : MonoBehaviour
{
    //Script asociado al controlador de la escena de seleccion. Configurado para detectar cual personaje jugara la partida

    public void Juegael()
    {
        SceneManager.LoadScene("entrada-el");
    }

    public void Juegaella()
    {
        SceneManager.LoadScene("entrada-ella");
    }

    public void Juegapix()
    {
        SceneManager.LoadScene("entrada-pix");
    }

}
