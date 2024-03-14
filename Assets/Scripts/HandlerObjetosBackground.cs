using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class HandlerObjetosBackground : MonoBehaviour
{
    float Timer;
    [SerializeField] Sprite SpriteFlecha;
    [SerializeField] Sprite SpriteInterrogacion;
    List<Sprite> Sprites = new List<Sprite>();
    // Start is called before the first frame update
    void Awake()
    {
        Sprites.Add(SpriteFlecha);
        Sprites.Add (SpriteInterrogacion);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        SpriteRenderer rb2 = rb.GetComponent<SpriteRenderer>();
        rb2.sprite = Sprites[Random.Range(0,2)];
        rb.AddForce(new Vector3(-1, -1, 0),ForceMode2D.Impulse);       
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > 11.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
