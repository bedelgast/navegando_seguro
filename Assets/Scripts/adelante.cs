using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adelante : MonoBehaviour
{
    //Script que da el movimiento hacia adelante al anonimo (el script "seguijugador" da el movimiento lateral, el giro)

    public float velMax = 5f;
    float direccion = 1f; //Variable que se encarga de dar el sentido/direccion al vector velocidad. Se utiliza para el efecto aturdir del jugador

    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 velocidad = new Vector3(0, velMax * Time.deltaTime, 0) * direccion;
        pos += transform.rotation * velocidad;
        transform.position = pos;
    }

    void Alejar() //Cuando el anonimo toca el jugador este queda aturdido, con lo cual el anonimo se aleja del jugador por unos segundos
    {
        direccion = -1f; //Esto es algebra, chicos. Multiplicar un vector por -1 es invertir su sentido. El anonimo antes andaba para adelante, ahora anda hacia atras
        Invoke("Seguir", 3); //Luego de 3seg se vuelve el vector al sentido normal, hacia adelante
    }

    void Seguir()
    {
        direccion = 1f;
    }

    public void Destruir()
    {
        Destroy(gameObject);
    }
}