using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparar : MonoBehaviour
{
    //Script basado en el tutorial de creacion de juego "Space Shooter" en youtube www.youtube.com/user/quill18creates
    //Controla los disparos que tiene el personaje del jugador. En ese proyecto "Fire1" es el boton X y "Fire2" es el boton C del teclado

    public GameObject verde;
    public GameObject azul;
    public float tiempoDisparo = 0.25f;
    float control = 0;

    void Update()
    {
        control -= Time.deltaTime; //Aca se usa una variable para controlar el tiempo del disparo
        if (Input.GetButton("Fire1") && control <= 0)
        {
            control = tiempoDisparo;
            Vector3 distancia = new Vector3(0, 0.9f, 0);
            Instantiate(verde, transform.position + distancia, transform.rotation);
        }
        if (Input.GetButton("Fire2") && control <= 0)
        {
            control = tiempoDisparo;
            Vector3 distancia = new Vector3(0, 0.9f, 0);
            Instantiate(azul, transform.position + distancia, transform.rotation);//Suma la distancia para que el disparo apareza en frente al jugador
        }
    }
}
