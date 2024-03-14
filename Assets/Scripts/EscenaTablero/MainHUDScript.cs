using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainHUDScript : MonoBehaviour
{
    [SerializeField] DadoScript DadoPrincipal;
    [SerializeField] TextMeshProUGUI TextoPrincipal;
    [SerializeField] UnityEngine.UI.Button BotonNuevoJuego;
    public IEnumerator RollDadoInicial(List<FichaScript> ListaFichas)
    {
        BotonNuevoJuego.gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        TextoPrincipal.text= ("Decidamos el orden inicial");
        yield return new WaitForSeconds(1.4f);

        if (ListaFichas.Count == 2)
        {
            print("esto se llama");

            ListaFichas[0].transform.position = new Vector3(-3.5f, -1, 0);
            ListaFichas[1].transform.position = new Vector3(1, -1, 0);
            ListaFichas[0].transform.localScale = new Vector3(4, 4, 1);
            ListaFichas[1].transform.localScale = new Vector3(4, 4, 1);
            DadoScript DadoCopy = Instantiate(DadoPrincipal) as DadoScript;
            DadoPrincipal.transform.position=new Vector3(-2.3f, -1.8f, 0);
            DadoCopy.transform.position=new Vector3(2.3f, -1.8f, 0);
            yield return new WaitForSeconds(2);
            int Roll1 = DadoPrincipal.Roll();
            int Roll2 = DadoCopy.Roll();

            ListaFichas[0].RollInicial = Roll1;
            ListaFichas[1].RollInicial = Roll2;

            yield return new WaitForSeconds(3);

            ListaFichas.Sort((x,y)=>y.RollInicial.CompareTo(x.RollInicial));
            DadoCopy.Destruir();
            ListaFichas[0].transform.position = new Vector3(-6f, -5, 0);
            ListaFichas[1].transform.position = new Vector3(-6, -5, 0);
            ListaFichas[0].transform.localScale = new Vector3(1.610817f, 1.601588f, 1);
            ListaFichas[1].transform.localScale = new Vector3(1.610817f, 1.601588f, 1);
        }
        else if (ListaFichas.Count == 3)
        {
            print("esto se llama 3");

            ListaFichas[0].transform.position = new Vector3(-4.5f, -1, 0);
            ListaFichas[1].transform.position = new Vector3(-1.2f, -1, 0);
            ListaFichas[2].transform.position = new Vector3(2, -1, 0);
            ListaFichas[0].transform.localScale = new Vector3(4, 4, 1);
            ListaFichas[1].transform.localScale = new Vector3(4, 4, 1);
            ListaFichas[2].transform.localScale = new Vector3(4, 4, 1);
            DadoScript DadoCopy1 = Instantiate(DadoPrincipal) as DadoScript;
            DadoScript DadoCopy2 = Instantiate(DadoPrincipal) as DadoScript;
            DadoPrincipal.transform.position = new Vector3(-3.3f, -1.8f, 0);
            DadoCopy1.transform.position = new Vector3(0f, -1.8f, 0);
            DadoCopy2.transform.position = new Vector3(3.3f, -1.8f, 0);
            yield return new WaitForSeconds(2);
            int Roll1 = DadoPrincipal.Roll();
            int Roll2 = DadoCopy1.Roll();
            int Roll3 = DadoCopy2.Roll();

            ListaFichas[0].RollInicial = Roll1;
            ListaFichas[1].RollInicial = Roll2;
            ListaFichas[2].RollInicial = Roll3;

            yield return new WaitForSeconds(3);

            ListaFichas.Sort((x, y) => y.RollInicial.CompareTo(x.RollInicial));
            DadoCopy1.Destruir();
            DadoCopy2.Destruir();
            ListaFichas[0].transform.position = new Vector3(-6, -5, 0);
            ListaFichas[1].transform.position = new Vector3(-6, -5, 0);
            ListaFichas[2].transform.position = new Vector3(-6, -5, 0);
            ListaFichas[0].transform.localScale = new Vector3(1.610817f, 1.601588f, 1);
            ListaFichas[1].transform.localScale = new Vector3(1.610817f, 1.601588f, 1);
            ListaFichas[2].transform.localScale = new Vector3(1.610817f, 1.601588f, 1);
        }
        else if (ListaFichas.Count == 4)
        {
            print("esto se llama 4");

            ListaFichas[0].transform.position = new Vector3(-5f, -1, 0);
            ListaFichas[1].transform.position = new Vector3(-2.5f, -1, 0);
            ListaFichas[2].transform.position = new Vector3(0, -1, 0);
            ListaFichas[3].transform.position = new Vector3(2.5f, -1, 0);
            ListaFichas[0].transform.localScale = new Vector3(4, 4, 1);
            ListaFichas[1].transform.localScale = new Vector3(4, 4, 1);
            ListaFichas[2].transform.localScale = new Vector3(4, 4, 1);
            ListaFichas[3].transform.localScale = new Vector3(4, 4, 1);
            DadoScript DadoCopy1 = Instantiate(DadoPrincipal) as DadoScript;
            DadoScript DadoCopy2 = Instantiate(DadoPrincipal) as DadoScript;
            DadoScript DadoCopy3 = Instantiate(DadoPrincipal) as DadoScript;
            DadoPrincipal.transform.position = new Vector3(-3.8f, -1.8f, 0);
            DadoCopy1.transform.position = new Vector3(-1.3f, -1.8f, 0);
            DadoCopy2.transform.position = new Vector3(1.3f, -1.8f, 0);
            DadoCopy3.transform.position = new Vector3(3.8f, -1.8f, 0);
            yield return new WaitForSeconds(2);
            int Roll1 = DadoPrincipal.Roll();
            int Roll2 = DadoCopy1.Roll();
            int Roll3 = DadoCopy2.Roll();
            int Roll4 = DadoCopy3.Roll();

            ListaFichas[0].RollInicial = Roll1;
            ListaFichas[1].RollInicial = Roll2;
            ListaFichas[2].RollInicial = Roll3;
            ListaFichas[3].RollInicial = Roll4;

            yield return new WaitForSeconds(3);

            ListaFichas.Sort((x, y) => y.RollInicial.CompareTo(x.RollInicial));
            DadoCopy1.Destruir();
            DadoCopy2.Destruir();
            DadoCopy3.Destruir();
            ListaFichas[0].transform.position = new Vector3(-6, -5, 0);
            ListaFichas[1].transform.position = new Vector3(-6, -5, 0);
            ListaFichas[2].transform.position = new Vector3(-6, -5, 0);
            ListaFichas[3].transform.position = new Vector3(-6, -5, 0);
            ListaFichas[0].transform.localScale = new Vector3(1.610817f, 1.601588f, 1);
            ListaFichas[1].transform.localScale = new Vector3(1.610817f, 1.601588f, 1);
            ListaFichas[2].transform.localScale = new Vector3(1.610817f, 1.601588f, 1);
            ListaFichas[3].transform.localScale = new Vector3(1.610817f, 1.601588f, 1);
        }
        GameObject.Find("Tablero").GetComponent<TableroScript>().NewTurn();
    }
    public IEnumerator NuevoTurno(FichaScript JugadorActual)
    {
        TextoPrincipal.text = "Turno de " + JugadorActual.Nombre;
        DadoPrincipal.transform.position = new Vector3(3.84f, -3.7f, 1);
        yield return new WaitForSeconds(2);
    }
    public IEnumerator DeshabilitarHud(int a)
    {
        TextoPrincipal.text = "Lanzas un " + a;
        yield return new WaitForSeconds(1.3f);
        TextoPrincipal.text = "";
        DadoPrincipal.DisableDice();
    }
    public IEnumerator MostrarGanador(FichaScript JugadorGanador) 
    {
        TextoPrincipal.text = JugadorGanador.Nombre + " Ha ganado";
        yield return new WaitForSeconds(1);
        BotonNuevoJuego.gameObject.SetActive(true);
    }
    public void PrintMovimientoInvalido()
    {
        TextoPrincipal.text = "Movimiento invalido";
    }
    public void OnPressNuevoJuego()
    {
        GameObject Handler = GameObject.Find("TransicionManager");
        StartCoroutine(Handler.GetComponent<ActivarTransicion>().IniciarTransicion(1.4f,1));
    }
}
