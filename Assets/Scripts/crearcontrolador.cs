using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crearcontrolador : MonoBehaviour
{
	//Script asociado al jugador que se encarga de crear el objeto controlador de la partida cada vez que se juega

    public GameObject objcontrolador;
    GameObject control;

    void Start()
    {
        control = Instantiate(objcontrolador) as GameObject;
    }
}
