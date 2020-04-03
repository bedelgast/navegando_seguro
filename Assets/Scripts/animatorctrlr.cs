using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorctrlr : MonoBehaviour
{
    //Script que controla la animacion del virus

    private Animator anim;
    private float valor = 1.0f;
    private movrandom scriptoMov;
    private disparoenemigo scriptoDisp;
    GameObject partida;

    void Start()
    {
        anim = GetComponent<Animator>();
        scriptoMov = GetComponent<movrandom>(); 
        scriptoDisp = GetComponent<disparoenemigo>(); //Variables que almacenan los componentes para accederlos y cambiar las variables para mejorar la ejecucion de la animacion
        partida = GameObject.FindWithTag("GameController");
    }

    void OnTriggerEnter2D()
    {
        valor--; //Disminuye la variable que contiene el valor que activa la transicion de la animacion de explosion del virus
        anim.SetFloat("vida", valor);
        gameObject.layer = 13;//Se cambia el layer del objeto para que el jugador no sufra daños mientras se ejecuta la animacion del virus
        scriptoMov.enabled = false; //Desactiva el script de movimiento
        scriptoDisp.SendMessage("Cancelar"); //Envia un mensaje al script de disparar y cancela el metodo Invoke
        partida.SendMessage("Contar"); //Envia un mensaje al controlador de la partida para que incremente en uno el acumulador de enemigos
        Invoke("DestruirAnimacion", 1); //Despues de todo el proceso de la animacion se destruye el objeto virus
    }

    void DestruirAnimacion()
    {
        Destroy(gameObject);
    }
}
