using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class HandlerCrearJugador : MonoBehaviour
{
    string Nombre="";
    string Color="";
    public static List<DatosJugador> Jugadores= new List<DatosJugador>();
    int JugadoresCount=1;
    [SerializeField] TextMeshProUGUI JugadorActual;
    [SerializeField] UnityEngine.UI.Button BotonAmarillo;
    [SerializeField] UnityEngine.UI.Button BotonAzul;
    [SerializeField] UnityEngine.UI.Button BotonVerde;
    [SerializeField] UnityEngine.UI.Button BotonRojo;
    [SerializeField] UnityEngine.UI.Button BotonCrear;
    [SerializeField] TMP_InputField InputTexto;
    [SerializeField] AudioSource EffectsHandler;
    [SerializeField] AudioClip opcionesAtablero;
    GameObject TransicionHandler;

    private void Start()
    {     
        JugadorActual.text = "Jugador 1";
        TransicionHandler = GameObject.Find("TransicionManager");
    }
    private void Update()
    {
        if (Nombre!="" && Color != "")
        {
            BotonCrear.interactable = true;
        }
        else
        {
            BotonCrear.interactable=false;
        }
    }

    public void CrearJugador()
    {
        EffectsHandler.Play();
        DatosJugador Jugador = new DatosJugador(this.Nombre, this.Color);
        Jugadores.Add(Jugador);
        JugadoresCount++;
        ButtonDisabler();
        InputTexto.text = "";
        if (JugadoresCount > NewGame.NumJugadores)
        {
            Destroy(GameObject.Find("OptionsAudioManager"));
            EffectsHandler.clip = opcionesAtablero;
            EffectsHandler.Play();
            StartCoroutine(TransicionHandler.GetComponent<ActivarTransicion>().IniciarTransicion(1.6f,3));
        }
        else
        {
            JugadorActual.text = "Jugador " + JugadoresCount;
        }
    }
    public void HandlerNombre(TMP_InputField Name)
    {
        this.Nombre = Name.text;
    }
    public void HanderColor(string Color)
    {
        EffectsHandler.Play();
        this.Color = Color;
    }

    void ButtonDisabler()
    {
        if (this.Color == "Amarillo")
        {
            BotonAmarillo.interactable= false;
            Color = "";
        }
        else if (this.Color == "Verde")
        {
            BotonVerde.interactable= false;
            Color = "";
        }
        else if (this.Color== "Azul")
        {
            BotonAzul.interactable = false;
            Color = "";
        }
        else if (this.Color == "Rojo")
        {
            BotonRojo.interactable = false;
            Color = "";
        }
    }
    public void VolverOpciones()
    {
        EffectsHandler.Play();
        StartCoroutine(TransicionHandler.GetComponent<ActivarTransicion>().IniciarTransicion(0.4f, 1));
    }
}
public class DatosJugador
{
    public string Nombre;
    public string Color;

    public DatosJugador(string Nombre, string Color)
    {
        this.Nombre = Nombre;
        this.Color = Color;
    }
}
