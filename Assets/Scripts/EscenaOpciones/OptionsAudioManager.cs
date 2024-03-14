using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsAudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] Objects = GameObject.FindGameObjectsWithTag("MusicController");
        if (Objects.Length > 1)
        {
            Destroy(Objects[1]);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
