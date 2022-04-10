using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Poliziotto : Nemico
{
    public float timeBetweenShoots;

    float waitingTime;
    public GameObject proiettile;
    private List<GameObject> proiettiliVolanti;
    // Start is called before the first frame update
     protected override void Init()
    {
        proiettiliVolanti = new List<GameObject>();
        waitingTime=timeBetweenShoots;
      //  GetComponent<Animator>().SetBool("isShooting", false);
    }

    // Update is called once per frame
    void Update()
    {
        this.attack();
        base.isAttacking=true;
    }

        public override void attack(){
        Vector3 differenza=target.transform.position-transform.position;
        float angolo= Mathf.Atan2(differenza.x, differenza.z)*Mathf.Rad2Deg;
        transform.rotation= Quaternion.Euler(0, angolo, 0);
        if(waitingTime<=0){
            proiettiliVolanti.Add(Instantiate(proiettile, transform.position+differenza.normalized, Quaternion.Euler(90, angolo,0))); 
            waitingTime=timeBetweenShoots;
            //GetComponent<Animator>().SetBool("isShooting", true);
        }
        else{
            waitingTime-=Time.deltaTime;
           // GetComponent<Animator>().SetBool("isShooting", false);
        }

    }
}
