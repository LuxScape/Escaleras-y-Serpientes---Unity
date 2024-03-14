using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DadoScript : MonoBehaviour
{
    [SerializeField] Sprite Numero1;
    [SerializeField] Sprite Numero2;
    [SerializeField] Sprite Numero3;
    [SerializeField] Sprite Numero4;
    [SerializeField] Sprite Numero5;
    [SerializeField] Sprite Numero6;
    [SerializeField] UnityEngine.UI.Button Boton;
    [SerializeField] List<Sprite> DadoSprites= new List<Sprite>();
    SpriteRenderer SpriteDado;
    bool IsStandby=true;
    // Start is called before the first frame update
    void Start()
    {
        DadoSprites.Add(Numero1);
        DadoSprites.Add(Numero2);
        DadoSprites.Add(Numero3);
        DadoSprites.Add(Numero4);
        DadoSprites.Add(Numero5);
        DadoSprites.Add(Numero6);
        SpriteDado = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount %20== 0 && IsStandby)
        {
            SpriteDado.sprite = DadoSprites[Random.Range(0, 6)];
        }
    }
    public int Roll()
    {
        TableroAudioManager.PlayLanzarDado();
        IsStandby = false;
        int NumeroRandom= Random.Range(0,6);
        Sprite NumeroObtenido = DadoSprites[NumeroRandom];
        SpriteDado.sprite = NumeroObtenido;
        return NumeroRandom+1;
    }
    public void ResetFlags()
    {
        this.IsStandby = true;
    }
    public void DisableButton()
    {
        this.Boton.interactable = false;
    }
    public void DisableDice()
    {
        this.gameObject.SetActive(false);
    }
    public void EnableButton()
    {
        this.Boton.interactable= true;
    }
    public void Destruir()
    {
        Destroy(this.gameObject);
    }
}
