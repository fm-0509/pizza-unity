using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GeneraOstacoli : MonoBehaviour
{


    void Start()
    {

    }

    public static void generaOstacoli(GameObject[] ArrayOstacoli, int livello){
        int n=(int)Random.Range(0,3);
        List<GameObject> lista= new List<GameObject>();
        for(int i=0; i<n; i++){
             lista.Add(Instantiate(ArrayOstacoli[(int)Random.Range(0, ArrayOstacoli.Length)], new Vector3(0,1,(i*5-4)+(25*livello)), new Quaternion(0,0,0,0)));
        }
        Partita.getOstacoli().Add(livello, lista);
    }
}
