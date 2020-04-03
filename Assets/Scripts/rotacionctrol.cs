using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacionctrol : MonoBehaviour
{
    //Script en el objeto hijo del anonimo
    //Obliga al transform del objeto a no cambiar su rotacion
    //(en realidad siempre lo esta seteando para no "girar" el sprite, no se... fue la unica solucion que encontre para que la imagen no gire ya que necesitaba que quedara quieta >.< pero funciona, es el tipico: "atado con alambre")

    void Update()
    {
        transform.rotation = Setear();
    }

    private Quaternion Setear()
    {
        Quaternion newQuaternion = new Quaternion();
        newQuaternion.Set(0, 0, 0, 1);
        return newQuaternion;
    }
}
