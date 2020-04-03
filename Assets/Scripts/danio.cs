using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danio : MonoBehaviour
{
    //Script que controla la mecanica de los disparos

    void OnTriggerEnter2D()
    {
        Destroy(gameObject); //Cuando un disparo detecta una colision entonces se destruye
    }
}
