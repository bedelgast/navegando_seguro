using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigorevive : MonoBehaviour
{
    //Script que controla el respawn del anonimo. Esta asociado al jugador. Crea un nuevo anonimo cada 4 o 10 segundos, depende del nivel seleccionado

    public GameObject enemigos;
    public int tiempoCreacion;
    float ancho;
    GameObject go;
    escenas scriptescenas;

    void Start()
    {
        ancho = Calcular();
        Setearnivel(); //Busca en el controlador de la portada la variable que tiene el tiempo de respawn del anonimo segun el nivel del juego seleccionado
        Invoke("Destruye", 2);//Destruye el controlador de la portada para que no quede ahi sin uso
        InvokeRepeating("Creando", 3f, tiempoCreacion); //InvokeRepeating(nombre funcion, tiempo hasta primer invocacion, tiempo para repetir)
    }
    
    float Calcular() //calcula el ancho de la pantalla
    {
        float escala = (float)Screen.width / (float)Screen.height;
        float x = Camera.main.orthographicSize * escala; //x representa el ancho
        return x;
    }

    public void Creando()
    {
        Vector3 puntorevivir = new Vector3(Random.Range(-ancho,ancho), 5f, 0); //crea un nuevo objeto anonimo entre los valores del acho y por afuera de la escena
        Instantiate(enemigos, puntorevivir, Quaternion.AngleAxis(180,Vector3.forward));//el quaternion lo gira 180° para que se instancie con la face apuntando al jugador
    }

    void Setearnivel()
    {
        go = GameObject.FindWithTag("Global");
        scriptescenas = go.GetComponent<escenas>();
        tiempoCreacion = scriptescenas.tiempo;
    }

    void Destruye()
    {
        Destroy(go);
    }
}
