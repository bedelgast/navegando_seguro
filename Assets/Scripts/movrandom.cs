using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movrandom : MonoBehaviour
{
    //Script basado en un tutorial explicando el uso del metodo Lerp para Vectores disponible en arjierdagames.com/blog/unity/que-es-el-lerp-y-como-usarlo-correctamente/
    
    public float Velocidad;
    public Transform[] Puntos; //Puntos donde el virus se mueve en el juego
    public Transform[] Entrada; //Punto de entrada al juego

    //Internos
    int indexA = 0; //Index para mover en puntos
    int indexB = 0;
    int maxIndex;
    Vector3 PuntoA; //Punto A para Lerp
    Vector3 PuntoB; //Punto B para Lerp
    float t; //Factor tiempo de Lerp
    float factorT; //Factor de moviemnto

    void Start()
    {
        t = 1f; //Esto ayuda al primer calculo
        maxIndex = Puntos.Length - 1;
        Entrar(); //Este metodo se aplica una sola vez para que el virus entre a la escena desde el punto de entrada
    }

    void Entrar()
    {
        PuntoA = Entrada[0].position;
        indexB = Random.Range(0, maxIndex);
        PuntoB = Puntos[indexB].position;
        t = 1.0f - t; //Solo para continuar con el movimiento y no se vea brusco una pausa
                      //FactorT siempre sera diferente entre puntos, pero al final esto ayudara que el moviento siempre sea la misma.
        factorT = 1.0f / Vector3.Distance(PuntoA, PuntoB) * Velocidad;
    }

    void Update()
    {
        t += factorT * Time.deltaTime;
        if (t >= 1f) //ya llegamos?
        {
            indexA = indexB;
            indexB = Random.Range(0,maxIndex);
            while (indexA == indexB)
            {
                indexB = Random.Range(0, maxIndex);
            }
            CalcularValores();
        }
        transform.position = Vector3.Lerp(PuntoA, PuntoB, t); //Aca se usa el Lerp
    }

    void CalcularValores()
    {
        PuntoA = Puntos[indexA].position;
        PuntoB = Puntos[indexB].position;
        t = 1.0f - t; //Solo para continuar con el movimiento y no se vea brusco una pausa
                      //FactorT siempre sera diferente entre puntos, pero al final esto ayudara que el moviento siempre sea la misma.
        factorT = 1.0f / Vector3.Distance(PuntoA, PuntoB) * Velocidad;
    }
}
