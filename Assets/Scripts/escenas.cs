using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class escenas : MonoBehaviour
{
    //Script general asociado a los botones de las placas para navegar por las escenas del juego
    //Esta adaptado para que en la portada se detecte cual nivel fue seleccionado y cambie los tiempos de respawn de los enemigos en la escena de batalla

    public int tiempo;
    public int valor;

    public void Facil(int x)
    {
        tiempo = x;
        valor = 12;
        DontDestroyOnLoad(this.gameObject);
        CambiarEscena("objetivo");
    }

    public void Normal(int x)
    {
        tiempo = x;
        valor = 23;
        DontDestroyOnLoad(this.gameObject);//Se usa DontDestroyOnLoad para que el objeto no se destruya en el cambio de escenas y asi el controlador de la partida pueda obtener los valores de tiempo de respawn y partida. Otro tipico "atado con alambre"
        CambiarEscena("objetivo");
    }

    public void CambiarEscena( string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    public void Salir()
    {
        Application.Quit(); //Metodo asociado al boton oculto de la portada para salir del juego
    }
}
