using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivarTransicion : MonoBehaviour
{
    [SerializeField] Animator ParteSuperior;
    [SerializeField] Animator ParteInferior;

    public IEnumerator IniciarTransicion(float Delay, int Escena)
    {
        ParteSuperior.SetTrigger("Start");
        ParteInferior.SetTrigger("StartDown");

        yield return new WaitForSeconds(Delay);

        SceneManager.LoadScene(Escena);
    }
}
