using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testoLivello : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Text>().text="Livello " + Partita.getLivelloCorrente();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Text>().text="Livello " + Partita.getLivelloCorrente();
    }
}
