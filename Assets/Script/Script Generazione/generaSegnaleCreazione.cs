using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generaSegnaleCreazione : MonoBehaviour
{
    public static int livello;
    public GameObject[] asset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision){
        int i = Random.Range(0,asset.Length);
        livello = livello + 1;
        generaPavimentoNew.generaLivello(livello, asset[i]);
    }
}

