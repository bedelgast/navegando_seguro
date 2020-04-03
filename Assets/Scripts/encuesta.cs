using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class encuesta : MonoBehaviour
{
    //Script asociado al fondo de la ultima escena de encuesta para registrar los datos de los ninios que asisten al estand
    //Crea un archivo json para registrar los datos nombre, apellido, direccion, edad y la cantidad de responsables que lo acompanian en el dia
    //Cada persona seria un nuevo objeto de la clase persona. Cuando no completa un dato el campo queda vacio

    public string n; //Variables para captar los datos ingresados en el formulario
    public string a;
    public string d;
    public int e;
    public int r;
    string datos;
    string directorio;
    string hoy;
    public System.DateTime aux;

    void Start()
    {
        directorio = Application.dataPath + "/encuesta.json"; //dataPath es la carpeta del juego, que contiene el ejecutable, cuando ya esta compilado (la que tiene el nombre del juego/proyecto). Cuando el juego esta en "formato" proyecto el Path es la carpeta Assets
        CrearEncuesta();
        SetFecha();
    }

    void CrearEncuesta() //Si el archivo no existe entonces lo crea, de lo contrario no hace nada
    {
        if (!File.Exists(directorio))
        {
            File.Create(directorio);
        }
        else
        {
            return;
        }
    }

    public void CambiarEscena(string x) //Metodo para cambiar a la portada al mismo tiempo que registra los datos de la encuesta (cuando hace click en la flecha)
    {
        SceneManager.LoadScene(x);
    }

    void SetFecha()
    {
        aux = System.DateTime.Today;
        hoy = aux.ToString("dd/MM/yyyy");//El mes va con mayusculas por que si no el sistema imprime los minutos que son con minusculas
    }

    public void Setnombre(string l) //Metodos para almacenar en las variables lo que el usuario ingresa en los campos del formulario
    {
        n = l;
    }
    public void Setapellido(string m)
    {
        a = m;
    }
    public void Setdireccion(string n)
    {
        d = n;
    }
    public void Setedad(string o)
    {
        e = int.Parse(o);
    }
    public void Setresponsables(string p)
    {
        r = int.Parse(p);
    }

    public void Registrar() //Metodo que abre el archivo json, "rellena" los atributos de la persona, concatena con lo que tenia ya en el archivo y lo vuelve a guardar
    {
        datos = File.ReadAllText(directorio);
        Persona persona = new Persona();
        persona.nombre = n;
        persona.apellido = a;
        persona.direccion = d;
        persona.edad = e;
        persona.cant_responsables = r;
        persona.fecha = hoy;
        datos = datos + JsonUtility.ToJson(persona);
        File.WriteAllText(directorio, datos);
    }
}
//Definicion de la clase persona
 [System.Serializable]
 public class Persona
    {
        public string nombre;
        public string apellido;
        public string direccion;
        public int edad;
        public int cant_responsables;
        public string fecha;
    }