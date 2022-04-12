using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Zombie : Nemico
{

    public float range, stoppingtimemax, stoppingtime;


    // Start is called before the first frame update
    protected override void Init()
    {
        GetComponent<Animator>().SetBool("isInMovement", true);
        stoppingtime=stoppingtimemax;
    }

    // Update is called once per frame
    void Update()
    {
        float distanza= Vector3.Distance(target.transform.position, transform.position);
        if(distanza>=range && isAttacking){
            Following();
        }
        else {
            base.isMoving=true;
            this.attack();
        }

    }

    void Following(){
        Vector3 differenza=target.transform.position-transform.position;
        float angolo= Mathf.Atan2(differenza.x, differenza.z)*Mathf.Rad2Deg;
        transform.rotation= Quaternion.Euler(0, angolo, 0);
        agent.SetDestination(target.transform.position);
        GetComponent<Animator>().SetBool("isInMovement", true);
    }

    public override void attack(){
        GetComponent<Animator>().SetBool("isInMovement", false);
        agent.SetDestination(transform.position);
        if(stoppingtime>0){
            stoppingtime-=Time.deltaTime;
            GetComponent<Animator>().SetBool("isAttacking", true);
            }
        else{
            stoppingtime=stoppingtimemax;
        isAttacking=false;
            GetComponent<Animator>().SetBool("isAttacking", false);
            GetComponent<Animator>().SetBool("isInMovement", true);
        }
    }
}
