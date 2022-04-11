using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class generaPavimentoNew : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
<<<<<<< Updated upstream
        Instantiate(prefab);
=======
=======
>>>>>>> dev
        
    }

<<<<<<< HEAD
    public static void generaLivello(Vector3 vettore, Quaternion q, GameObject prefab){
=======
    public static void generaLivello(int livello, GameObject prefab){
<<<<<<< HEAD
        Vector3 vettore = new Vector3(0,0,25*livello);
        Instantiate(prefab, vettore, prefab.transform.rotation);
>>>>>>> Stashed changes
=======
        Vector3 vettore = new Vector3(0,0,30*livello);
        Quaternion q = new Quaternion(0,0,0,0);
>>>>>>> dev
        Instantiate(prefab, vettore, q);
>>>>>>> dev
    }


}
