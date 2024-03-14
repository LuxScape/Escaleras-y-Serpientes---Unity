using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TableroAudioManager
{
    static AudioTablero Referencia;

    public static void PlayMusicaVictoria()
    {
        Referencia.PlayMusicaVictoria();
    }

    public static void PlayLanzarDado()
    {
        if (Referencia == null)
        {
            UpdateReferencia();
        }
        else
        {
            Referencia.PlayLanzarDado();
        }
    }
    public static void PlayMoverFicha()
    {
        if (Referencia == null)
        {
            UpdateReferencia();
        }
        else
        {
            Referencia.PlayMoverFicha();
        }
    }
    public static void StopMusica()
    {
        if (Referencia == null)
        {
            UpdateReferencia();
        }
        else
        {
            Referencia.StopMusica();
        }
    }

    //Despues de volver al menu de opciones al finalizar una partida, la referencia original se destruye, por lo que
    //Se hace esto para obtener una nueva referencia al iniciar un nuevo juego
    static void UpdateReferencia()
    {
        Referencia = GameObject.Find("Manager").GetComponent<AudioTablero>();
    }
}
