using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class controlador : MonoBehaviour
{
    //Script del controlador de la partida. Contiene el tiempo de juego y el contador de enemigos disparados
    //Tambien tiene asociada la animacion del countdown para finalizar la partida y evaluar si el jugador cumplio la mision del juego

    private int tiempo;
    public int contador = 0;
    private Animator anim;
    public GameObject controladorGO;
    GameObject findejuego;
    AudioSource sonido;

    void Start()
    {
        anim = GetComponent<Animator>();
        findejuego = Instantiate(controladorGO) as GameObject;
        sonido = GetComponent<AudioSource>();
    }

    void Contar() //Metodo para acumular la cantidad de enemigos derrotados
    {
        contador++;
    }

    void Update()
    {
        tiempo = (int) Time.timeSinceLevelLoad;
        if (tiempo == 90)
        {
            anim.SetFloat("tiempo", 0f); //Luego de llegar al tiempo limite de la partida se activa la animacion del countdown que prepara el fin del juego
            Invoke("Nuevoset",5); //Se hace un nuevo set para que la animacion desaparezca
        }
        if (tiempo >= 98) //Despues del tiempo de las animaciones disminuye el volumen de la musica, intentando coordinar con el fadeout
        {
            sonido.volume -= Time.deltaTime;
        }
    }

    void Nuevoset()
    {
        anim.SetFloat("tiempo", 1f);
        findejuego.SendMessage("Gameover", contador); //Al desaparecer el countdown se envia un mensaje al controlador del gameover para la animacion de "tiempo" y la cantidad de enemigos derrotados
    }
}
