using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public float velocita;
    private Vector3 targetPosition;
    private GameObject target;

    void Start()
    {
        target=Partita.getTarget();
        if(target!=null){
        targetPosition = target.transform.position; 
        Vector3 projectileDirection= (targetPosition-transform.position).normalized*velocita;
        Rigidbody r = GetComponentInChildren<Rigidbody>();
        r.AddForce(projectileDirection, ForceMode.Impulse);
        }
    }

      void OnTriggerEnter(Collider hit){
        if(hit.gameObject.CompareTag("neemico")){
            Partita.converti(hit.gameObject).prendiDanno(25);
            Destroy(gameObject);
        }
        if(hit.CompareTag("ostacolo"))
            Destroy(gameObject);
    }

    void Update(){
        Destroy(gameObject,10);
    }

}
