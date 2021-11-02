using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Nemico2 : MonoBehaviour
{
    NavMeshAgent agent;
    Transform target;
    public float range;

    // Start is called before the first frame update
    void Start()
    {
        target=GameObject.Find("Player").transform;
        agent=GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanza= Vector3.Distance(target.position, transform.position);
        if(distanza<=range){
            agent.SetDestination(target.position);
            GetComponent<Animator>().SetBool("isInMovement", true);
        }
        else
            GetComponent<Animator>().SetBool("isInMovement", false);
    }
}
