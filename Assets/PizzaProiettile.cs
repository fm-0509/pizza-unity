using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaProiettile : MonoBehaviour
{

    void OnTriggerEnter(Collider hit)
    {

        if (hit.gameObject.CompareTag("neemico"))
        {
            Partita.converti(hit.gameObject).prendiDanno(25);
            Destroy(gameObject.transform.parent.transform.parent.gameObject);
        }
        if (hit.CompareTag("ostacolo"))
            Destroy(gameObject.transform.parent.transform.parent.gameObject);
        if (hit.CompareTag("Wall"))
            Destroy(gameObject.transform.parent.transform.parent.gameObject);
    }
}
