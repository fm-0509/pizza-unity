using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generaSegnaleCreazione : MonoBehaviour
{
    public static int livello;
<<<<<<< HEAD
    public GameObject[] asset;
=======
    public GameObject asset;
>>>>>>> dev
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision){
<<<<<<< HEAD
        int i = Random.Range(0,asset.Length);
        livello = livello + 1;
        generaPavimentoNew.generaLivello(livello, asset[i]);
    }
}

=======
        livello = livello + 1;
        generaPavimentoNew.generaLivello(livello, asset);
    }
}
>>>>>>> dev
