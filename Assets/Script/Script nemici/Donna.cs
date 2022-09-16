using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Donna : Nemico
{
    
    public float moovingTime, rayTime, waitingTime;
    float time, ray;
    LineRenderer laser;
    public GameObject coltello;
    Vector3 lastPosition, shotPosition;
    Vector3 randPos;
   /* GameObject barraVita;
    public GameObject assetBarraVita; */
    // Start is called before the first frame update
    protected override void Init()
    {
        barraVita = Instantiate(assetBarraVita, this.gameObject.transform);
        isMoving=true;
        time=moovingTime;
        ray=rayTime;
        laser=GetComponent<LineRenderer>();
        laser.startWidth = 0.2f;
        laser.endWidth = 0.2f;
        shotPosition=transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        if(isMoving){
            GetComponentInChildren<Animator>().SetBool("IsMooving", true);
            GetComponentInChildren<Animator>().SetBool("isAttacking", false);
            laser.enabled=false;
            Move();
        }
        if(isAttacking){
            GetComponentInChildren<Animator>().SetBool("IsMooving", false);
            GetComponentInChildren<Animator>().SetBool("isAttacking", true);
            laser.SetPosition(0, transform.position+new Vector3(0,1,0));
            attack();
        }
    }

    void Move(){
        if(time==moovingTime){
            randPos= new Vector3(Random.Range(-2, 2), 0, Random.Range(-2, 2)).normalized;
            agent.SetDestination(transform.position+randPos*2);
            time-=Time.deltaTime;
        }
        else if(time>=0){
            time-=Time.deltaTime;
        }
        else{
            isMoving=false;
            isAttacking=true;
            time=moovingTime;
        }
    }

    public override void attack(){
        Vector3 differenza=target.transform.position-transform.position;
        float angolo= Mathf.Atan2(differenza.x, differenza.z)*Mathf.Rad2Deg+90;
        transform.rotation= Quaternion.Euler(0, angolo-90, 0);
        if(ray<=waitingTime){
            ray-=Time.deltaTime;
            animator.SetBool("isAttacking", true);
            shotPosition=transform.position+differenza.normalized;
            laser.enabled=false;
        }
        if(ray>waitingTime){
            ray-=Time.deltaTime;
            laser.enabled=true;
            lastPosition= target.transform.position;
            laser.SetPosition(1, lastPosition);
        }
        if(ray<=0){
            ray=rayTime;
            Instantiate(coltello, shotPosition, Quaternion.Euler(90, angolo,0));
            isMoving=true;
            isAttacking=false;
        }
    }

    void OnTriggerEnter(Collider hit){
        if(hit.CompareTag("Wall"))
            agent.SetDestination(transform.position-randPos*0.2f);
    }
}
