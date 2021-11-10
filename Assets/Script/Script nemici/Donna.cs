using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Donna : MonoBehaviour
{
    
    public float moovingTime, rayTime;
    float time, ray;
    bool move, attack;
    LineRenderer laser;
    GameObject target;
    public GameObject coltello;
    Vector3 lastPosition;
    Vector3 randPos;
    // Start is called before the first frame update
    void Start()
    {
        time=moovingTime;
        ray=rayTime;
        move=true;
        attack=false;
        target=GameObject.FindGameObjectWithTag("Player");
        laser=GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(move){
            GetComponent<Animator>().SetBool("IsMooving", true);
            GetComponent<Animator>().SetBool("isAttacking", false);
            laser.enabled=false;
            Move();
        }
        if(attack){
            GetComponent<Animator>().SetBool("IsMooving", false);
            laser.SetPosition(0, transform.position+new Vector3(0,1,0));
            Attack();
        }
    }

    void Move(){
        if(time==moovingTime){
            randPos= new Vector3(Random.Range(-2, 2), 0, Random.Range(-2, 2)).normalized;
            GetComponent<NavMeshAgent>().SetDestination(transform.position+randPos*2);
            time-=Time.deltaTime;
        }
        else if(time>=0){
            time-=Time.deltaTime;
        }
        else{
            move=false;
            attack=true;
            time=moovingTime;
        }
    }

    void Attack(){
        Vector3 differenza=target.transform.position-transform.position;
        float angolo= Mathf.Atan2(differenza.x, differenza.z)*Mathf.Rad2Deg+90;
        transform.rotation= Quaternion.Euler(0, angolo-90, 0);
        if(ray<=0.7f){
            GetComponent<Animator>().SetBool("isAttacking", true);
        }

        if(ray>=0){
            ray-=Time.deltaTime;
            laser.enabled=true;
            lastPosition= target.transform.position;
            laser.SetPosition(1, lastPosition);
        }
        else{
            ray=rayTime;
            Instantiate(coltello, transform.position+differenza.normalized, Quaternion.Euler(90, angolo,0));
            move=true;
            attack=false;
        }
    }

    void OnTriggertEnter(Collider hit){
        if(hit.CompareTag("Wall"))
            GetComponent<NavMeshAgent>().SetDestination(transform.position-randPos*0.2f);
    }
}
