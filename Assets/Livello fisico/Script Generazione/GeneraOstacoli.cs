using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GeneraOstacoli : MonoBehaviour
{
    public GameObject asset;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] muro = GameObject.FindGameObjectsWithTag("muroImportante");
        Vector3 distanza = new Vector3(1,0,4);
        Instantiate(asset, muro[1].transform.position+distanza, Quaternion.identity, GameObject.FindGameObjectWithTag("ostacolo").transform);

    }
}
