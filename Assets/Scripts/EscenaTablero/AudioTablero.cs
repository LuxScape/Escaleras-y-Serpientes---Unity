using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioTablero: MonoBehaviour
{
    [SerializeField] AudioClip MusicaPrincipal;
    [SerializeField] AudioClip MusicaVictoria;
    [SerializeField] AudioClip LanzarDado;
    [SerializeField] AudioClip MoverFicha;
    [SerializeField] AudioSource MusicaPrincipalManager;
    [SerializeField] AudioSource EfectosManager;

    public void PlayMusicaVictoria()
    {
        MusicaPrincipalManager.clip = MusicaVictoria;
        MusicaPrincipalManager.loop = false;
        MusicaPrincipalManager.Play();
    }
    public void PlayLanzarDado()
    {
        EfectosManager.clip = LanzarDado;
        EfectosManager.Play();
    }
    public void PlayMoverFicha()
    {
        EfectosManager.clip = MoverFicha;
        EfectosManager.Play();
    }
    public void StopMusica()
    {
        MusicaPrincipalManager.Stop();
    }
}
