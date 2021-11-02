using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proiettile : MonoBehaviour
{
    public float velocita;
    private Vector3 targetPosition;
    private GameObject target;
    void Start()
    {
        target=GameObject.FindGameObjectWithTag("Player");
        targetPosition = target.transform.position;
        Vector3 projectileDirection= (targetPosition-transform.position).normalized*velocita;
        GetComponent<Rigidbody>().AddForce(projectileDirection, ForceMode.Impulse); 
    }

    void OnTriggerEnter(Collider hit){
        if(hit.CompareTag("Player") || hit .CompareTag("Wall"))
            Destroy(gameObject);
    }

}
