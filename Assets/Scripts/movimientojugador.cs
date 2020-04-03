using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movimientojugador : MonoBehaviour
{
    //Script basado en el tutorial de creacion de juego "Space Shooter" en youtube www.youtube.com/user/quill18creates
    //Se encarga de controlar el movimiento vertical y horizontal del personaje
    //Como "enemigo" entiendase como el anonimo
    
    float bordeNave = 0.8f;
    public float maxVel = 7f;
    float ancho;
    Animator anim;

    void Start()
    {
        ancho = Calcular();
        anim = GetComponent<Animator>();
    }

    float Calcular() //Calcula el ancho de la pantalla
    {
        float escala = (float)Screen.width / (float)Screen.height;
        float x = Camera.main.orthographicSize * escala; //x representa el ancho
        return x;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemigo") //Si detecta que un enemigo lo toco entonces pone la velocidad en cero para tener el efecto de aturdido y no se mueva
        {
            maxVel = 0f;
        }
        if (collision.tag == "virus")
        {
            maxVel = 3.5f;
        }
        Invoke("Mover", 3); //Luego de 3seg llama al metodo que restablece la velocidad de movimiento
        anim.SetBool("toque", true); //Activa la animacion de aturdido(a)
    }

    void Mover()
    {
        maxVel = 7f;
        anim.SetBool("toque", false); //Cambia el parametro de la transicion para forzar el fin de la animacion de aturdido(a)
    }

    void Update()
    {
        //Primero calcula los valores de x e y en funcion del pulsar de las flechas del teclado
        Vector3 pos = transform.position;
        pos.y += Input.GetAxis("Vertical") * maxVel * Time.deltaTime;
        pos.x += Input.GetAxis("Horizontal") * maxVel * Time.deltaTime;

        //Aca controla para que el jugador no salga de la pantalla en el sentido vertical
        if (pos.y + bordeNave > Camera.main.orthographicSize){ 
            pos.y = Camera.main.orthographicSize - bordeNave;
        }
        if (pos.y - bordeNave < -Camera.main.orthographicSize){
            pos.y = -Camera.main.orthographicSize + bordeNave;
        }
        //Aca controla para que el jugador no salga de la pantalla en el sentido horizontal
        if (pos.x + bordeNave > ancho){
            pos.x = ancho - bordeNave;
        }
        if (pos.x - bordeNave < -ancho){
            pos.x = -ancho + bordeNave;
        }
        //Luego de todos los calculos y controles asigna los valores al Transform del objeto
        transform.position = pos;

        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("portada");
        }
    }
}