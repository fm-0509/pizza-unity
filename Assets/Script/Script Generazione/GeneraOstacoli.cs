using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GeneraOstacoli : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    public static void generaOstacoli(GameObject[] ArrayMappe, int casuale, Vector3 v, Quaternion q){
        int indice = casuale%ArrayMappe.Length;
        Instantiate(ArrayMappe[indice], v, q);
    }
}
