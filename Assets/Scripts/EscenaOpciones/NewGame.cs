using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    [SerializeField] AudioSource BotonEfecto;
    public static int NumJugadores = 0;
    GameObject Handler;
    private void Start()
    {
        HandlerCrearJugador.Jugadores.Clear();
        NumJugadores = 0;
        Handler = GameObject.Find("TransicionManager");
    }
    public void OnButtonClick(int a)
    {
        NumJugadores = a;
        BotonEfecto.Play();
        StartCoroutine(Handler.GetComponent<ActivarTransicion>().IniciarTransicion(0.4f, 2));
    }

    public void VolverATitulo()
    {
        Destroy(GameObject.Find("OptionsAudioManager"));
        BotonEfecto.Play();
        StartCoroutine(Handler.GetComponent<ActivarTransicion>().IniciarTransicion(1.6f, 0));
    }
}
