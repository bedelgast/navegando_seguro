using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparoenemigo : MonoBehaviour
{
    //Script que controla el disparo del virus (el unico enemigo que dispara)

    public GameObject rojo;
    public float tiempoDisparo = 0.25f;
    private int tiempoInicio = 2;

    void Start()
    {
        InvokeRepeating("Disparar", tiempoInicio , tiempoDisparo);
        //Tiempo de inicio es el tiempo que el objeto virus tarda en aparecer en la escena cuando es instanciado
    }

    void Disparar()
    {
        Vector3 distancia = new Vector3(0, 0.8f, 0);
        Instantiate(rojo, transform.position - distancia, transform.rotation);
        //Se resta distancia para que el disparo aparezca en frente del virus
    }

    void Cancelar()
    {
        CancelInvoke();//Se creo ese metodo para que el virus deje de disparar cuando el jugador lo mata
    }

}
