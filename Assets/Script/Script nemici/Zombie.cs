using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Zombie : Nemico
{

    public float range, stoppingtimemax;
    protected float timeToStop, angolo;


    // Start is called before the first frame update
    protected override void Init()
    {
        barraVita = Instantiate(assetBarraVita, this.gameObject.transform);
        isMoving=true;
        angolo=0;
        animator.SetBool("isInMovement", true);
        timeToStop=stoppingtimemax;
        agent.speed = 9.0f;
        StartCoroutine(aspetta1());
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanza= Vector3.Distance(target.transform.position, transform.position);
        Vector3 differenza=target.transform.position-transform.position;
        angolo= Mathf.Atan2(differenza.x, differenza.z)*Mathf.Rad2Deg;
        transform.rotation= Quaternion.Euler(0, angolo, 0);   
        }

    IEnumerator aspetta1(){
        while(true){
        interruttore();
        yield return new WaitForSeconds(stoppingtimemax);
        }
    }

    public void interruttore(){
        if(isMoving && !agent.isStopped){
            isMoving=false;
            agent.isStopped = true;
        }
            
        else{
            isMoving=true;
            agent.isStopped = false;
            agent.SetDestination(target.transform.position);
        }
            
    }

    public override void prendiDanno(int damage){
        if((this.vita-damage)>0)
        this.vita-=damage;
        else{
        StopAllCoroutines();
        Partita.distruggi(gameObject);
        }
    }


     
     
     /*   if(distanza>=range){
            float stop = 2.0f;
            Vector3 differenza=target.transform.position-transform.position;
            float angolo= Mathf.Atan2(differenza.x, differenza.z)*Mathf.Rad2Deg;
            transform.rotation= Quaternion.Euler(0, angolo, 0);
            agent.SetDestination(target.transform.position);
            while(stop>0)
                stop-=Time.deltaTime;
            agent.velocity = Vector3.zero;
            }
            
        else {
            base.isMoving=false;
            timeToStop=stoppingtimemax;
        }
               */
 

    void Following(){
    /*    isMoving=true;
        agent.speed=0.2f;

        agent.SetDestination(target.transform.position);

       animator.SetBool("isInMovement", true); */
    }

    public override void attack(){
     /*  animator.SetBool("isInMovement", false);
        agent.SetDestination(target.transform.position);
        if(stoppingtime>0){
            stoppingtime-=Time.deltaTime;
           animator.SetBool("isAttacking", true);
            }
        else{
            stoppingtime=stoppingtimemax;
        isAttacking=false;
           animator.SetBool("isAttacking", false);
           animator.SetBool("isInMovement", true);
        } */
    } 
}
