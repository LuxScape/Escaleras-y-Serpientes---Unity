using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FichaScript : MonoBehaviour
{
    public string Nombre;
    public string Color;
    Transform Posicion;
    SpriteRenderer SpriteFicha;
    [SerializeField] Sprite FichaAmarilla;
    [SerializeField] Sprite FichaAzul;
    [SerializeField] Sprite FichaVerde;
    [SerializeField] Sprite FichaRoja;
    public int RollInicial;
    public bool IsTurnEnded = false;
    int PosicionActual=0;
    public bool Won=false;
    public bool InvalidMovement=false;

    // Obtenenos los componentes Necesarios para cambiar el sprite, y la posicion
    void Awake()
    {
        Posicion = GetComponent<Transform>();
        SpriteFicha = GetComponent<SpriteRenderer>();
    }
    public void InicializarFicha(string Nombre,string Color)// Input: Datos provenientes de Lista Jugadores
    {
        this.Nombre = Nombre;
        this.Color = Color;

        if (Color == "Amarillo")
        {
            SpriteFicha.sprite=FichaAmarilla;
        }
        else if (Color == "Azul")
        {
            SpriteFicha.sprite =FichaAzul;
        }
        else if (Color == "Verde")
        {
            SpriteFicha.sprite = FichaVerde;
        }
        else if (Color == "Rojo")
        {
            SpriteFicha.sprite = FichaRoja;
        }
        this.Posicion.SetLocalPositionAndRotation(new Vector2(-6,-5),transform.rotation); //Se coloca la ficha una cuadricula antes de la casilla 1
    }

    public void MoveChecker(int Num)
    {
        if(PosicionActual+Num > 100)
        {
            StartCoroutine(MovimientoInvalido());
        }
        else
        {
            StartCoroutine(Move(Num));
        }
    }
    IEnumerator MovimientoInvalido()
    {
        this.InvalidMovement = true;
        yield return new WaitForSeconds(1.3f);
        this.InvalidMovement = false;
        this.IsTurnEnded = true;
    }
    IEnumerator Move(int Num)
    {
        yield return new WaitForSeconds(1.3f);
        for (int i = 0; i < Num; i++)
        {
            if (Posicion.position.y %2 !=0 && PosicionActual%10!=0 || Posicion.position.x==-6)
            {
                MoveRight();
                PosicionActual++;
                yield return new WaitForSeconds(0.3f);
            }
            else if (Posicion.position.y %2 == 0 && PosicionActual % 10 != 0 || Posicion.position.x == -6)
            {
                MoveLeft();
                PosicionActual++;
                yield return new WaitForSeconds(0.3f);
            }
            else if (PosicionActual % 10 == 0)
            {
                MoveUp();
                PosicionActual++;
                yield return new WaitForSeconds(0.3f);
            }
        }
        yield return new WaitForSeconds(.6f);
        StartCoroutine(ComprobarCasilla());
    }
    void MoveLeft()
    {
        Vector3 VecPos=Posicion.position;
        VecPos.x -= 1;
        Posicion.position = VecPos;
        TableroAudioManager.PlayMoverFicha();
    }
    void MoveRight()
    {
        Vector3 VecPos = Posicion.position;
        VecPos.x += 1;
        Posicion.position = VecPos;
        TableroAudioManager.PlayMoverFicha();
    }
    void MoveUp()
    {
        Vector3 VecPos = Posicion.position;
        VecPos.y += 1;
        Posicion.position = VecPos;
        TableroAudioManager.PlayMoverFicha();
    }
    IEnumerator ComprobarCasilla()
    {
        //Escaleras
        if (PosicionActual == 5) 
        {
            Posicion.position=new Vector3(-2,-1,0);
            TableroAudioManager.PlayMoverFicha();
            PosicionActual = 44;
            yield return new WaitForSeconds(0.8f);
        }
        else if (PosicionActual == 14)
        {
            Posicion.position = new Vector3(3, -1, 0);
            TableroAudioManager.PlayMoverFicha();
            PosicionActual = 49;
            yield return new WaitForSeconds(0.8f);
        }
        else if (PosicionActual == 53)
        {
            Posicion.position = new Vector3(3, 2, 0);
            TableroAudioManager.PlayMoverFicha();
            PosicionActual = 72;
            yield return new WaitForSeconds(0.8f);
        }
        else if (PosicionActual == 64)
        {
            Posicion.position = new Vector3(-3, 3, 0);
            TableroAudioManager.PlayMoverFicha();
            PosicionActual = 83;
            yield return new WaitForSeconds(0.8f);
        }
        else if (PosicionActual == 74)
        {
            Posicion.position = new Vector3(1, 4, 0);
            TableroAudioManager.PlayMoverFicha();
            PosicionActual = 94;
            yield return new WaitForSeconds(0.8f);
        }

        //Serpientes
        else if (PosicionActual == 38)
        {
            Posicion.position = new Vector3(-5, -4, 0);
            TableroAudioManager.PlayMoverFicha();
            PosicionActual = 20;
            yield return new WaitForSeconds(0.8f);
        }
        else if(PosicionActual == 51)
        {
            Posicion.position = new Vector3(4, -5, 0);
            TableroAudioManager.PlayMoverFicha();
            PosicionActual = 10;
            yield return new WaitForSeconds(0.8f);
        }
        else if (PosicionActual == 76)
        {
            Posicion.position = new Vector3(1, 0, 0);
            TableroAudioManager.PlayMoverFicha();
            PosicionActual = 54;
            yield return new WaitForSeconds(0.8f);
        }
        else if (PosicionActual == 91)
        {
            Posicion.position = new Vector3(2, 2, 0);
            TableroAudioManager.PlayMoverFicha();
            PosicionActual = 73;
            yield return new WaitForSeconds(0.8f);
        }
        else if (PosicionActual == 97)
        {
            Posicion.position = new Vector3(-5, 1, 0);
            TableroAudioManager.PlayMoverFicha();
            PosicionActual = 61;
            yield return new WaitForSeconds(0.8f);
        }

        //Comprobar si ganamos
        if (PosicionActual == 100)
        {
            Won = true;
        }
        this.IsTurnEnded = true;
    }

}
