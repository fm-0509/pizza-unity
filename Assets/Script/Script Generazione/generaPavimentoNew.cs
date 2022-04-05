using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class generaPavimentoNew : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static void generaLivello(int livello, GameObject prefab){
        Vector3 vettore = new Vector3(0,0,30*livello);
        Quaternion q = new Quaternion(0,0,0,0);
        Instantiate(prefab, vettore, q);
    }


}
