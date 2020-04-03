using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollfondo : MonoBehaviour
{
    //Script basado en el tutorial de youtube disponible en www.youtube.com/watch?v=epRPKFsOPck
    //Controla el scroll del fondo del juego

    public float velocidady = 0.5f; //Velocidad en el eje y, ya que el fondo se mueve en la vertical
    Vector2 fondo;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        fondo = new Vector2(0, velocidady);
    }

    void Update()
    {
        rend.material.mainTextureOffset += fondo * Time.deltaTime;
    }
}
