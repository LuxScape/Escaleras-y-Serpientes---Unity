using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFondo : MonoBehaviour
{
    [SerializeField] HandlerObjetosBackground Prefab;
    float Timer;
    float TimerMax = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > TimerMax)
        {
            Timer -= TimerMax;
            Instantiate(Prefab, new Vector3(5, 5, 0), Quaternion.identity);
            Instantiate(Prefab, new Vector3(3, 5, 0), Quaternion.identity);
            Instantiate(Prefab, new Vector3(1, 5, 0), Quaternion.identity);
            Instantiate(Prefab, new Vector3(-1, 5, 0), Quaternion.identity);
            Instantiate(Prefab, new Vector3(-3, 5, 0), Quaternion.identity);
            Instantiate(Prefab, new Vector3(-5, 5, 0), Quaternion.identity);
            Instantiate(Prefab, new Vector3(5, 3, 0), Quaternion.identity);
            Instantiate(Prefab, new Vector3(5, 1, 0), Quaternion.identity);
            Instantiate(Prefab, new Vector3(5, -1, 0), Quaternion.identity);
            Instantiate(Prefab, new Vector3(5, -3, 0), Quaternion.identity);
            Instantiate(Prefab, new Vector3(5, -5, 0), Quaternion.identity);
        }
    }
}
