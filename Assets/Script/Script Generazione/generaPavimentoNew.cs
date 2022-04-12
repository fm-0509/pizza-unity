using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class generaPavimentoNew : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static void generaLivello(Vector3 vettore, Quaternion q, GameObject prefab){
        Instantiate(prefab, vettore, q);
    }


}
