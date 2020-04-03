using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viajedisparo : MonoBehaviour
{
    //Script que mueve el disparo del jugador (es el mismo para los dos disparos que tiene)
    //Es la misma logica del script del disparo del enemigo, pero sumando el vector ya que el disparo va hacia arriba en el escenario

    public float maxVel = 7f;

    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 velocidad = new Vector3(0, maxVel * Time.deltaTime, 0);
        pos += transform.rotation * velocidad;
        transform.position = pos;

        //Aca controlamos para que el objeto disparo se destruya cuando llegue al borde superior del escenario
        if (pos.y > Camera.main.orthographicSize)
        {
            Destroy(gameObject);
        }
    }
}
