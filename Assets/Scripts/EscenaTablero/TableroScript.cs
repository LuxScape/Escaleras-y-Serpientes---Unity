using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEditor;
using UnityEngine;

public class TableroScript : MonoBehaviour
{
    List<FichaScript> ListaFichas= new List<FichaScript>();
    [SerializeField] FichaScript Prefab;
    [SerializeField] DadoScript Dado;
    [SerializeField] MainHUDScript MainHUD;
    int TurnoActual=0;

    /// <summary>
    /// Con RollDadoInicial creamos las fichas de jugador y 
    /// Determinamos el orden con el que haran los turnos
    /// Despues de ello, iniciamos el gameplay normal con NewTurn()
    /// </summary>
    void Start()
    {
        Dado.DisableButton(); //Deshabilitamos el dado para impedir que el jugador pueda interactuar con el durante la determinacion del orden
        CreadorFicha();
        StartCoroutine(MainHUD.RollDadoInicial(ListaFichas)); //Dentro de esta corutina se llama a NewTurn()
    }

    // Update is called once per frame
    void Update()
    {
        if (ListaFichas[TurnoActual].InvalidMovement == true)
        {
            MainHUD.PrintMovimientoInvalido();
        }
    }

    /// <summary>
    /// Esta Funcion se llama al inicio de un nuevo turno,
    /// se encarga de re-activar el dado y mandarle al HUD los
    /// datos del jugador con el turno actual. Al re-activar el dado
    /// permite al jugador hacer clic sobre el y de esta forma llamar
    /// a ExecuteRoll()
    /// 
    /// CICLO DE TURNO
    /// 
    /// 1. NewTurn() -> 2. ExecuteRoll() [Al clickear el dado] -> HandleCurrentTurn() -> EndTurn()
    /// </summary>
    public void NewTurn()
    {
        Dado.gameObject.SetActive(true);
        StopAllCoroutines();
        Dado.EnableButton();
        Dado.ResetFlags();
        StartCoroutine(MainHUD.NuevoTurno(ListaFichas[TurnoActual]));
    }
    void CreadorFicha()
    {
        List<DatosJugador> ListaDatos = HandlerCrearJugador.Jugadores;
        int NumJugadores = NewGame.NumJugadores;

        for (int i = 0; i < NumJugadores; i++)
        {
            FichaScript Ficha = Instantiate(Prefab) as FichaScript;
            Ficha.InicializarFicha(ListaDatos[i].Nombre, ListaDatos[i].Color);
            ListaFichas.Add(Ficha);
        }
    }

    /// <summary>
    /// Esta funcion se llama cuando el jugador hace click en el dado,
    /// Se lanza el dado y luego se deshabilita para evitar un segundo
    /// lanzamiento por parte del mismo jugador, finalmente se llama a
    /// HandleCurrenTurn() y se le envia el roll del dado para que la
    /// ficha del jugador se mueva los espacios determinados por el roll.
    /// </summary>
    public void ExecuteRoll()
    {
        int Numero = Dado.Roll();
        Dado.DisableButton();
        print(Numero);
        StartCoroutine(MainHUD.DeshabilitarHud(Numero));
        StartCoroutine(HandleCurrentTurn(Numero));
    }
    IEnumerator HandleCurrentTurn(int Num)
    {
        ListaFichas[TurnoActual].MoveChecker(Num);
        yield return new WaitUntil(()=> ListaFichas[TurnoActual].IsTurnEnded==true);
        ListaFichas[TurnoActual].IsTurnEnded = false;
        EndTurn();
    }
    void EndTurn()
    {
        if (ListaFichas[TurnoActual].Won == true)
        {
            EndGameplay();
        }
        else
        {
            TurnoActual++;
            if (TurnoActual == ListaFichas.Count)
            {
                TurnoActual = 0;
                NewTurn();
            }
            else
            {
                NewTurn();
            }

        }
    }
    void EndGameplay()
    {
        TableroAudioManager.PlayMusicaVictoria();
        StartCoroutine(MainHUD.MostrarGanador(ListaFichas[TurnoActual]));
    }

    //Funciones usadas para crear objetos fichas dentro de la escena tablero
    //Asi podemos hacer tests sin necesidad de pasar por las escenas anteriores
    //Para crear fichas.
    void CreadorFichaTest(int a)
    {
        int NumJugadores = a;
        for (int i = 0; i < NumJugadores; i++)
        {
            FichaScript Ficha = Instantiate(Prefab) as FichaScript;
            Ficha.InicializarFicha("Test" + i, ReturnColor(i));
            ListaFichas.Add(Ficha);
        }
    }
    string ReturnColor(int a)
    {
        if (a == 0) return "Amarillo";
        else if (a == 1) return "Azul";
        else if (a == 2) return "Verde";
        else return "Rojo";
    }

}
