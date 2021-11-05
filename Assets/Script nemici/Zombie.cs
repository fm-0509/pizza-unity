using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Zombie : MonoBehaviour
{
    NavMeshAgent agent;
    Transform target;
    public float range, stoppingtimemax, stoppingtime;
    bool attack;


    // Start is called before the first frame update
    void Start()
    {
        target=GameObject.Find("Player").transform;
        agent=GetComponent<NavMeshAgent>();
        GetComponent<Animator>().SetBool("isInMovement", true);
        stoppingtime=stoppingtimemax;
        attack=false;
    }

    // Update is called once per frame
    void Update()
    {
        float distanza= Vector3.Distance(target.position, transform.position);
        if(distanza>=range && !attack){
            Following();
        }
        else {
            attack=true;
            Attacking();
        }

    }

    void Following(){
        Vector3 differenza=target.position-transform.position;
        float angolo= Mathf.Atan2(differenza.x, differenza.z)*Mathf.Rad2Deg;
        transform.rotation= Quaternion.Euler(0, angolo, 0);
        agent.SetDestination(target.position);
        GetComponent<Animator>().SetBool("isInMovement", true);
    }

    void Attacking(){
        GetComponent<Animator>().SetBool("isInMovement", false);
        agent.SetDestination(transform.position);
        if(stoppingtime>0){
            stoppingtime-=Time.deltaTime;
            GetComponent<Animator>().SetBool("isAttacking", true);
            }
        else{
            stoppingtime=stoppingtimemax;
            attack=false;
            GetComponent<Animator>().SetBool("isAttacking", false);
            GetComponent<Animator>().SetBool("isInMovement", true);
        }
    }
}
