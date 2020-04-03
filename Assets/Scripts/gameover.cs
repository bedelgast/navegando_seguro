using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    //Script asociado al controlador de gameover para la animacion de TIEMPO. Re atado con alambre

    private Animator anim;
    private int cantidad;
    private int nivel;
    GameObject go;
    escenas scriptescenas;

    void Start()
    {
        anim = GetComponent<Animator>();
        Setnivel(); //Busca el controlador de la portada para recuperar el valor de la cantidad de enemigos a disparar segun la dificultad seleccionada
    }

    public void Gameover(int x)
    {
        anim.SetFloat("fin", 0f); //Setea el parametro que dispara la transicion
        cantidad = x; //Recibe la cantidad de enemigos derrotados 
    }

    public void Fadeout() //Este metodo esta asociado a la animacion de Fadeout. Luego de terminada esa animacion hay un evento que llama al metodo y cambia de escena segun la cantidad de enemigos derrotados
    {
        if (cantidad >= nivel)
        {
            SceneManager.LoadScene("final-si");
        }
        else
        {
            SceneManager.LoadScene("final-no");
        }
    }
    //En la escena final hay una animacion de Fadein que se ejecuta luego de cargar, asi hace la transicion de una escena a otra con mas fluidez

    void Setnivel()
    {
        go = GameObject.FindWithTag("Global");
        scriptescenas = go.GetComponent<escenas>();
        nivel = scriptescenas.valor;
    }
}
