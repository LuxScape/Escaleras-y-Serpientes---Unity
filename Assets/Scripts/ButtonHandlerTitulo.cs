using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandlerTitulo : MonoBehaviour
{
    [SerializeField] AudioClip MusicaTitulo;
    [SerializeField] AudioClip OnClickBoton;
    [SerializeField] AudioSource AudioHandler;
    public void OnButtonPressTitulo()
    {
        AudioHandler.clip = OnClickBoton;
        AudioHandler.loop = false;
        AudioHandler.Play();
        GameObject Handler= GameObject.Find("TransicionManager");
        StartCoroutine(Handler.GetComponent<ActivarTransicion>().IniciarTransicion(1.8f, 1));
    }
}
