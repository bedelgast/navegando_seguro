using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguirjugador : MonoBehaviour {

    //Script basado en el tutorial de creacion de juego "Space Shooter" en youtube www.youtube.com/user/quill18creates
    //Script asociado al anonimo. Hace que el persiga el jugador en el escenario

    public float velRot = 90f;
    Transform player;

    void Update()
    {
        if (player == null)
        {
            GameObject go = GameObject.FindWithTag("Player");
            //El jugador tiene asignado la tag player, entonces se asigna el Transform del jugador a la variable
            if (go != null)
            {
                player = go.transform;
            }
        }
        if (player == null)
            return; //Si no encuentra el jugador entonces sale y prueba otra vez

        Vector3 dir = player.position - transform.position;
        dir.Normalize();
        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, velRot * Time.deltaTime);
        //Aca lo que hace es definir un vector entre el anonimo y el jugador, calcular el angulo entre los dos y luego
        //aplicar al Transform la rotacion para "mirar" en direccion al jugador
    }
}