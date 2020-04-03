using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animctrlanonimo : MonoBehaviour
{
    //Script que controla la animacion del anonimo

    private Animator anim;
    private adelante scriptoAdel;
    GameObject partida;

    void Start()
    {
        anim = GetComponent<Animator>();
        scriptoAdel = GetComponentInParent<adelante>(); //Recupera el script del objeto padre para acceder a las variables publicas
        partida = GameObject.FindWithTag("GameController");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            scriptoAdel.SendMessage("Alejar"); //Envia mensaje al script "adelante" para que se aleje
        }

        if (collision.tag == "disparoazul")
        {
            anim.SetFloat("vida", 0f);
            gameObject.layer = 13; //Se cambia el layer del objeto para que el jugador no sufra daños mientras se ejecuta la animacion del virus
            scriptoAdel.velMax = 0f; //Pone la velocidad del anonimo en cero para que deje de moverse
            Invoke("Destruirpadre", 2); //Llama al metodo de destruir el objeto padre luego del tiempo de la animacion
            partida.SendMessage("Contar");
        }
    }

    void Destruirpadre()
    {
        scriptoAdel.SendMessage("Destruir"); //Destruye tambien el ob
    }
}
