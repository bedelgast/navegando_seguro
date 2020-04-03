using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virusrevive : MonoBehaviour
{
    //Script que controla el respawn del virus. Asociado al jugador. Está hecho para que aparezca un nuevo virus 1seg despues de disparar al virus en la escena
    
    public GameObject virusPrefab;
    GameObject virus;
    float tiempo;

    void Start()
    {
        Revivir();
    }

    void Revivir()
    {
        Vector3 pos = new Vector3(0, 7, 0); //Marca el origen de creacion del objeto afuera de la escena
        tiempo = 1f; //Tiempo de revivir un nuevo virus
        virus = (GameObject)Instantiate(virusPrefab, pos, Quaternion.identity); //La nueva instancia del objeto virus se asigna a una variable
    }

    void Update()
    {
        if (virus == null) //Cuando se dispara a un virus...
        {
            tiempo -= Time.deltaTime; //...resta deltatime a tiempo hasta llegar a cero y ahi llamar al metodo de revivir el virus
            if (tiempo < 0)
            {
                Revivir();
            }
        }
    }
}
