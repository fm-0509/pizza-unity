using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class generaPavimentoNew : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
<<<<<<< Updated upstream
        Instantiate(prefab);
=======
        
    }

    public static void generaLivello(int livello, GameObject prefab){
        Vector3 vettore = new Vector3(0,0,25*livello);
        Instantiate(prefab, vettore, prefab.transform.rotation);
>>>>>>> Stashed changes
    }


}
